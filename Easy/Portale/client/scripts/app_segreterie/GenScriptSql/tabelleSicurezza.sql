
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


setuser 'amministrazione'
--[DBO]--
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
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idvirtualuser','4','''assistenza''','int','virtualuser','','','','','N','S','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','birthdate','3','''assistenza''','date','virtualuser','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','cf','16','''assistenza''','varchar(16)','virtualuser','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','codicedipartimento','50','''assistenza''','varchar(50)','virtualuser','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','email','200','''assistenza''','varchar(200)','virtualuser','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','forename','50','''assistenza''','varchar(50)','virtualuser','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lt','8','''assistenza''','datetime','virtualuser','','','','','S','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lu','64','''assistenza''','varchar(64)','virtualuser','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','surname','50','''assistenza''','varchar(50)','virtualuser','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','sys_user','30','''assistenza''','varchar(30)','virtualuser','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','userkind','2','''assistenza''','smallint','virtualuser','','','','','N','N','smallint','assistenza','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','username','50','''assistenza''','varchar(50)','virtualuser','','','','','N','N','varchar','assistenza','System.String')
GO

-- VERIFICA DI virtualuser IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'virtualuser')
UPDATE customobject set isreal = 'S' where objectname = 'virtualuser'
ELSE
INSERT INTO customobject (objectname, isreal) values('virtualuser', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA dbaccess --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbaccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbaccess] (
alpha1 varchar(66) NULL,
iddbdepartment varchar(50) NOT NULL,
login varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
pwdlastmod date NULL,
pwdmaxage int NULL,
pwdwarning int NULL)
END
GO

-- VERIFICA STRUTTURA dbaccess --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'alpha1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD alpha1 varchar(66) NULL 
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN alpha1 varchar(66) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'iddbdepartment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD iddbdepartment varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dbaccess') and col.name = 'iddbdepartment' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dbaccess] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN iddbdepartment varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'login' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD login varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('dbaccess') and col.name = 'login' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [dbaccess] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN login varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'pwdlastmod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD pwdlastmod date NULL 
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN pwdlastmod date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'pwdmaxage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD pwdmaxage int NULL 
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN pwdmaxage int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'pwdwarning' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [dbaccess] ADD pwdwarning int NULL 
END
ELSE
	ALTER TABLE [dbaccess] ALTER COLUMN pwdwarning int NULL
GO

-- VERIFICA DI dbaccess IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dbaccess'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','alpha1','66','''assistenza''','varchar(66)','dbaccess','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','iddbdepartment','50','''assistenza''','varchar(50)','dbaccess','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','login','50','''assistenza''','varchar(50)','dbaccess','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lt','8','''assistenza''','datetime','dbaccess','','','','','S','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lu','64','''assistenza''','varchar(64)','dbaccess','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pwdlastmod','3','''assistenza''','date','dbaccess','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pwdmaxage','4','''assistenza''','int','dbaccess','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pwdwarning','4','''assistenza''','int','dbaccess','','','','','S','N','int','assistenza','System.Int32')
GO

-- VERIFICA DI dbaccess IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dbaccess')
UPDATE customobject set isreal = 'S' where objectname = 'dbaccess'
ELSE
INSERT INTO customobject (objectname, isreal) values('dbaccess', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

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

IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[EraseSecureVariable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[EraseSecureVariable]
GO

CREATE PROCEDURE EraseSecureVariable
	@variableName nvarchar(256)
AS
BEGIN
	
	--associazione tra il sistema di diritti con regole su tabella e variabile
	DELETE dbo.customgroupoperation WHERE allowcondition like ('%\[' +@variableName + '\]%') ESCAPE '\'
	--associazione tra organigramma e variabile
	DELETE amministrazione.[FlowChartrestrictedfunction] WHERE idrestrictedfunction = (select top (1) idrestrictedfunction from dbo.[restrictedfunction] WHERE variablename = @variableName) 
	--associazione tra utente e variabile 
	DELETE amministrazione.userenvironment where variablename = @variableName 
	--variabile nella tabella dei diritti per le tabelle
	DELETE dbo.[restrictedfunction] WHERE variablename = @variableName 
	--variabile 
	DELETE dbo.[securityvar] WHERE variablename = @variableName 

END
GO

--select 'exec EraseSecureVariable ''mw_' + cast (idmenuweb as varchar(10)) + ''';' from menuweb
--select 'exec EraseSecureVariable ''mr_' + cast (idmenuweb as varchar(10)) + ''';' from menuweb
--select 'exec EraseSecureVariable ''' + variablename + '''',* from securityvar where description like 'Menu Portale: %' order by variablename
--select 'exec EraseSecureVariable ''' + variablename + '''',* from securityvar where description like 'Menu Portale: %' order by variablename
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[menuweb_addentry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menuweb_addentry]
GO

/****** Object:  StoredProcedure [dbo].[menuweb_addentry]    Script Date: 25/09/2020 18:28:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ferdinando Caprilli
-- Create date: 30/11/2018
-- Description:	per aggiungere voci al men—
-- =============================================
ALTER PROCEDURE [dbo].[menuweb_addentry]
			@idmenuwebparent int = NULL
           ,@idx int = NULL
           ,@tableName nvarchar(60)
           ,@editType nvarchar(60)
           ,@label nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF(@idx IS NULL)
	BEGIN
		SET @idx = (SELECT isnull(MAX([idmenuweb]),0) + 1 FROM [dbo].[menuweb]);
	END

--INSERIMENTO NEL MENU WEB --------------BEGIN
    IF NOT EXISTS (
		SELECT [idmenuweb]
		FROM [dbo].[menuweb]
		WHERE isnull(idmenuwebparent,0) = isnull(@idmenuwebparent,0) AND
				(
				(tableName = @tableName AND editType = @editType)
				OR
				(tableName is null and @tableName is null and editType is null and @editType is null and [label] = @label)
				)
				)
	BEGIN
		INSERT INTO [dbo].[menuweb]
			   ([idmenuweb]
			   ,[idmenuwebparent]
			   ,[tableName]
			   ,[editType]
			   ,[label])
		 VALUES
			   (@idx
			   ,@idmenuwebparent
			   ,@tableName
			   ,@editType
			   ,@label );
	END
	ELSE
	BEGIN
		SET @idx = (SELECT [idmenuweb]
		FROM [dbo].[menuweb]
		WHERE isnull(idmenuwebparent,'') = isnull(@idmenuwebparent,'') AND
				(
				(tableName = @tableName AND editType = @editType)
				OR
				(tableName is null and @tableName is null and editType is null and @editType is null and [label] = @label)
				)
		)
	END
--INSERIMENTO NEL MENU WEB --------------END

--INSERIMENTO NELLE VARIABILI D'AMBIENTE --------------BEGIN
    BEGIN

        DECLARE  @varnamer varchar(50) = CONCAT('mr_', @idx);
        DECLARE  @descritpion varchar(100) = CONCAT('Menu Portale: ',  @label );
        DECLARE  @descritpionr varchar(100) = CONCAT('Menu Portale: ',  @label + ' - Lettura');
        DECLARE  @varnamew varchar(50) = CONCAT('mw_', @idx);
        DECLARE  @descritpionw varchar(100) = CONCAT('Menu Portale: ',  @label + ' - Scrittura');

		IF (@tableName IS NOT NULL)

		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SU TABELLA --------------BEGIN
		BEGIN

			--INSERIMENTO su tabella restrictedfunction --------------BEGIN
            IF NOT EXISTS (
        		SELECT [idrestrictedfunction]
        		FROM [dbo].[restrictedfunction]
        		WHERE variablename = @varnamer AND
        			 description = @descritpionr)
            BEGIN
                DECLARE @idxRestrictedFunctionr int = (SELECT isnull(MAX([idrestrictedfunction]),0) + 1 FROM [dbo].[restrictedfunction]);
                INSERT INTO [dbo].restrictedfunction
                               ([idrestrictedfunction]
                               ,[variablename]
                               ,[description],
							   [ct],[cu],[lt],[lu])
                         VALUES
                               (@idxRestrictedFunctionr
                               ,@varnamer
                               ,@descritpionr
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END

            IF NOT EXISTS (
        		SELECT [idrestrictedfunction]
        		FROM [dbo].[restrictedfunction]
        		WHERE variablename = @varnamew AND
        			 description = @descritpionw)
            BEGIN
                DECLARE @idxRestrictedFunctionw int = (SELECT isnull(MAX([idrestrictedfunction]),0) + 1 FROM [dbo].[restrictedfunction]);
                INSERT INTO [dbo].restrictedfunction
                               ([idrestrictedfunction]
                               ,[variablename]
                               ,[description],
							   [ct],[cu],[lt],[lu])
                         VALUES
                               (@idxRestrictedFunctionw
                               ,@varnamew
                               ,@descritpionw
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END
			--INSERIMENTO su tabella [restrictedfunction] --------------END

			--INSERIMENTO su tabella [securityvar] --------------BEGIN
            IF NOT EXISTS (
                SELECT [idsecurityvar]
                FROM [dbo].[securityvar]
                WHERE  variablename = @varnamer AND
                        description = @descritpionr)
            BEGIN
                DECLARE @idxSecurityvarr int = (SELECT isnull(MAX([idsecurityvar]),0) + 1 FROM [dbo].[securityvar]);

                INSERT INTO [dbo].securityvar
                               ([idsecurityvar]
                               ,[variablename]
                               ,[description]
                               ,[value]
							   ,[kind]
							   ,[ct],[cu],[lt],[lu])
                         VALUES
                               (@idxSecurityvarr
                               ,@varnamer
                               ,@descritpionr
                               ,'compute_set'
							   ,'S'
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END

            IF NOT EXISTS (
                SELECT [idsecurityvar]
                FROM [dbo].[securityvar]
                WHERE  variablename = @varnamew AND
                        description = @descritpionw)
            BEGIN
                DECLARE @idxSecurityvarw int = (SELECT isnull(MAX([idsecurityvar]),0) + 1 FROM [dbo].[securityvar]);

                INSERT INTO [dbo].securityvar
                               ([idsecurityvar]
                               ,[variablename]
                               ,[description]
                               ,[value]
							   ,[kind]
							   ,[ct],[cu],[lt],[lu])
                         VALUES
                               (@idxSecurityvarw
                               ,@varnamew
                               ,@descritpionw
                               ,'compute_set'
							   ,'S'
							   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
            END
			--INSERIMENTO su tabella [securityvar] --------------END

			--INSERIMENTO su tabella [customgroupoperation] --------------BEGN
			
			IF NOT EXISTS (
					SELECT *
					FROM [dbo].[customgroupoperation]
					WHERE  [idgroup] = 'ORGANIGRAMMA' 
					AND tablename = @tableName)
			BEGIN

				INSERT INTO [dbo].[customgroupoperation]
							   ([idgroup]
							   ,[operation]
							   ,[tablename]
							   ,[allowcondition]
							   ,[ct]
							   ,[cu]
							   ,[defaultisdeny]
							   ,[denycondition]
							   ,[lastmodtimestamp]
							   ,[lastmoduser]
							   ,[lt]
							   ,[lu])
				VALUES
							   ('ORGANIGRAMMA'
							   ,'I'
							   ,@tableName
							   ,'(<%usr[' + @varnamew + ']%> = ''S'')'
							   ,CURRENT_TIMESTAMP
							   ,'assistenza'
							   ,'S'
							   ,null
							   ,null
							   ,null
							   ,CURRENT_TIMESTAMP
							   ,'assistenza')

				INSERT INTO [dbo].[customgroupoperation]
							   ([idgroup]
							   ,[operation]
							   ,[tablename]
							   ,[allowcondition]
							   ,[ct]
							   ,[cu]
							   ,[defaultisdeny]
							   ,[denycondition]
							   ,[lastmodtimestamp]
							   ,[lastmoduser]
							   ,[lt]
							   ,[lu])
				VALUES
							   ('ORGANIGRAMMA'
							   ,'U'
							   ,@tableName
							   ,'(<%usr[' + @varnamew + ']%> = ''S'')'
							   ,CURRENT_TIMESTAMP
							   ,'assistenza'
							   ,'S'
							   ,null
							   ,null
							   ,null
							   ,CURRENT_TIMESTAMP
							   ,'assistenza')

				INSERT INTO [dbo].[customgroupoperation]
							   ([idgroup]
							   ,[operation]
							   ,[tablename]
							   ,[allowcondition]
							   ,[ct]
							   ,[cu]
							   ,[defaultisdeny]
							   ,[denycondition]
							   ,[lastmodtimestamp]
							   ,[lastmoduser]
							   ,[lt]
							   ,[lu])
				VALUES
							   ('ORGANIGRAMMA'
							   ,'D'
							   ,@tableName
							   ,'(<%usr[' + @varnamew + ']%> = ''S'')'
							   ,CURRENT_TIMESTAMP
							   ,'assistenza'
							   ,'S'
							   ,null
							   ,null
							   ,null
							   ,CURRENT_TIMESTAMP
							   ,'assistenza')
			END
			--INSERIMENTO su tabella [customgroupoperation] --------------END

		END
		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SU TABELLA --------------END

		ELSE

		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SEMPLICE--------------BEGIN
		BEGIN

			--INSERIMENTO su tabella restrictedfunction  --------------BEGIN
			IF NOT EXISTS (
        			SELECT [idrestrictedfunction]
        			FROM [dbo].[restrictedfunction]
        			WHERE variablename = @varnamer AND
        				 description = @descritpion)
			BEGIN

				DECLARE @idxRestrictedFunction int = (SELECT isnull(MAX([idrestrictedfunction]),0) + 1 FROM [dbo].[restrictedfunction]);

				INSERT INTO [dbo].restrictedfunction
								   ([idrestrictedfunction]
								   ,[variablename]
								   ,[description],
								   [ct],[cu],[lt],[lu])
							 VALUES
								   (@idxRestrictedFunction
								   ,@varnamer
								   ,@descritpion
								   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
			END
			--INSERIMENTO su tabella [restrictedfunction] --------------END

			--INSERIMENTO su tabella [securityvar] --------------BEGIN
			IF NOT EXISTS (
					SELECT [idsecurityvar]
					FROM [dbo].[securityvar]
					WHERE  variablename = @varnamer AND
							description = @descritpion)
			BEGIN

				DECLARE @idxSecurityvar int = (SELECT isnull(MAX([idsecurityvar]),0) + 1 FROM [dbo].[securityvar]);

				INSERT INTO [dbo].securityvar
								   ([idsecurityvar]
								   ,[variablename]
								   ,[description]
								   ,[value]
								   ,[kind]
								   ,[ct],[cu],[lt],[lu])
				VALUES
								   (@idxSecurityvar
								   ,@varnamer
								   ,@descritpion
								   ,'compute_set'
								   ,'S'
								   ,CURRENT_TIMESTAMP ,'assistenza',CURRENT_TIMESTAMP ,'assistenza');
			END
			--INSERIMENTO su tabella [securityvar] --------------BEGIN

		END
		--INSERIMENTO NELLE VARIABILI D'AMBIENTE PER VOCE MENU' SEMPLICE--------------END

    END
    --INSERIMENTO NELLE VARIABILI D'AMBIENTE --------------END


	RETURN @idx;

END
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[GenerateUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GenerateUser]
GO

CREATE PROCEDURE [dbo].[GenerateUser]
        @login varchar(60),
        @password varchar(100),
        @db varchar(100),
		@executor varchar(60),				-- utente che sta eseguento la procedura (per il log)
		@dipartimento varchar(60),
		@passwordalpha varchar(1024),		-- metaeasylibrary.Easy_DataAccess.getAlfaFromPassword(string userPassword)
		@passwordweb varchar(1024),			-- fc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations)
		@iterweb int,
		@saltweb varchar(50),
		@surname varchar(50),
		@forename varchar(49),
		@cf varchar(16),
		@email varchar(1024),
		@codeflowchart varchar(50) = NULL,	-- codice della voce dell'organigramma in cui inserire lutente
		@esercizio int = NULL,				-- esercizio dell'organigramma
		@usertype varchar(50), 				-- studenti, docenti, amministrativi 
		@matricola varchar(50) = NULL
AS
BEGIN

	declare @safe_login varchar(200);
	declare @safe_password varchar(200);
	declare @safe_db varchar(200);
	set @safe_login = replace(@login,'''', '''''');
	set @safe_password = replace(@password,'''', '''''');
	set @safe_db = replace(@db,'''', '''''');
	declare @sql nvarchar(max);
	declare @outmsg nvarchar(max) = '';

---------------------Utente SQL

IF NOT EXISTS (select loginname from master.dbo.syslogins where hasaccess = 1 and isntgroup=0 and loginname = @login)
BEGIN

	set @sql = --'use ' + @safe_db + ';' +
			   'create login [' + @safe_login + '] with password = ''' + @safe_password + ''', DEFAULT_DATABASE = ' + @safe_db + ', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF; ' --+
			   --'create user DEV' + @safe_login + ' from login ' + @safe_login + ';'
	exec (@sql)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'La login SQL esisteva già; ';
END


IF NOT EXISTS (select * from dbo.dbaccess where iddbdepartment = @dipartimento and [login] = @safe_login)
BEGIN

	exec sp_grantdbaccess @safe_login ,@safe_login;

	set @sql = 'exec sp_addrolemember  N''db_denydatawriter'', [' + @safe_login + '];
	GRANT  SELECT  ON [dbo].[dbaccess] TO [' + @safe_login + '];
	GRANT  SELECT  ON [' + @dipartimento + '].[customobject] TO [' + @safe_login + '];
	GRANT  SELECT  ON [' + @dipartimento + '].[columntypes] TO [' + @safe_login + '];'
	exec (@sql)

	INSERT [dbo].[dbaccess] ([alpha1], [iddbdepartment], [login], [lt], [lu], [pwdlastmod], [pwdmaxage], [pwdwarning]) 
	VALUES (@passwordalpha, @dipartimento, @safe_login, CURRENT_TIMESTAMP, @executor, NULL, NULL, NULL)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in dbaccess esisteva già; ';
END


IF NOT EXISTS (select * from [dbo].[dbuser] where [login] = @safe_login)
BEGIN
	INSERT INTO [dbo].[dbuser] ([forename],[initpwd] ,[login],[lt],[lu],[start],[stop],[surname]) 
	VALUES (@forename , null, @safe_login, CURRENT_TIMESTAMP, @executor ,CURRENT_TIMESTAMP, null, @surname)
END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in dbuser esisteva già; ';
END

-----------------Utente

--utente
IF NOT EXISTS (select * from [dbo].[customuser] where [username] = @safe_login)
BEGIN
	INSERT [dbo].[customuser] ([idcustomuser], [ct], [cu], [lastmodtimestamp], [lastmoduser], [lt], [lu], [username]) 
	VALUES (@safe_login, CURRENT_TIMESTAMP, @executor, NULL, NULL, CURRENT_TIMESTAMP, @executor, @safe_login)
END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in customuser esisteva già; ';
END

--utente virtuale (serve a collegare un utente all'utente effettivo a cui sono agganciati i diritti)
IF NOT EXISTS (select * from [dbo].[virtualuser] where [username] = @safe_login)
BEGIN

	DECLARE @idvirtualuser int = (SELECT isnull(MAX([idvirtualuser]),0) + 1 FROM [dbo].[virtualuser]);

	INSERT [dbo].[virtualuser] ([idvirtualuser], [birthdate], [cf], [forename], [codicedipartimento], [lt], [lu], [surname], [sys_user], [userkind], [username], [email]) 
	VALUES (@idvirtualuser, NULL, @cf, @forename, @dipartimento, NULL, NULL, @surname, @safe_login, 3, @safe_login, @email);

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in virtualuser esisteva già; ';
END


--associo l'utente al gruppo principale di diritti
IF NOT EXISTS (select * from [dbo].[customusergroup] where [idcustomuser] = @safe_login)
BEGIN
	INSERT INTO [dbo].[customusergroup] ([idcustomgroup], [idcustomuser], [ct], [cu], [lastmodtimestamp], [lastmoduser], [lt], [lu])
	VALUES ('ORGANIGRAMMA', @safe_login, CURRENT_TIMESTAMP, @executor, CURRENT_TIMESTAMP, @executor, CURRENT_TIMESTAMP, @executor);
END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in customusergroup esisteva già; ';
END

-----------------Utente organigramma e variabili di sicurezza

IF (@codeflowchart IS NOT NULL AND @esercizio IS NOT NULL)
BEGIN 
	
	DECLARE @idflowchart varchar(34) = (SELECT idflowchart FROM [amministrazione].[flowchart] where codeflowchart = @codeflowchart and ayear = @esercizio);

	--associo l'utente alla voce dell'organigramma
	IF NOT EXISTS (select * from [amministrazione].[flowchartuser] where [idcustomuser] = @safe_login and [idflowchart] = @idflowchart)
	BEGIN
		
		INSERT [amministrazione].[flowchartuser] ([idflowchart], [ndetail], [idcustomuser], [ct], [cu], [flagdefault], [lt], [lu], [start], [stop], [all_sorkind01], [all_sorkind02], [all_sorkind03], [all_sorkind04], [all_sorkind05], [idsor01], [idsor02], [idsor03], [idsor04], [idsor05], [sorkind01_withchilds], [sorkind02_withchilds], [sorkind03_withchilds], [sorkind04_withchilds], [sorkind05_withchilds], [title]) 
		VALUES (@idflowchart, 1, @safe_login, CURRENT_TIMESTAMP, @executor, N'N', CURRENT_TIMESTAMP, @executor, CAST(N'1900-01-01' AS Date), NULL, N'N', N'S', N'S', N'S', N'S', NULL, NULL, NULL, NULL, NULL, N'N', N'S', N'S', N'S', N'S', NULL);
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in flowchartuser esisteva già; ';
	END



	--associo l'utente alle variabili di sicurezza che sono associate alla sua voce dell'organigramma
	DECLARE @uecount int = (select count([variablename]) from [amministrazione].[userenvironment] where [idcustomuser] = @safe_login);

	INSERT INTO [amministrazione].[userenvironment] ([idcustomuser], [variablename], [flagadmin], [kind], [lt], [lu], [value]) 
	SELECT  @safe_login, (	select top 1 sv.variablename 
							from [restrictedfunction] sv
							where sv.idrestrictedfunction = fcrf.idrestrictedfunction)
			, N'N', N'S', CURRENT_TIMESTAMP, @executor, N'compute_set' 
	FROM amministrazione.[FlowChartrestrictedfunction] fcrf
	WHERE idflowchart =  @idflowchart AND NOT EXISTS(select * 
													from [amministrazione].[userenvironment] ue
													where ue.[idcustomuser] =  @safe_login AND ue.variablename = (	select top 1 sv2.variablename 
																											from [restrictedfunction] sv2
																											where sv2.idrestrictedfunction = fcrf.idrestrictedfunction));
	
	SET @outmsg = @outmsg + 'Inserite in userenvironment ' + cast( (select  count([variablename]) - @uecount from [amministrazione].[userenvironment] where [idcustomuser] = @safe_login) as nvarchar(10)) + ' variabili; '
END

-------------------anagrafica dell'utente

	DECLARE @idreg int = (SELECT isnull(MAX([idreg]),0) + 1 FROM [dbo].[registry]);

IF NOT EXISTS (select * from registry where cf = @cf)
BEGIN

	DECLARE @datanascita date = (SELECT cast('19' + SUBSTRING(@cf,7,2) +
		CASE
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'A' THEN '01'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'E' THEN '05'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'P' THEN '09'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'B' THEN '02'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'H' THEN '06'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'R' THEN '10'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'C' THEN '03'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'L' THEN '07'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'S' THEN '11'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'D' THEN '04'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'M' THEN '08'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'T' THEN '12'
		END +
		CASE 
		WHEN LEN(cast(CASE 
						WHEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) < 35
						THEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int)
						ELSE (cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) -40) END as nvarchar(255))) =1
		THEN '0' + cast(CASE 
						WHEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) < 35
						THEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int)
						ELSE (cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) -40) END as nvarchar(255))
		ELSE cast(CASE 
					WHEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) < 35
					THEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int)
					ELSE (cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) -40) END as nvarchar(255))
					END as date));

	DECLARE @comunenascita int = (select idcity FROM [dbo].[geo_city_agency] where [value] = SUBSTRING (@cf,12,4) );

	DECLARE @gender char(1) = (CASE WHEN CAST(SUBSTRING (@cf,10,2) as int) > 40 THEN 'F' ELSE 'M' END);

	--anagrafica generale
	INSERT [dbo].[registry] ([idreg], [active], [annotation], [badgecode], [birthdate], [cf], [ct], [cu], [extmatricula], [foreigncf], [forename], [gender], [idcategory], [idcentralizedcategory], [idcity], [idmaritalstatus], [idnation], [idregistryclass], [idtitle], [location], [lt], [lu], [maritalsurname], [p_iva], [rtf], [surname], [title], [txt], [residence], [idregistrykind], [authorization_free], [multi_cf], [toredirect], [idaccmotivecredit], [idaccmotivedebit], [ccp], [flagbankitaliaproceeds], [idexternal], [ipa_fe], [flag_pa], [sdi_defrifamm], [sdi_norifamm], [email_fe], [pec_fe], [extension], [ipa_perlapa]) 
	VALUES (@idreg, N'S', NULL, NULL, @datanascita, @cf, CURRENT_TIMESTAMP, @executor, @matricola, NULL, @forename, @gender, NULL, NULL, @comunenascita, NULL, NULL, N'22', NULL, NULL, CURRENT_TIMESTAMP, @executor, NULL, NULL, NULL, @surname, @surname + ' ' + @forename, NULL, 1, 5, N'N', N'N', NULL, NULL, NULL, NULL, N'N', NULL, NULL, N'N', NULL, N'N', @email, NULL, @usertype, NULL)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in registry esisteva già; ';
	SET @idreg = (select top(1) idreg from registry where cf = @cf)
END 



	--credenziali web e email
IF NOT EXISTS (select * from [registryreference] where [userweb] = @safe_login AND idreg = @idreg)
BEGIN
	
	DECLARE @idregistryreference int = (SELECT isnull(MAX([idregistryreference]),0) + 1 FROM [dbo].[registryreference]);

	INSERT [dbo].[registryreference] ([referencename], [idreg], [ct], [cu], [email], [faxnumber], [flagdefault], [lt], [lu], [mobilenumber], [passwordweb], [phonenumber], [registryreferencerole], [rtf], [txt], [userweb], [idregistryreference], [msnnumber], [skypenumber], [activeweb], [iterweb], [saltweb], [pec], [website]) VALUES (N'Residenza', @idreg, CURRENT_TIMESTAMP, @executor, @email, NULL, N'S', CURRENT_TIMESTAMP, @executor, NULL, @passwordweb, NULL, NULL, NULL, NULL, @safe_login, @idregistryreference, NULL, NULL, NULL, @iterweb, @saltweb, NULL, NULL)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in registryreference esisteva già; ';
END 

IF(@usertype = 'studenti')
BEGIN

	IF NOT EXISTS (select * from [registry_studenti] where idreg = @idreg)
	BEGIN

		INSERT INTO [dbo].[registry_studenti]
				   ([idreg]
				   ,[authinps]
				   ,[ct]
				   ,[cu]
				   ,[idstuddirittokind]
				   ,[idstudprenotkind]
				   ,[lt]
				   ,[lu])
			 VALUES
				   (@idreg
				   ,'N'
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,null
				   ,0
				   ,CURRENT_TIMESTAMP
				   ,@executor)
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in registry_studenti esisteva già; ';
	END 

END

IF(@usertype = 'docenti')
BEGIN

	IF NOT EXISTS (select * from [registry_docenti] where idreg = @idreg)
	BEGIN
		INSERT INTO [dbo].[registry_docenti]
				   ([idreg]
				   ,[ct]
				   ,[cu]
				   ,[cv]
				   ,[idclassconsorsuale]
				   ,[idcontrattokind]
				   ,[idfonteindicebibliometrico]
				   ,[idreg_istituti]
				   ,[idsasd]
				   ,[idstruttura]
				   ,[indicebibliometrico]
				   ,[lt]
				   ,[lu]
				   ,[matricola]
				   ,[ricevimento]
				   ,[soggiorno])
			 VALUES
				   (@idreg
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,''
				   ,null
				   ,null
				   ,null
				   ,null
				   ,null
				   ,null
				   ,null
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,@matricola
				   ,''
				   ,'')
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in registry_docenti esisteva già; ';
	END 

END

IF(@usertype = 'amministrativi')
BEGIN

	IF NOT EXISTS (select * from [registry_amministrativi] where idreg = @idreg)
	BEGIN
		INSERT INTO [dbo].[registry_amministrativi]
				   ([idreg]
				   ,[ct]
				   ,[cu]
				   ,[cv]
				   ,[idcontrattokind]
				   ,[lt]
				   ,[lu])
			 VALUES
				   (@idreg
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,''
				   ,null
				   ,CURRENT_TIMESTAMP
				   ,@executor)
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in registry_amministrativi esisteva già; ';
	END 
END

------------------
select @outmsg;
------------------

END
GO


--Query di verifica
--declare @user varchar(50) = 'UTENTE.TEST9'; -- 'monitor'--'912917'  --1983 prova progetti (tutto) --1997 funz amm progetti
--declare @esercizio int = 2021;
----select * from dbo.customgroupoperation  where allowcondition like '%mw_%' or allowcondition like '%mr_%'
--select 'dbo.customusergroup' as tablename,* from dbo.customusergroup where [idcustomuser]= @user --è ORGANIGRAMMA per tutti
--select 'amministrazione.userenvironment' as tablename,* from amministrazione.userenvironment where [idcustomuser]= @user order by variablename --variabili e utenti senza invìfluenza dell'esercizio
--select 'amministrazione.FlowChartrestrictedfunction ' as tablename,* from amministrazione.FlowChartrestrictedfunction where idflowchart in (select idflowchart from amministrazione.FlowChartUser where [idcustomuser]= @user and idflowchart in (select idflowchart from amministrazione.flowchart where ayear= @esercizio)) order by idflowchart--spunte tra in organigramma sulle singole varaibili
--select 'amministrazione.flowchart' as tablename,* from amministrazione.flowchart where idflowchart in (select idflowchart from amministrazione.FlowChartUser where [idcustomuser]= @user) and ayear= @esercizio;
--select 'amministrazione.FlowChartUser' as tablename,* from amministrazione.FlowChartUser where [idcustomuser]= @user and idflowchart in (select idflowchart from amministrazione.flowchart where ayear= @esercizio)
----select 'WebUser' as tablename,* from [WebUser] where [username]= @user
--select 'customuser' as tablename,* from [customuser] where [username]= @user
--select 'dbuser' as tablename,* from dbo.[dbuser] where [login]= @user
--select 'dbaccess' as tablename,* from [dbaccess] where [login]= @user
--select 'virtualuser' as tablename,* from virtualuser where username = @user or sys_user = @user
--select 'registryreference' as tablename,* from registryreference where userweb = @user
--select 'registry' as tablename,* from registry where idreg = (select top 1 idreg from registryreference where userweb = @user)
--select 'registry_docenti' as tablename,* from registry_docenti where idreg = (select top 1 idreg from registryreference where userweb = @user)
--select 'registry_studenti' as tablename,* from registry_studenti where idreg = (select top 1 idreg from registryreference where userweb = @user)
--select 'registry_amministrativi' as tablename,* from registry_amministrativi where idreg = (select top 1 idreg from registryreference where userweb = @user)

exec menuweb_addentry @idmenuwebparent = NULL, @idx = 1, @tableName = null, @editType = null, @label = 'Tutti i Menù';
exec menuweb_addentry @idmenuwebparent = 1, @idx = 29, @tableName = null, @editType = null, @label = 'Menù dell''applicazione delle segreterie';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 400, @tableName = null, @editType = null, @label = 'Amministrazione';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 81, @tableName = null, @editType = null, @label = 'Segreteria didattica';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 83, @tableName = null, @editType = null, @label = 'Segreteria amministrativa';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 296, @tableName = null, @editType = null, @label = 'Progetti di ricerca e attività istituzionali';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 41, @tableName = null, @editType = null, @label = 'Elenchi';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 143, @tableName = null, @editType = null, @label = 'Configurazioni';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 177, @tableName = null, @editType = null, @label = 'Tipologie';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 244, @tableName = null, @editType = null, @label = 'Definizione delle tasse';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 57, @tableName = 'sasd', @editType = 'default', @label = 'Settori artistico-scientifico disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 72, @tableName = 'classconsorsuale', @editType = 'default', @label = 'Classi di concorso MIUR';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 145, @tableName = 'ccnl', @editType = 'default', @label = 'Contratti Collettivi Nazionali del Lavoro';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 170, @tableName = 'areadidattica', @editType = 'default', @label = 'Aeree didattiche';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 178, @tableName = 'istattitolistudio', @editType = 'default', @label = 'Titoli di studio ISTAT';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 180, @tableName = 'classescuola', @editType = 'default', @label = 'Scuole / Classi di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 186, @tableName = 'upb', @editType = 'default', @label = 'Unità previsionali di base';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 191, @tableName = 'geo_nation', @editType = 'seg', @label = 'Nazioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 193, @tableName = 'geo_continent', @editType = 'default', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 194, @tableName = 'geo_country', @editType = 'seg', @label = 'Province';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 195, @tableName = 'geo_region', @editType = 'seg', @label = 'Regioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 196, @tableName = 'geo_city', @editType = 'seg', @label = 'Comuni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 197, @tableName = 'corsostudionorma', @editType = 'default', @label = 'Normativa dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 213, @tableName = 'corsostudiolivello', @editType = 'default', @label = 'Livelli dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 239, @tableName = 'geo_continent', @editType = 'anagrafica_easyweb', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 270, @tableName = 'pianostudiostatus', @editType = 'default', @label = 'Stati dei piani di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 278, @tableName = 'nace', @editType = 'default', @label = 'Classificazione delle attività economiche nella Comunità Europea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 279, @tableName = 'ateco', @editType = 'default', @label = 'Classificazione ATECO';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 292, @tableName = 'sasdgruppo', @editType = 'default', @label = 'Gruppo';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 293, @tableName = 'classescuolaarea', @editType = 'default', @label = 'Area della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 294, @tableName = 'classescuolakind', @editType = 'default', @label = 'Tipologia della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 295, @tableName = 'ambitoareadisc', @editType = 'default', @label = 'Ambiti o aree disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 302, @tableName = 'progettostatuskind', @editType = 'default', @label = 'Stati delle attività o progetti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 303, @tableName = 'settoreerc', @editType = 'seg', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 304, @tableName = 'fonteindicebibliometrico', @editType = 'seg', @label = 'Fonti degli indici bibliometrici';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 306, @tableName = 'settoreerc', @editType = 'segprog', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 307, @tableName = 'tax', @editType = 'seg', @label = 'Tipi di ritenuta';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 310, @tableName = 'changes', @editType = 'default', @label = 'Cambiamento per learning agreement';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 311, @tableName = 'changeskind', @editType = 'default', @label = 'Tipo di cambiamenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 344, @tableName = 'stipendiokind', @editType = 'default', @label = 'Tabelle stipendiali';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 346, @tableName = 'naturagiur', @editType = 'default', @label = 'Natura giuridica';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 347, @tableName = 'numerodip', @editType = 'default', @label = 'Numero dipendenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 348, @tableName = 'inventorytree', @editType = 'seg', @label = 'Classificazione inventariale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 353, @tableName = 'isced2013', @editType = 'default', @label = 'International Standard Classification of Education (ISCED)';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 354, @tableName = 'cefr', @editType = 'default', @label = 'Quadro europeo comune di riferimento per le lingue';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 357, @tableName = 'bandomobilitaintkind', @editType = 'default', @label = 'Tipologa del bando di mobilità internanzionale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 397, @tableName = 'currency', @editType = 'default', @label = 'Valute';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 82, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 179, @tableName = null, @editType = null, @label = 'Didattica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 45, @tableName = 'location', @editType = 'aula', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 77, @tableName = 'registry', @editType = 'anagrafica', @label = 'Anagrafica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 79, @tableName = 'registry', @editType = 'docenti', @label = 'Docenti';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 136, @tableName = 'publicaz', @editType = 'default', @label = 'Pubblicazioni';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 182, @tableName = 'insegn', @editType = 'default', @label = 'Insegnamenti';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 218, @tableName = 'aula', @editType = 'default', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 220, @tableName = 'edificio', @editType = 'default', @label = 'Edifici';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 84, @tableName = null, @editType = null, @label = 'Iscrizioni, rinnovi, conseguimenti e decadenze';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 86, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 280, @tableName = null, @editType = null, @label = 'Istanze e delibere';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 283, @tableName = null, @editType = null, @label = 'Protocollo';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 313, @tableName = null, @editType = null, @label = 'Tirocini';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 349, @tableName = null, @editType = null, @label = 'Mobilità internazionale';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 358, @tableName = null, @editType = null, @label = 'Diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 367, @tableName = null, @editType = null, @label = 'Dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 369, @tableName = null, @editType = null, @label = 'Contabilità studenti';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 274, @tableName = 'iscrizione', @editType = 'seg', @label = 'Iscrizioni';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 308, @tableName = 'decadenza', @editType = 'seg', @label = 'Decadenza';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 381, @tableName = 'sostenimento', @editType = 'segcons', @label = 'Conseguimento del titolo';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 42, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 51, @tableName = 'registry', @editType = 'aziende', @label = 'Enti e Aziende';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 52, @tableName = 'registry', @editType = 'istituti', @label = 'Istituti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 53, @tableName = 'registry', @editType = 'istitutiesteri', @label = 'Istituti esteri';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 174, @tableName = 'registry', @editType = 'studenti', @label = 'Studenti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 187, @tableName = 'aoo', @editType = 'default', @label = 'Aree organizzative omogenee';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 212, @tableName = 'sede', @editType = 'default', @label = 'Sedi';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 214, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 215, @tableName = 'struttura', @editType = 'default', @label = 'Struttura / Unità organizzativa';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 300, @tableName = 'registry', @editType = 'amministrativi', @label = 'Personale Amministrativo';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 146, @tableName = 'menuweb', @editType = 'tree', @label = 'Menù';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 233, @tableName = 'registry', @editType = 'user', @label = 'Pagina di registrazione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 241, @tableName = 'questionario', @editType = 'default', @label = 'Questionari';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 242, @tableName = 'graduatoriavar', @editType = 'default', @label = 'Variabili delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 243, @tableName = 'registry', @editType = 'istituti_princ', @label = 'Istituto in gestione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 277, @tableName = 'graduatoria', @editType = 'default', @label = 'Definizioni delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 135, @tableName = 'contrattokind', @editType = 'default', @label = 'Tipologie di contratto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 137, @tableName = 'publicazkind', @editType = 'default', @label = 'Tipologie di pubblicazione ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 139, @tableName = 'rendicontaltrokind', @editType = 'default', @label = 'Tipologia delle attività da rendicontare oltre le lezioni ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 141, @tableName = 'studdirittokind', @editType = 'default', @label = 'Categoria dello studente per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 142, @tableName = 'studprenotkind', @editType = 'default', @label = 'Tipologia di studente durante la prenotazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 171, @tableName = 'corsostudiokind', @editType = 'default', @label = 'Tipologie dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 172, @tableName = 'istitutokind', @editType = 'default', @label = 'Tipologia di istituto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 176, @tableName = 'registryclass', @editType = 'default', @label = 'Tipologia fiscale';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 183, @tableName = 'valutazionekind', @editType = 'default', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 211, @tableName = 'strutturakind', @editType = 'default', @label = 'Tipologia delle strutture';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 217, @tableName = 'tipoattform', @editType = 'default', @label = 'Tipologia delle attività formative';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 221, @tableName = 'valutazionekind', @editType = 'seg_child', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 223, @tableName = 'aulakind', @editType = 'default', @label = 'Tipologie delle aule';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 225, @tableName = 'affidamentokind', @editType = 'default', @label = 'Tipologie di affidamento';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 227, @tableName = 'erogazkind', @editType = 'default', @label = 'Tipologie di erogazione della didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 229, @tableName = 'sessionekind', @editType = 'default', @label = 'Tipologie di sessione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 230, @tableName = 'appellokind', @editType = 'default', @label = 'Tipologie di appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 263, @tableName = 'istanzakind', @editType = 'default', @label = 'Tipologie di istanza';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 264, @tableName = 'ofakind', @editType = 'default', @label = 'Titologie di obblighi formativi aggiuntivi';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 265, @tableName = 'questionariodomkind', @editType = 'default', @label = 'Tipologie di  domande del questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 266, @tableName = 'questionariokind', @editType = 'default', @label = 'Tipologie di questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 267, @tableName = 'tirociniocandidaturakind', @editType = 'default', @label = 'Tipologia di candidatura ad un tirocinio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 268, @tableName = 'tirociniostato', @editType = 'default', @label = 'Stato dei tirocini';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 269, @tableName = 'appelloazionekind', @editType = 'default', @label = 'Titologie di azione in appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 271, @tableName = 'sostenimentoesito', @editType = 'default', @label = 'Esito';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 290, @tableName = 'dichiarkind', @editType = 'default', @label = 'Tipi di dichiarazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 298, @tableName = 'orakind', @editType = 'seg', @label = 'Tipologia di ore';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 305, @tableName = 'progettoactivitykind', @editType = 'default', @label = 'Tipo di attività o progetto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 345, @tableName = 'duratakind', @editType = 'default', @label = 'Tipo di durata';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 365, @tableName = 'accreditokind', @editType = 'default', @label = 'Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 366, @tableName = 'convalidakind', @editType = 'default', @label = 'Tipologie di convalida';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 376, @tableName = 'dichiardisabilkind', @editType = 'default', @label = 'Tipologie di disabilità';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 377, @tableName = 'dichiardisabilsuppkind', @editType = 'default', @label = 'Tipologie dichiarazioni disabilita';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 382, @tableName = 'dichiaraltrekind', @editType = 'default', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 383, @tableName = 'dichiaraltrekind', @editType = 'elenchi', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 392, @tableName = 'bandodsiscresitokind', @editType = 'default', @label = 'Esito della partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 401, @tableName = 'progettoudrmembrokind', @editType = 'default', @label = 'Tipologia di membro delle unità di personale';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 181, @tableName = 'didprog', @editType = 'default', @label = 'Didattiche programmate';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 188, @tableName = 'corsostudio', @editType = 'default', @label = 'Corsi di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 219, @tableName = 'diderog', @editType = 'default', @label = 'Didattica Erogata';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 226, @tableName = 'appello', @editType = 'default', @label = 'Appelli';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 228, @tableName = 'sessione', @editType = 'default', @label = 'Sessioni di esami';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 232, @tableName = 'corsostudio', @editType = 'ingresso', @label = 'Prove di ammissione';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 272, @tableName = 'corsostudio', @editType = 'dotmas', @label = 'Master';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 273, @tableName = 'corsostudio', @editType = 'stato', @label = 'Esami di stato';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 276, @tableName = 'pianostudio', @editType = 'segstud', @label = 'Piani di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 312, @tableName = 'pratica', @editType = 'segstud', @label = 'Pratica di convalida/riconoscimento/dispensa';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 391, @tableName = 'getcostididattica', @editType = 'default', @label = 'Riepilogo dei costi degli affidamenti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 246, @tableName = 'costoscontodef', @editType = 'default', @label = 'Costi';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 247, @tableName = 'costoscontodef', @editType = 'sconti', @label = 'Sconti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 248, @tableName = 'costoscontodef', @editType = 'more', @label = 'Indennità / More';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 249, @tableName = 'costoscontodefdettagliokind', @editType = 'default', @label = 'Voci dei dettaglio debito';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 250, @tableName = 'esonero', @editType = 'default', @label = 'Definizione degli esoneri generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 251, @tableName = 'esonero', @editType = 'carriera', @label = 'Definizione degli esoneri  derivanti dalla carriera';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 252, @tableName = 'esonero', @editType = 'disabil', @label = 'Definizione degli esoneri di invalidità';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 253, @tableName = 'esonero', @editType = 'titolostudio', @label = 'Definizione degli esoneri per titoli di studio conseguiti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 254, @tableName = 'fasciaisee', @editType = 'default', @label = 'Fasce ISEE';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 255, @tableName = 'pagamentokind', @editType = 'default', @label = 'Tipologie di pagamento';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 256, @tableName = 'ratakind', @editType = 'default', @label = 'Rate';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 257, @tableName = 'tassaconf', @editType = 'default', @label = 'Definizione dei costi generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 258, @tableName = 'tassaconfkind', @editType = 'default', @label = 'Definizione delle tasse generiche';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 259, @tableName = 'tassacsingconf', @editType = 'default', @label = 'Definizione dei costi dei corsi singoli';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 260, @tableName = 'tassaiscrizioneconf', @editType = 'default', @label = 'Definizione delle tasse di iscrizione';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 261, @tableName = 'tassaistanzaconf', @editType = 'default', @label = 'Definizione dei costi delle istanze';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 262, @tableName = 'costoscontodefkind', @editType = 'default', @label = 'Tipologia tra Costo, Sconto, Mora, indennizzo';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 287, @tableName = 'istanza', @editType = 'imm_segpre', @label = 'Istanze di preimmatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 288, @tableName = 'istanza', @editType = 'imm_seg', @label = 'Istanze di immatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 289, @tableName = 'istanza', @editType = 'imm_segrin', @label = 'Istanze di rinnovo della iscrizione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 385, @tableName = 'istanza', @editType = 'rin_seg', @label = 'Istanza di rinuncia agli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 386, @tableName = 'istanza', @editType = 'tru_seg', @label = 'Istanza di trasferimento in uscita';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 387, @tableName = 'istanza', @editType = 'eq_seg', @label = 'Istanza di equipollenza ';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 388, @tableName = 'istanza', @editType = 'cert_seg', @label = 'Richiesta di certificato';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 389, @tableName = 'istanza', @editType = 'sosp_seg', @label = 'Istanza di sospensione degli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 390, @tableName = 'delibera', @editType = 'seg', @label = 'Delibere';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 284, @tableName = 'protocollo', @editType = 'seg', @label = 'Registrazioni di protocollo';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 285, @tableName = 'protocollodockind', @editType = 'seg', @label = 'Tipo di documento protocollato';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 286, @tableName = 'protocollorifkind', @editType = 'seg', @label = 'Tipo di documento di riferimento';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 297, @tableName = 'progetto', @editType = 'seg', @label = 'Progetti e attività';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipo di progetto o attività';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 342, @tableName = 'convenzione', @editType = 'seg', @label = 'Convenzioni';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 343, @tableName = 'tirocinioproposto', @editType = 'seg', @label = 'Proposte di tirocinio';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 350, @tableName = 'programmami', @editType = 'seg', @label = 'Programmi di cooperazione';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 351, @tableName = 'accordoscambiomi', @editType = 'seg', @label = 'Accordi bilaterali';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 352, @tableName = 'bandomi', @editType = 'seg', @label = 'Bandi di mobilità';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 356, @tableName = 'assicurazione', @editType = 'default', @label = 'Assicurazione';
exec menuweb_addentry @idmenuwebparent = 358, @idx = 359, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 359, @idx = 360, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 371, @tableName = 'dichiar', @editType = 'altrititoli_seg', @label = 'Altri titoli';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 378, @tableName = 'dichiar', @editType = 'altre_seg', @label = 'Altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 379, @tableName = 'dichiar', @editType = 'disabil_seg', @label = 'Dichiarazione di disabilità';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 380, @tableName = 'dichiar', @editType = 'isee_seg', @label = 'Attestazione ISEE';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 384, @tableName = 'dichiar', @editType = 'titolo_seg', @label = 'Dichiarazione titoli di studio';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 405, @tableName = 'registry', @editType = 'admin', @label = 'Funzioni di amministrazione';
--docenti
exec menuweb_addentry @idmenuwebparent = 29, @idx = 415, @tableName = null, @editType = null, @label = 'I miei dati';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 416, @tableName = null, @editType = null, @label = 'I miei corsi';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 421, @tableName = null, @editType = null, @label = 'Le mie attività di ricerca e istituzionali';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 417, @tableName = 'assetdiary', @editType = 'doc', @label = 'Diari di utilizzo di beni strumentali';
exec menuweb_addentry @idmenuwebparent = 416, @idx = 418, @tableName = 'affidamento', @editType = 'doc', @label = 'Affidamento';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 419, @tableName = 'rendicontattivitaprogetto', @editType = 'doc', @label = 'Attività di ricerca';
exec menuweb_addentry @idmenuwebparent = 415, @idx = 420, @tableName = 'registry', @editType = 'docenti_doc', @label = 'Dati personali';
--amministrativi
exec menuweb_addentry @idmenuwebparent = 415, @idx = 422, @tableName = 'registry', @editType = 'amministrativi_personale', @label = 'Dati personali';
--menu




IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202199')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202199'
           ,null
           ,2021
           ,null
           ,'SEGADM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'21'
           ,null
           ,1
           ,'Segreterie Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202198')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202198'
           ,null
           ,2021
           ,null
           ,'SEGPRG'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'21'
           ,null
           ,1
           ,'Segreterie Progetti Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202196')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202196'
           ,null
           ,2021
           ,null
           ,'SEGDOC'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'21'
           ,null
           ,1
           ,'Docenti'
           ,null
           ,null
           ,null)
GO


IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202195')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202195'
           ,null
           ,2021
           ,null
           ,'SEGAMM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'21'
           ,null
           ,1
           ,'Personale amministrativo'
           ,null
           ,null
           ,null)
GO

--diritti Docenti

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202196'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mr_415'  --menu
,'mr_416'
,'mr_421'
,'mr_417' --interfacce
,'mr_418'
,'mr_419'
,'mr_420'
,'mw_417'
,'mw_418'
,'mw_419'
--,'mw_420' --non può modificare i suoi dati
,'all_upb' --elenchi
,'all_man'
,'cespiti_read'
,'missioni'
,'anagrafica_read'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202196' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)

--diritti Personale amministrativo

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202195'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mr_415'  --menu
,'mr_421'
,'mr_417' --interfacce
,'mr_419'
,'mr_422'
,'mw_417'
,'mw_419'
--,'mw_422' --non può modificare i suoi dati
,'all_upb' --elenchi
,'all_man'
,'cespiti_read'
,'missioni'
,'anagrafica_read'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202195' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diritti Amministratori segreterie

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202199'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mandato'
,'reversale'
,'compensi'
,'bilancio'
,'upb'
,'spesa'
,'entrata'
,'ordine'
,'trasmissione'
,'esitazione'
,'fondoec'
,'annullamento'
,'cespiti'
,'iva'
,'anag_c'
,'anag_l'
,'econopatr'
,'liquidazione'
,'stampe'
,'classificazione'
,'contrattivo'
,'impegni'
,'accertamenti'
,'ordinegrande'
,'organigramma'
,'management'
,'dichiarazione'
,'imposta'
,'configurazione'
,'anagrafeprestazioni'
,'consolidamento'
,'man_ufficiale'
,'rev_ufficiale'
,'multiprint'
,'banca'
,'crediti'
,'incassi'
,'coana'
,'contcompensi'
,'contiva'
,'contcontratti'
,'previsione'
,'assestamento'
,'list_man'
,'responsabile'
,'contrattivogrande'
,'list_mfin'
,'list_mupb'
,'menu'
,'anagrafica'
,'sel_cp'
,'sel_ca'
,'bilancio_read'
,'anagrafica_read'
,'spesa_read'
,'entrata_read'
,'trasmissione_read'
,'fondoec_read'
,'adm_localconfig'
,'adm_backup'
,'adm_ondemand'
,'adm_menuupdate'
,'varspesa'
,'varentrata'
,'tax_clawback'
,'endofyear_entry'
,'all_fin'
,'all_upb'
,'all_man'
,'all_mandatekind'
,'all_estimatekind'
,'all_invoicekind'
,'all_pettycash'
,'list_estimatekind'
,'list_invoicekind'
,'list_pettycash'
,'list_mandatekind'
,'fattura'
,'del_invoice'
,'cespiti_read'
,'liquidazioneiva'
,'anag_d'
,'classificazione_mod'
,'anag_dis'
,'chiusura'
,'anag_config'
,'anag_procedure'
,'adm_magazzino'
,'ric_magazzino'
,'config_magazzino'
,'pre_accertamenti'
,'post_accertamenti'
,'pre_impegni'
,'post_impegni'
,'dipendenti'
,'missioni'
,'occasionali'
,'cococo'
,'professionali'
,'stipendi'
,'eco_entry'
,'all_authmodel'
,'list_authmodel'
,'crea_card'
,'admin_card'
,'var_bilancio'
,'asspendenti'
,'movimprotetta'
,'saldicassa'
,'finvarapproved'
,'manage_estimatekind'
,'manage_mandatekind'
,'manage_invoicekind'
,'storniapprove'
,'sitfinanziaria_read'
,'finanziamenti'
,'trasmissione_ap'
,'edit_limit'
,'stornimedesimocapitoloapprove'
,'finvarcredit'
,'sel_fatture'
,'trasmissione_abilita'
,'certificazionecrediti'
,'fe_ipa_rifamm'
,'fe_ipa'
,'fe_all'
,'manage_split_payment'
,'accetta_fe'
,'rifiuta_fe'
,'creaincontabilita_fe'
,'cambia_rifamm'
,'tipologiaincarichi_ap'
,'var_budget'
,'storno_budget'
,'storno_budget_approve'
,'var_budget_approve'
,'edit_epexpresidui'
,'flussostudenti'
,'flussomovimenti'
,'config_bil_sottosezionali'
,'mov_protettecomp'
,'ct_stornocompetenzaclass'
,'pat'
,'UPBsecurity'
,'edit_epaccresidui'
,'flag_escludidacu'
,'notcreacontabilita'
,'flag_authorizationfree'
,'config_stipendi'
,'stipendi_ct'
,'conf_classauto'
,'upd_paymentcompetency'
,'config_account'
,'mw_40'
,'mr_1'
,'mr_29'
,'mr_400'
,'mr_81'
,'mr_83'
,'mr_296'
,'mr_41'
,'mr_143'
,'mr_177'
,'mr_244'
,'mr_57'
,'mw_57'
,'mr_72'
,'mw_72'
,'mr_145'
,'mw_145'
,'mr_170'
,'mw_170'
,'mr_178'
,'mw_178'
,'mr_180'
,'mw_180'
,'mr_186'
,'mw_186'
,'mr_191'
,'mw_191'
,'mr_193'
,'mw_193'
,'mr_194'
,'mw_194'
,'mr_195'
,'mw_195'
,'mr_196'
,'mw_196'
,'mr_197'
,'mw_197'
,'mr_213'
,'mw_213'
,'mr_239'
,'mw_239'
,'mr_270'
,'mw_270'
,'mr_278'
,'mw_278'
,'mr_279'
,'mw_279'
,'mr_292'
,'mw_292'
,'mr_293'
,'mw_293'
,'mr_294'
,'mw_294'
,'mr_295'
,'mw_295'
,'mr_302'
,'mw_302'
,'mr_303'
,'mw_303'
,'mr_304'
,'mw_304'
,'mr_306'
,'mw_306'
,'mr_307'
,'mw_307'
,'mr_310'
,'mw_310'
,'mr_311'
,'mw_311'
,'mr_344'
,'mw_344'
,'mr_346'
,'mw_346'
,'mr_347'
,'mw_347'
,'mr_348'
,'mw_348'
,'mr_353'
,'mw_353'
,'mr_354'
,'mw_354'
,'mr_357'
,'mw_357'
,'mr_397'
,'mw_397'
,'mr_82'
,'mr_179'
,'mr_45'
,'mw_45'
,'mr_77'
,'mw_77'
,'mr_79'
,'mw_79'
,'mr_136'
,'mw_136'
,'mr_182'
,'mw_182'
,'mr_218'
,'mw_218'
,'mr_220'
,'mw_220'
,'mr_84'
,'mr_86'
,'mr_280'
,'mr_283'
,'mr_313'
,'mr_349'
,'mr_358'
,'mr_367'
,'mr_369'
,'mr_274'
,'mw_274'
,'mr_308'
,'mw_308'
,'mr_381'
,'mw_381'
,'mr_42'
,'mw_42'
,'mr_51'
,'mw_51'
,'mr_52'
,'mw_52'
,'mr_53'
,'mw_53'
,'mr_174'
,'mw_174'
,'mr_187'
,'mw_187'
,'mr_212'
,'mw_212'
,'mr_215'
,'mw_215'
,'mr_300'
,'mw_300'
,'mr_146'
,'mw_146'
,'mr_233'
,'mw_233'
,'mr_241'
,'mw_241'
,'mr_242'
,'mw_242'
,'mr_243'
,'mw_243'
,'mr_277'
,'mw_277'
,'mr_135'
,'mw_135'
,'mr_137'
,'mw_137'
,'mr_139'
,'mw_139'
,'mr_141'
,'mw_141'
,'mr_142'
,'mw_142'
,'mr_171'
,'mw_171'
,'mr_172'
,'mw_172'
,'mr_176'
,'mw_176'
,'mr_183'
,'mw_183'
,'mr_211'
,'mw_211'
,'mr_217'
,'mw_217'
,'mr_221'
,'mw_221'
,'mr_223'
,'mw_223'
,'mr_225'
,'mw_225'
,'mr_227'
,'mw_227'
,'mr_229'
,'mw_229'
,'mr_230'
,'mw_230'
,'mr_263'
,'mw_263'
,'mr_264'
,'mw_264'
,'mr_265'
,'mw_265'
,'mr_266'
,'mw_266'
,'mr_267'
,'mw_267'
,'mr_268'
,'mw_268'
,'mr_269'
,'mw_269'
,'mr_271'
,'mw_271'
,'mr_290'
,'mw_290'
,'mr_298'
,'mw_298'
,'mr_305'
,'mw_305'
,'mr_345'
,'mw_345'
,'mr_365'
,'mw_365'
,'mr_366'
,'mw_366'
,'mr_376'
,'mw_376'
,'mr_377'
,'mw_377'
,'mr_382'
,'mw_382'
,'mr_383'
,'mw_383'
,'mr_392'
,'mw_392'
,'mr_401'
,'mw_401'
,'mr_181'
,'mw_181'
,'mr_188'
,'mw_188'
,'mr_219'
,'mw_219'
,'mr_226'
,'mw_226'
,'mr_228'
,'mw_228'
,'mr_232'
,'mw_232'
,'mr_272'
,'mw_272'
,'mr_273'
,'mw_273'
,'mr_276'
,'mw_276'
,'mr_312'
,'mw_312'
,'mr_391'
,'mw_391'
,'mr_246'
,'mw_246'
,'mr_247'
,'mw_247'
,'mr_248'
,'mw_248'
,'mr_249'
,'mw_249'
,'mr_250'
,'mw_250'
,'mr_251'
,'mw_251'
,'mr_252'
,'mw_252'
,'mr_253'
,'mw_253'
,'mr_254'
,'mw_254'
,'mr_255'
,'mw_255'
,'mr_256'
,'mw_256'
,'mr_257'
,'mw_257'
,'mr_258'
,'mw_258'
,'mr_259'
,'mw_259'
,'mr_260'
,'mw_260'
,'mr_261'
,'mw_261'
,'mr_262'
,'mw_262'
,'mr_287'
,'mw_287'
,'mr_288'
,'mw_288'
,'mr_289'
,'mw_289'
,'mr_385'
,'mw_385'
,'mr_386'
,'mw_386'
,'mr_387'
,'mw_387'
,'mr_388'
,'mw_388'
,'mr_389'
,'mw_389'
,'mr_390'
,'mw_390'
,'mr_284'
,'mw_284'
,'mr_285'
,'mw_285'
,'mr_286'
,'mw_286'
,'mr_297'
,'mw_297'
,'mr_299'
,'mw_299'
,'mr_342'
,'mw_342'
,'mr_343'
,'mw_343'
,'mr_350'
,'mw_350'
,'mr_351'
,'mw_351'
,'mr_352'
,'mw_352'
,'mr_356'
,'mw_356'
,'mr_359'
,'mw_359'
,'mr_360'
,'mw_360'
,'mr_371'
,'mw_371'
,'mr_378'
,'mw_378'
,'mr_379'
,'mw_379'
,'mr_380'
,'mw_380'
,'mr_384'
,'mw_384'
,'mr_402'
,'mw_402'
,'mr_403'
,'mw_403'
,'mr_404'
,'mw_404'
,'mr_405'
,'mw_405'

,'mr_417' --interfacce docenti e amministrativi
,'mr_418'
,'mr_419'
,'mw_417'
,'mw_418'
,'mw_419'

)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202199' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diriti Amministratori progetti
INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202198'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'anag_config',
'anagrafica',
'anagrafica_read',
'all_upb',
'all_man',
'missioni',
'cespiti_read',
'mr_135',
'mr_136',
'mr_137',
'mr_143',
'mr_176',
'mr_177',
'mr_179',
'mr_211',
'mr_212',
'mr_215',
'mr_272',
'mr_283',
'mr_284',
'mr_285',
'mr_286',
'mr_29',
'mr_296',
'mr_297',
'mr_299',
'mr_300',
'mr_302',
'mr_303',
'mr_304',
'mr_305',
'mr_306',
'mr_307',
'mr_344',
'mr_348',
'mr_397',
'mr_400',
'mr_401',
'mr_41',
'mr_51',
'mr_52',
'mr_53',
'mr_79',
'mr_81',
'mr_82',
'mr_83',
'mr_86',
'mw_135',
'mw_136',
'mw_137',
'mw_211',
'mw_212',
'mw_215',
'mw_284',
'mw_285',
'mw_286',
'mw_297',
'mw_299',
'mw_300',
'mw_302',
'mw_303',
'mw_304',
'mw_305',
'mw_306',
'mw_401',
'mw_51',
'mw_52',
'mw_53',
'mw_79'
,'mr_405'
,'mw_405'
,'mr_243' 
,'mw_243'

,'mr_417' --interfacce docenti e amministrativi
,'mr_418'
,'mr_419'
,'mw_417'
,'mw_418'
,'mw_419'

)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202198' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogettokind  
	from progettotipocostokindaccmotive
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idaccmotive, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogettokind  
	from progettotipocostokindcontrattokind
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idcontrattokind, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogettokind  
	from progettotipocostokindinventorytree
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idinv, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogettokind  
	from progettotipocostokindtax
	where idprogettokind = %<progettokind.idprogettokind>%
	group by taxcode, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogetto  
	from progettotipocostoaccmotive
	where idprogetto = %<progetto.idprogetto>%
	group by idaccmotive, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogetto  
	from progettotipocostocontrattokind
	where idprogetto = %<progetto.idprogetto>%
	group by idcontrattokind, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogetto  
	from progettotipocostoinventorytree
	where idprogetto = %<progetto.idprogetto>%
	group by idinv, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'workpackageupb', @code = 'WORKPACKAGEUPB01', @message = 'L''UPB risulta già  associato ad un''altro Workpackage.', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '[(select cc from (
select count(*)as cc, idprogetto, idupb  from workpackageupb
group by idprogetto, idupb) tbl1
where idupb= %<workpackageupb.idupb>% and idprogetto = %<workpackageupb.idprogetto>%)]{I} =1', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO05', @message = 'Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato
([
select count(idprogettostatuskind) from progettoattachkindprogettostatuskind 
	where 
	idprogettoattachkind IN 
		(
			select  idprogettoattachkind from progettoattachkind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progetto.idprogetto>%)
			AND
			title IN (select title from progettoattach where idprogetto = %<progetto.idprogetto>% and idattach is null)
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progetto.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO06', @message = 'Bisogna inserire le descrizioni per tutti i testi del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna inserire le descrizioni per tutti i testi del progetto, per questo specifico stato selezionato
([
select count(idprogettotestokind) from progettotestokindprogettostatuskind 
	where 
	idprogettotestokind IN 
		(
			select idprogettotestokind from progettotestokind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progetto.idprogetto>%)
			AND
			titolo in (select title from progettotesto where idprogetto = %<progetto.idprogetto>% and description is null)
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progetto.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettoattach', @code = 'PROGETTOATTACH01', @message = 'Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato
([
select count(idprogettostatuskind) from progettoattachkindprogettostatuskind 
	where 
	idprogettoattachkind IN 
		(
			select  idprogettoattachkind from progettoattachkind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progettoattach.idprogetto>%)
			AND
			title IN (select title from progettoattach where idprogetto = %<progettoattach.idprogetto>% and idattach is null)
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progettoattach.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO07', @message = 'Bisogna inserire sia l''ente capofila che finanziatore, se lo stato è operativo', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna inserire sia l''''ente capofila che finanziatore, se lo stato è operativo
([select count(*) from progetto
	    where
	    ((progetto.idreg_aziende is not null and progetto.idreg_aziende_fin is not null and %<progetto.idprogettostatuskind>% >= 8) OR
	     (%<progetto.idprogettostatuskind>% < 8)) AND
	     idprogetto = %<progetto.idprogetto>%
]{I} = 1)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettotesto', @code = 'PROGETTOTESTO01', @message = 'Bisogna inserire descrizioni per tutti i testi del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna inserire le descrizioni per tutti i testi del progetto, per questo specifico stato selezionato
([
select count(idprogettotestokind) from progettotestokindprogettostatuskind 
	where 
	idprogettotestokind IN 
		(
			select idprogettotestokind from progettotestokind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progettotesto.idprogetto>%)
			AND
			titolo in (select title from progettotesto where idprogetto = %<progettotesto.idprogetto>% and isnull(description ,'''') = '''')
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progettotesto.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
--rule	
