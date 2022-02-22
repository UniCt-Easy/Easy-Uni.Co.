
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
-- CREAZIONE TABELLA registryreference --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryreference]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryreference] (
idreg int NOT NULL,
idregistryreference int NOT NULL,
activeweb char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(200) NULL,
faxnumber varchar(50) NULL,
flagdefault char(1) NULL,
iterweb int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
mobilenumber varchar(20) NULL,
msnnumber varchar(50) NULL,
passwordweb varchar(40) NULL,
pec varchar(200) NULL,
phonenumber varchar(50) NULL,
referencename varchar(50) NOT NULL,
registryreferencerole varchar(50) NULL,
rtf image NULL,
saltweb varchar(20) NULL,
skypenumber varchar(50) NULL,
txt text NULL,
userweb varchar(40) NULL,
website varchar(512) NULL,
 CONSTRAINT xpkregistryreference PRIMARY KEY (idreg,
idregistryreference
)
)
END
GO

-- VERIFICA STRUTTURA registryreference --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryreference') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryreference] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'idregistryreference' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD idregistryreference int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryreference') and col.name = 'idregistryreference' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryreference] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'activeweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD activeweb char(1) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN activeweb char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryreference') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryreference] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryreference') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryreference] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD email varchar(200) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN email varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'faxnumber' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD faxnumber varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN faxnumber varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'flagdefault' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD flagdefault char(1) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN flagdefault char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'iterweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD iterweb int NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN iterweb int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryreference') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryreference] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryreference') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryreference] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'mobilenumber' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD mobilenumber varchar(20) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN mobilenumber varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'msnnumber' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD msnnumber varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN msnnumber varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'passwordweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD passwordweb varchar(40) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN passwordweb varchar(40) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'pec' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD pec varchar(200) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN pec varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'phonenumber' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD phonenumber varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN phonenumber varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'referencename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD referencename varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryreference') and col.name = 'referencename' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryreference] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN referencename varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'registryreferencerole' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD registryreferencerole varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN registryreferencerole varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'saltweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD saltweb varchar(20) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN saltweb varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'skypenumber' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD skypenumber varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN skypenumber varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD txt text NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'userweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD userweb varchar(40) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN userweb varchar(40) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryreference' and C.name = 'website' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryreference] ADD website varchar(512) NULL 
END
ELSE
	ALTER TABLE [registryreference] ALTER COLUMN website varchar(512) NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registryreference' and id=object_id('registryreference'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registryreference
     ON registryreference (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registryreference
     ON registryreference (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA DI registryreference IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryreference'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryreference','int','assistenza2','idreg','4','S','int','System.Int32','','','''assistenza2''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryreference','int','assistenza2','idregistryreference','4','S','int','System.Int32','','','''assistenza2''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','char(1)','assistenza2','activeweb','1','N','char','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryreference','datetime','assistenza2','ct','8','S','datetime','System.DateTime','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryreference','varchar(64)','assistenza2','cu','64','S','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(200)','assistenza2','email','200','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(50)','assistenza2','faxnumber','50','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','char(1)','assistenza2','flagdefault','1','N','char','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','int','assistenza2','iterweb','4','N','int','System.Int32','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryreference','datetime','assistenza2','lt','8','S','datetime','System.DateTime','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryreference','varchar(64)','assistenza2','lu','64','S','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(20)','assistenza2','mobilenumber','20','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(50)','assistenza2','msnnumber','50','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(40)','assistenza2','passwordweb','40','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(200)','assistenza2','pec','200','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(50)','assistenza2','phonenumber','50','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryreference','varchar(50)','assistenza2','referencename','50','S','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(50)','assistenza2','registryreferencerole','50','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','image','assistenza2','rtf','16','N','image','System.Byte[]','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(20)','assistenza2','saltweb','20','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(50)','assistenza2','skypenumber','50','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','text','assistenza2','txt','16','N','text','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(40)','assistenza2','userweb','40','N','varchar','System.String','','','''assistenza2''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryreference','varchar(512)','','website','512','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI registryreference IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryreference')
UPDATE customobject set isreal = 'S' where objectname = 'registryreference'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryreference', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registryreference')
UPDATE [tabledescr] SET description = 'Contatto',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:29.047'},lu = 'nino',title = 'Contatto' WHERE tablename = 'registryreference'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registryreference','Contatto',null,'S',{ts '1900-01-01 03:00:29.047'},'nino','Contatto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'activeweb' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'accesso web attivato?',kind = 'C',lt = {ts '2017-01-20 13:28:37.690'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'activeweb' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('activeweb','registryreference','1',null,null,'accesso web attivato?','C',{ts '2017-01-20 13:28:37.690'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.193'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registryreference','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.193'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.627'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registryreference','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.627'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Email',kind = 'S',lt = {ts '1900-01-01 03:00:13.380'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email','registryreference','200',null,null,'Email','S',{ts '1900-01-01 03:00:13.380'},'nino','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'faxnumber' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Numero fax.',kind = 'S',lt = {ts '1900-01-01 03:00:23.000'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'faxnumber' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('faxnumber','registryreference','50',null,null,'Numero fax.','S',{ts '1900-01-01 03:00:23.000'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagdefault' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Contatto predefinito',kind = 'C',lt = {ts '2016-02-07 09:12:56.327'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagdefault' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagdefault','registryreference','1',null,null,'Contatto predefinito','C',{ts '2016-02-07 09:12:56.327'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:52.507'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registryreference','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:52.507'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryreference' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '#',kind = 'S',lt = {ts '1900-01-01 03:00:23.007'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryreference' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryreference','registryreference','4',null,null,'#','S',{ts '1900-01-01 03:00:23.007'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iterweb' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'iterazioni algoritmo di hashing',kind = 'S',lt = {ts '2017-01-20 11:57:02.887'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iterweb' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iterweb','registryreference','4',null,null,'iterazioni algoritmo di hashing','S',{ts '2017-01-20 11:57:02.887'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:42.950'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registryreference','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:42.950'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:39.980'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registryreference','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:39.980'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'mobilenumber' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Num. cellulare',kind = 'S',lt = {ts '1900-01-01 03:00:23.010'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'mobilenumber' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('mobilenumber','registryreference','20',null,null,'Num. cellulare','S',{ts '1900-01-01 03:00:23.010'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'msnnumber' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'MSN No.',kind = 'S',lt = {ts '1900-01-01 03:00:23.013'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'msnnumber' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('msnnumber','registryreference','50',null,null,'MSN No.','S',{ts '1900-01-01 03:00:23.013'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'passwordweb' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '40',col_precision = null,col_scale = null,description = 'password per accesso web',kind = 'S',lt = {ts '2016-10-09 09:56:11.620'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(40)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'passwordweb' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('passwordweb','registryreference','40',null,null,'password per accesso web','S',{ts '2016-10-09 09:56:11.620'},'nino','N','varchar(40)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'phonenumber' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Numero tel.',kind = 'S',lt = {ts '1900-01-01 03:00:23.017'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'phonenumber' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('phonenumber','registryreference','50',null,null,'Numero tel.','S',{ts '1900-01-01 03:00:23.017'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'referencename' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Nome Contatto',kind = 'S',lt = {ts '1900-01-01 03:00:23.020'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'referencename' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('referencename','registryreference','50',null,null,'Nome Contatto','S',{ts '1900-01-01 03:00:23.020'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'registryreferencerole' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Funzione contatto',kind = 'S',lt = {ts '1900-01-01 03:00:23.023'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'registryreferencerole' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('registryreferencerole','registryreference','50',null,null,'Funzione contatto','S',{ts '1900-01-01 03:00:23.023'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.580'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','registryreference','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.580'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'saltweb' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'sale per la codifica della password',kind = 'S',lt = {ts '2017-01-20 11:57:02.890'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'saltweb' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('saltweb','registryreference','20',null,null,'sale per la codifica della password','S',{ts '2017-01-20 11:57:02.890'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'skypenumber' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Skype No.',kind = 'S',lt = {ts '1900-01-01 03:00:23.027'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'skypenumber' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('skypenumber','registryreference','50',null,null,'Skype No.','S',{ts '1900-01-01 03:00:23.027'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.277'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','registryreference','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.277'},'nino','N','text','text','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'userweb' AND tablename = 'registryreference')
UPDATE [coldescr] SET col_len = '40',col_precision = null,col_scale = null,description = 'login web',kind = 'S',lt = {ts '2016-10-09 09:56:11.620'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(40)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'userweb' AND tablename = 'registryreference'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('userweb','registryreference','40',null,null,'login web','S',{ts '2016-10-09 09:56:11.620'},'nino','N','varchar(40)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'activeweb' AND tablename = 'registryreference' AND value = 'N')
UPDATE [colvalue] SET description = 'L''utente non pu? accedere ai servizi web.',lt = {ts '2017-04-25 14:54:29.160'},lu = 'nino',title = 'Non attivo' WHERE colname = 'activeweb' AND tablename = 'registryreference' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('activeweb','registryreference','N','L''utente non pu? accedere ai servizi web.',{ts '2017-04-25 14:54:29.160'},'nino','Non attivo')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'activeweb' AND tablename = 'registryreference' AND value = 'S')
UPDATE [colvalue] SET description = 'L''utente pu?  accedere ai servizi web.',lt = {ts '2017-04-25 14:54:46.020'},lu = 'nino',title = 'Attivo' WHERE colname = 'activeweb' AND tablename = 'registryreference' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('activeweb','registryreference','S','L''utente pu?  accedere ai servizi web.',{ts '2017-04-25 14:54:46.020'},'nino','Attivo')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagdefault' AND tablename = 'registryreference' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:12:56.327'},lu = 'Nino',title = 'Non è contatto predefinito' WHERE colname = 'flagdefault' AND tablename = 'registryreference' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagdefault','registryreference','N',null,{ts '2016-02-07 09:12:56.327'},'Nino','Non è contatto predefinito')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagdefault' AND tablename = 'registryreference' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:12:56.327'},lu = 'Nino',title = 'Contatto predefinito' WHERE colname = 'flagdefault' AND tablename = 'registryreference' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagdefault','registryreference','S',null,{ts '2016-02-07 09:12:56.327'},'Nino','Contatto predefinito')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '2098')
UPDATE [relation] SET childtable = 'registryreference',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:05.860'},lu = 'lu',parenttable = 'registry',title = 'Contatto' WHERE idrelation = '2098'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2098','registryreference','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:05.860'},'lu','registry','Contatto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '2098' AND parentcol = 'idreg')
UPDATE [relationcol] SET childcol = 'idreg',lt = {ts '2017-05-20 09:20:06.137'},lu = 'lu' WHERE idrelation = '2098' AND parentcol = 'idreg'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('2098','idreg','idreg',{ts '2017-05-20 09:20:06.137'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

