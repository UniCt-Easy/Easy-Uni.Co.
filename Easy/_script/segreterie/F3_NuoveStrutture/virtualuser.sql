
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

