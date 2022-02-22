
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


-- CREAZIONE TABELLA virtualuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[virtualuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[virtualuser] (
idvirtualuser int NOT NULL,
birthdate date NULL,
cf varchar(16) NULL,
codicedipartimento varchar(50) NOT NULL,
email varchar(200) NULL,
forename varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
surname varchar(50) NOT NULL,
sys_user varchar(30) NOT NULL,
userkind smallint NOT NULL,
username varchar(50) NOT NULL,
 CONSTRAINT xpkvirtualuser PRIMARY KEY (idvirtualuser
)
)
END
GO

-- VERIFICA STRUTTURA virtualuser --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'idvirtualuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD idvirtualuser int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('virtualuser') and col.name = 'idvirtualuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [virtualuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'birthdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD birthdate date NULL 
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN birthdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD cf varchar(16) NULL 
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN cf varchar(16) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'codicedipartimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD codicedipartimento varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('virtualuser') and col.name = 'codicedipartimento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [virtualuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN codicedipartimento varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD email varchar(200) NULL 
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN email varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'forename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD forename varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('virtualuser') and col.name = 'forename' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [virtualuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN forename varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'surname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD surname varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('virtualuser') and col.name = 'surname' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [virtualuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN surname varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'sys_user' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD sys_user varchar(30) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('virtualuser') and col.name = 'sys_user' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [virtualuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN sys_user varchar(30) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'userkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD userkind smallint NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('virtualuser') and col.name = 'userkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [virtualuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN userkind smallint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'virtualuser' and C.name = 'username' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [virtualuser] ADD username varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('virtualuser') and col.name = 'username' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [virtualuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [virtualuser] ALTER COLUMN username varchar(50) NOT NULL
GO

-- VERIFICA DI virtualuser IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'virtualuser'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','virtualuser','int','assistenza','idvirtualuser','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','virtualuser','date','assistenza','birthdate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','virtualuser','varchar(16)','assistenza','cf','16','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','virtualuser','varchar(50)','assistenza','codicedipartimento','50','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','virtualuser','varchar(200)','assistenza','email','200','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','virtualuser','varchar(50)','assistenza','forename','50','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','virtualuser','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','virtualuser','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','virtualuser','varchar(50)','assistenza','surname','50','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','virtualuser','varchar(30)','assistenza','sys_user','30','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','virtualuser','smallint','assistenza','userkind','2','S','smallint','System.Int16','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','virtualuser','varchar(50)','assistenza','username','50','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI virtualuser IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'virtualuser')
UPDATE customobject set isreal = 'S' where objectname = 'virtualuser'
ELSE
INSERT INTO customobject (objectname, isreal) values('virtualuser', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'virtualuser')
UPDATE [tabledescr] SET description = 'Utente web',idapplication = null,isdbo = null,lt = {ts '2017-05-20 15:26:28.413'},lu = 'nino',title = 'Utente web' WHERE tablename = 'virtualuser'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('virtualuser','Utente web',null,null,{ts '2017-05-20 15:26:28.413'},'nino','Utente web')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'birthdate' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.083'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'birthdate' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('birthdate','virtualuser','4',null,null,null,'S',{ts '1900-01-01 02:59:18.083'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'Codice fiscale',kind = 'S',lt = {ts '1900-01-01 03:00:10.617'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(16)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cf' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','virtualuser','16',null,null,'Codice fiscale','S',{ts '1900-01-01 03:00:10.617'},'nino','N','varchar(16)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicedipartimento' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.090'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicedipartimento' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicedipartimento','virtualuser','50',null,null,null,'S',{ts '1900-01-01 02:59:18.090'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Email',kind = 'S',lt = {ts '1900-01-01 03:00:13.403'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email','virtualuser','200',null,null,'Email','S',{ts '1900-01-01 03:00:13.403'},'nino','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'forename' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.097'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'forename' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('forename','virtualuser','50',null,null,null,'S',{ts '1900-01-01 02:59:18.097'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idvirtualuser' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '#',kind = 'S',lt = {ts '1900-01-01 03:00:30.387'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idvirtualuser' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idvirtualuser','virtualuser','4',null,null,'#','S',{ts '1900-01-01 03:00:30.387'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:43.527'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','virtualuser','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:43.527'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:40.557'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','virtualuser','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:40.557'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surname' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome',kind = 'S',lt = {ts '1900-01-01 03:00:15.407'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surname' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surname','virtualuser','50',null,null,'Cognome','S',{ts '1900-01-01 03:00:15.407'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sys_user' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '30',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.113'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(30)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'sys_user' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sys_user','virtualuser','30',null,null,null,'S',{ts '1900-01-01 02:59:18.113'},'nino','N','varchar(30)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'userkind' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.117'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'userkind' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('userkind','virtualuser','2',null,null,null,'S',{ts '1900-01-01 02:59:18.117'},'nino','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'username' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.120'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'username' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('username','virtualuser','50',null,null,null,'S',{ts '1900-01-01 02:59:18.120'},'nino','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

