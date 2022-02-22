
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
-- CREAZIONE TABELLA bandodsserviziorequisito --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandodsserviziorequisito]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bandodsserviziorequisito] (
idbandodsserviziorequisito int NOT NULL,
idbandodsservizio int NOT NULL,
idbandods int NOT NULL,
idtipologiastudente int NOT NULL,
cfbonus decimal(9,2) NULL,
cfbonushp decimal(9,2) NULL,
cfconseguiti decimal(9,2) NULL,
cfconseguitihp decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkbandodsserviziorequisito PRIMARY KEY (idbandodsserviziorequisito,
idbandodsservizio,
idbandods,
idtipologiastudente
)
)
END
GO

-- VERIFICA STRUTTURA bandodsserviziorequisito --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'idbandodsserviziorequisito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD idbandodsserviziorequisito int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'idbandodsserviziorequisito' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'idbandodsservizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD idbandodsservizio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'idbandodsservizio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'idbandods' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD idbandods int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'idbandods' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'idtipologiastudente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD idtipologiastudente int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'idtipologiastudente' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'cfbonus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD cfbonus decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN cfbonus decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'cfbonushp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD cfbonushp decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN cfbonushp decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'cfconseguiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD cfconseguiti decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN cfconseguiti decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'cfconseguitihp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD cfconseguitihp decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN cfconseguitihp decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandodsserviziorequisito' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandodsserviziorequisito] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandodsserviziorequisito') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandodsserviziorequisito] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandodsserviziorequisito] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI bandodsserviziorequisito IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandodsserviziorequisito'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','int','ASSISTENZA','idbandods','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','int','ASSISTENZA','idbandodsservizio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','int','ASSISTENZA','idbandodsserviziorequisito','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','int','ASSISTENZA','idtipologiastudente','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodsserviziorequisito','decimal(9,2)','ASSISTENZA','cfbonus','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodsserviziorequisito','decimal(9,2)','ASSISTENZA','cfbonushp','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodsserviziorequisito','decimal(9,2)','ASSISTENZA','cfconseguiti','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandodsserviziorequisito','decimal(9,2)','ASSISTENZA','cfconseguitihp','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandodsserviziorequisito','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI bandodsserviziorequisito IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandodsserviziorequisito')
UPDATE customobject set isreal = 'S' where objectname = 'bandodsserviziorequisito'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandodsserviziorequisito', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'bandodsserviziorequisito')
UPDATE [tabledescr] SET description = 'Requisiti di accesso ad un servizio di un 2.5.12 Bando per il diritto allo studio
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 16:54:00.277'},lu = 'assistenza',title = 'Requisiti di accesso ad un servizio di un bando per il diritto allo studio' WHERE tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('bandodsserviziorequisito','Requisiti di accesso ad un servizio di un 2.5.12 Bando per il diritto allo studio
',null,'N',{ts '2018-07-27 16:54:00.277'},'assistenza','Requisiti di accesso ad un servizio di un bando per il diritto allo studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfbonus' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti formativi massimi di bonus che si possono richiedere ',kind = 'S',lt = {ts '2019-11-29 10:07:35.750'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfbonus' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfbonus','bandodsserviziorequisito','5','9','2','Crediti formativi massimi di bonus che si possono richiedere ','S',{ts '2019-11-29 10:07:35.750'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfbonushp' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti formativi massimi di bonus che si possono richiedere per portatori di handicap ',kind = 'S',lt = {ts '2019-11-29 10:07:35.750'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfbonushp' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfbonushp','bandodsserviziorequisito','5','9','2','Crediti formativi massimi di bonus che si possono richiedere per portatori di handicap ','S',{ts '2019-11-29 10:07:35.750'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfconseguiti' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti formativi minimi conseguiti negli anni accademici precedenti ',kind = 'S',lt = {ts '2019-11-29 10:07:35.750'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfconseguiti' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfconseguiti','bandodsserviziorequisito','5','9','2','Crediti formativi minimi conseguiti negli anni accademici precedenti ','S',{ts '2019-11-29 10:07:35.750'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfconseguitihp' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti formativi minimi conseguiti negli anni accademici precedenti per portatori di handicap ',kind = 'S',lt = {ts '2019-11-29 10:07:35.750'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfconseguitihp' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfconseguitihp','bandodsserviziorequisito','5','9','2','Crediti formativi minimi conseguiti negli anni accademici precedenti per portatori di handicap ','S',{ts '2019-11-29 10:07:35.750'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:54:04.017'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','bandodsserviziorequisito','8',null,null,null,'S',{ts '2018-07-27 16:54:04.017'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:54:04.017'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','bandodsserviziorequisito','64',null,null,null,'S',{ts '2018-07-27 16:54:04.017'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandods' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:03:51.007'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandods' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandods','bandodsserviziorequisito','4',null,null,null,'S',{ts '2019-11-29 10:03:51.007'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandodsservizio' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:03:51.007'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandodsservizio' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandodsservizio','bandodsserviziorequisito','4',null,null,null,'S',{ts '2019-11-29 10:03:51.007'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandodsserviziorequisito' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:54:04.017'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandodsserviziorequisito' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandodsserviziorequisito','bandodsserviziorequisito','4',null,null,null,'S',{ts '2018-07-27 16:54:04.017'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipologiastudente' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:03:51.007'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipologiastudente' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipologiastudente','bandodsserviziorequisito','4',null,null,null,'S',{ts '2019-11-29 10:03:51.007'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:54:04.017'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','bandodsserviziorequisito','8',null,null,null,'S',{ts '2018-07-27 16:54:04.017'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'bandodsserviziorequisito')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:54:04.017'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'bandodsserviziorequisito'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','bandodsserviziorequisito','64',null,null,null,'S',{ts '2018-07-27 16:54:04.017'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3399')
UPDATE [relation] SET childtable = 'bandodsserviziorequisito',description = 'servizio di cui è requisito',lt = {ts '2018-07-27 16:57:01.637'},lu = 'assistenza',parenttable = 'bandodsservizio',title = null WHERE idrelation = '3399'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3399','bandodsserviziorequisito','servizio di cui è requisito',{ts '2018-07-27 16:57:01.637'},'assistenza','bandodsservizio',null)
GO

-- FINE GENERAZIONE SCRIPT --

