
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
-- CREAZIONE TABELLA inventorytree --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inventorytree]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inventorytree] (
idinv int NOT NULL,
codeinv varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
idaccmotivediscount varchar(36) NULL,
idaccmotiveload varchar(36) NULL,
idaccmotivetransfer varchar(36) NULL,
idaccmotiveunload varchar(36) NULL,
lookupcode varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nlevel tinyint NOT NULL,
paridinv int NULL,
rtf image NULL,
txt text NULL,
 CONSTRAINT xpkinventorytree PRIMARY KEY (idinv
)
)
END
GO

-- VERIFICA STRUTTURA inventorytree --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD idinv int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'idinv' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'codeinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD codeinv varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'codeinv' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN codeinv varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idaccmotivediscount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD idaccmotivediscount varchar(36) NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN idaccmotivediscount varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idaccmotiveload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD idaccmotiveload varchar(36) NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN idaccmotiveload varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idaccmotivetransfer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD idaccmotivetransfer varchar(36) NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN idaccmotivetransfer varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'idaccmotiveunload' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD idaccmotiveunload varchar(36) NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN idaccmotiveunload varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'lookupcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD lookupcode varchar(50) NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN lookupcode varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD nlevel tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inventorytree') and col.name = 'nlevel' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inventorytree] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN nlevel tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'paridinv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD paridinv int NULL 
END
ELSE
	ALTER TABLE [inventorytree] ALTER COLUMN paridinv int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytree' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorytree] ADD txt text NULL 
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='UQ_1_inventorytree' and id=object_id('inventorytree'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorytree
     ON inventorytree (codeinv )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX UQ_1_inventorytree
     ON inventorytree (codeinv )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1inventorytree' and id=object_id('inventorytree'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorytree
     ON inventorytree (paridinv )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1inventorytree
     ON inventorytree (paridinv )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2inventorytree' and id=object_id('inventorytree'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventorytree
     ON inventorytree (nlevel )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2inventorytree
     ON inventorytree (nlevel )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA DI inventorytree IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inventorytree'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','int','ASSISTENZA','idinv','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','varchar(50)','ASSISTENZA','codeinv','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','varchar(150)','ASSISTENZA','description','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','varchar(36)','ASSISTENZA','idaccmotivediscount','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','varchar(36)','ASSISTENZA','idaccmotiveload','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','varchar(36)','ASSISTENZA','idaccmotivetransfer','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','varchar(36)','ASSISTENZA','idaccmotiveunload','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','varchar(50)','ASSISTENZA','lookupcode','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inventorytree','tinyint','ASSISTENZA','nlevel','1','S','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','int','ASSISTENZA','paridinv','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','image','ASSISTENZA','rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inventorytree','text','ASSISTENZA','txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI inventorytree IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inventorytree')
UPDATE customobject set isreal = 'S' where objectname = 'inventorytree'
ELSE
INSERT INTO customobject (objectname, isreal) values('inventorytree', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'inventorytree')
UPDATE [tabledescr] SET description = 'Classificazione inventariale',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:29.627'},lu = 'nino',title = 'Classificazione inventariale' WHERE tablename = 'inventorytree'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('inventorytree','Classificazione inventariale',null,'S',{ts '1900-01-01 03:00:29.627'},'nino','Classificazione inventariale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codeinv' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'codice class.inventariale (tab. inventorytree)',kind = 'S',lt = {ts '1900-01-01 03:00:12.080'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codeinv' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codeinv','inventorytree','50',null,null,'codice class.inventariale (tab. inventorytree)','S',{ts '1900-01-01 03:00:12.080'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:47.363'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','inventorytree','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:47.363'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.797'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','inventorytree','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.797'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:51.087'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','inventorytree','150',null,null,'Descrizione','S',{ts '1900-01-01 02:59:51.087'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivediscount' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'Causale ricavo in applicazione sconto',kind = 'S',lt = {ts '2019-03-11 17:00:55.007'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivediscount' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivediscount','inventorytree','36',null,null,'Causale ricavo in applicazione sconto','S',{ts '2019-03-11 17:00:55.007'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotiveload' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'causale di carico',kind = 'S',lt = {ts '2016-10-07 17:47:31.133'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotiveload' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotiveload','inventorytree','36',null,null,'causale di carico','S',{ts '2016-10-07 17:47:31.133'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivetransfer' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'Causale carico/scarico per trasferimento',kind = 'S',lt = {ts '2019-03-11 17:00:55.007'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivetransfer' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivetransfer','inventorytree','36',null,null,'Causale carico/scarico per trasferimento','S',{ts '2019-03-11 17:00:55.007'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotiveunload' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'causale di scarico',kind = 'S',lt = {ts '2016-10-07 17:47:31.133'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotiveunload' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotiveunload','inventorytree','36',null,null,'causale di scarico','S',{ts '2016-10-07 17:47:31.133'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinv' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID class. inventariale (tabella inventorytree)',kind = 'S',lt = {ts '1900-01-01 03:00:10.653'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinv' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinv','inventorytree','4',null,null,'ID class. inventariale (tabella inventorytree)','S',{ts '1900-01-01 03:00:10.653'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lookupcode' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'lookup usato in alcune migrazioni',kind = 'S',lt = {ts '2016-10-07 17:47:31.133'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lookupcode' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lookupcode','inventorytree','50',null,null,'lookup usato in alcune migrazioni','S',{ts '2016-10-07 17:47:31.133'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:42.047'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','inventorytree','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:42.047'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:39.077'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','inventorytree','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:39.077'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nlevel' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'N. livello',kind = 'S',lt = {ts '1900-01-01 02:59:21.557'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'nlevel' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nlevel','inventorytree','1',null,null,'N. livello','S',{ts '1900-01-01 02:59:21.557'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridinv' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id class.parent',kind = 'S',lt = {ts '2016-10-07 17:47:31.133'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'paridinv' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridinv','inventorytree','4',null,null,'id class.parent','S',{ts '2016-10-07 17:47:31.133'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.470'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','inventorytree','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.470'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'inventorytree')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.140'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'inventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','inventorytree','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.140'},'nino','N','text','text','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '37')
UPDATE [relation] SET childtable = 'inventorytree',description = 'causale di carico',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Classificazione inventariale' WHERE idrelation = '37'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('37','inventorytree','causale di carico',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Classificazione inventariale')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '38')
UPDATE [relation] SET childtable = 'inventorytree',description = 'causale di scarico',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Classificazione inventariale' WHERE idrelation = '38'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('38','inventorytree','causale di scarico',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Classificazione inventariale')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2967')
UPDATE [relation] SET childtable = 'inventorytree',description = 'N. livello',lt = {ts '2017-05-20 14:40:10.437'},lu = 'lu',parenttable = 'inventorysortinglevel',title = 'Classificazione inventariale' WHERE idrelation = '2967'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2967','inventorytree','N. livello',{ts '2017-05-20 14:40:10.437'},'lu','inventorysortinglevel','Classificazione inventariale')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3070')
UPDATE [relation] SET childtable = 'inventorytree',description = 'id class.parent',lt = {ts '2017-05-22 12:15:02.050'},lu = 'nino',parenttable = 'inventorytree',title = 'Classificazione inventariale' WHERE idrelation = '3070'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3070','inventorytree','id class.parent',{ts '2017-05-22 12:15:02.050'},'nino','inventorytree','Classificazione inventariale')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3454')
UPDATE [relation] SET childtable = 'inventorytree',description = 'Causale ricavo in applicazione sconto',lt = {ts '2019-03-11 17:01:45.880'},lu = 'nino',parenttable = 'accmotive',title = 'causale ricavo per sconto' WHERE idrelation = '3454'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3454','inventorytree','Causale ricavo in applicazione sconto',{ts '2019-03-11 17:01:45.880'},'nino','accmotive','causale ricavo per sconto')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3455')
UPDATE [relation] SET childtable = 'inventorytree',description = 'Causale carico/scarico per trasferimento',lt = {ts '2019-03-11 17:01:45.880'},lu = 'nino',parenttable = 'accmotive',title = 'causale carico/scarico per trasferimenti' WHERE idrelation = '3455'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3455','inventorytree','Causale carico/scarico per trasferimento',{ts '2019-03-11 17:01:45.880'},'nino','accmotive','causale carico/scarico per trasferimenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '37' AND parentcol = 'idaccmotive')
UPDATE [relationcol] SET childcol = 'idaccmotiveload',lt = {ts '2017-05-20 09:19:36.287'},lu = 'lu' WHERE idrelation = '37' AND parentcol = 'idaccmotive'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('37','idaccmotive','idaccmotiveload',{ts '2017-05-20 09:19:36.287'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

