
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


/* Versione 1.0.0 del 11/09/2007 ultima modifica: PIERO */

if exists (select * from dbo.sysobjects where id = object_id(N'[create_dbaccess]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [create_dbaccess]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE             procedure create_dbaccess(@userlogin varchar(50), @alpha1 varchar(66), @iddbdepartment varchar(50)) as
begin
-- CREAZIONE TABELLA dbuser --
IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'[dbo].[dbuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbuser] (
login varchar(50) NOT NULL,
forename varchar(50) NULL,
initpwd varchar(50) NULL,
lt datetime NULL,
lu varchar(64) NULL,
start datetime NULL,
stop datetime NULL,
surname varchar(50) NULL,
 CONSTRAINT xpkdbuser PRIMARY KEY (login
)
)
END
-- VERIFICA STRUTTURA dbuser --
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'login')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD login varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(150)
	select @vincolo = nam.name from sysobjects tabl join syscolumns col on col.id = tabl.id join sysconstraints const on const.id = tabl.id and const.colid = col.colid join sysobjects nam on nam.id=const.constid where tabl.name = 'dbuser' and col.name = 'login' and nam.xtype = 'D'
	exec ('ALTER TABLE [dbo].[dbuser] drop constraint '+@vincolo)
END
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'forename')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD forename varchar(50) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbuser] ALTER COLUMN forename varchar(50) NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'initpwd')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD initpwd varchar(50) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbuser] ALTER COLUMN initpwd varchar(50) NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'lt')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [dbo].[dbuser] ALTER COLUMN lt datetime NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'lu')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbuser] ALTER COLUMN lu varchar(64) NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'start')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD start datetime NULL 
END
ELSE
	ALTER TABLE [dbo].[dbuser] ALTER COLUMN start datetime NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'stop')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD stop datetime NULL 
END
ELSE
	ALTER TABLE [dbo].[dbuser] ALTER COLUMN stop datetime NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbuser' and C.name = 'surname')
BEGIN
	ALTER TABLE [dbo].[dbuser] ADD surname varchar(50) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbuser] ALTER COLUMN surname varchar(50) NULL
-- VERIFICA DI dbuser IN COLUMNTYPES --
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'login')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = 'SA',col_scale = '',iskey = 'S',tablename = 'dbuser',field = 'login',col_len = '50' where tablename = 'dbuser' AND field = 'login'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','S','System.String','','','''SA''','','varchar','N','SA','','S','dbuser','login','50')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'forename')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbuser',field = 'forename',col_len = '50' where tablename = 'dbuser' AND field = 'forename'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbuser','forename','50')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'initpwd')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbuser',field = 'initpwd',col_len = '50' where tablename = 'dbuser' AND field = 'initpwd'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbuser','initpwd','50')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'lt')
UPDATE [dbo].[columntypes] set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbuser',field = 'lt',col_len = '8' where tablename = 'dbuser' AND field = 'lt'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','''SA''','','datetime','S','SA','','N','dbuser','lt','8')


IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'lu')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(64)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbuser',field = 'lu',col_len = '64' where tablename = 'dbuser' AND field = 'lu'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(64)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbuser','lu','64')


IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'start')
UPDATE [dbo].[columntypes] set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbuser',field = 'start',col_len = '8' where tablename = 'dbuser' AND field = 'start'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','''SA''','','datetime','S','SA','','N','dbuser','start','8')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'stop')
UPDATE [dbo].[columntypes] set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbuser',field = 'stop',col_len = '8' where tablename = 'dbuser' AND field = 'stop'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','''SA''','','datetime','S','SA','','N','dbuser','stop','8')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbuser' AND field = 'surname')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbuser',field = 'surname',col_len = '50' where tablename = 'dbuser' AND field = 'surname'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbuser','surname','50')
-- VERIFICA DI dbuser IN CUSTOMOBJECT --
IF EXISTS(select * from [dbo].[customobject] where objectname = 'dbuser')
UPDATE [dbo].[customobject] set isreal = 'S' where objectname = 'dbuser'
ELSE
INSERT INTO [dbo].[customobject] (objectname, isreal) values('dbuser', 'S')
-- GENERAZIONE DATI PER dbuser --
IF exists(SELECT * FROM [dbo].[dbuser] WHERE login = @userlogin)
UPDATE [dbo].[dbuser] SET forename = null,initpwd = null,lt = {ts '2005-10-27 11:47:33.187'},lu = '''SA''',start = null,stop = null,surname = null WHERE login = @userlogin
ELSE
INSERT INTO [dbo].[dbuser] (login,forename,initpwd,lt,lu,start,stop,surname) VALUES (@userlogin,null,null,{ts '2005-10-27 11:47:33.187'},'''SA''',null,null,null)
-- FINE GENERAZIONE SCRIPT --


-- CREAZIONE TABELLA dbaccess --
IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'[dbo].[dbaccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbaccess] (
iddbdepartment varchar(50) NOT NULL,
login varchar(50) NOT NULL,
alpha1 varchar(66) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkdbaccess PRIMARY KEY (iddbdepartment,
login
)
)
END
-- VERIFICA STRUTTURA dbaccess --
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'iddbdepartment')
BEGIN
	ALTER TABLE [dbo].[dbaccess] ADD iddbdepartment varchar(50) NOT NULL DEFAULT ''
	select @vincolo = nam.name from sysobjects tabl join syscolumns col on col.id = tabl.id join sysconstraints const on const.id = tabl.id and const.colid = col.colid join sysobjects nam on nam.id=const.constid where tabl.name = 'dbaccess' and col.name = 'iddbdepartment' and nam.xtype = 'D'
	exec ('ALTER TABLE [dbo].[dbaccess] drop constraint '+@vincolo)
END
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'login')
BEGIN
	ALTER TABLE [dbo].[dbaccess] ADD login varchar(50) NOT NULL DEFAULT ''
	select @vincolo = nam.name from sysobjects tabl join syscolumns col on col.id = tabl.id join sysconstraints const on const.id = tabl.id and const.colid = col.colid join sysobjects nam on nam.id=const.constid where tabl.name = 'dbaccess' and col.name = 'login' and nam.xtype = 'D'
	exec ('ALTER TABLE [dbo].[dbaccess] drop constraint '+@vincolo)
END
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'alpha1')
BEGIN
	ALTER TABLE [dbo].[dbaccess] ADD alpha1 varchar(66) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbaccess] ALTER COLUMN alpha1 varchar(66) NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'lt')
BEGIN
	ALTER TABLE [dbo].[dbaccess] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [dbo].[dbaccess] ALTER COLUMN lt datetime NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbaccess' and C.name = 'lu')
BEGIN
	ALTER TABLE [dbo].[dbaccess] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbaccess] ALTER COLUMN lu varchar(64) NULL
-- VERIFICA DI dbaccess IN COLUMNTYPES --
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbaccess' AND field = 'iddbdepartment')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = 'SA',col_scale = '',iskey = 'S',tablename = 'dbaccess',field = 'iddbdepartment',col_len = '50' where tablename = 'dbaccess' AND field = 'iddbdepartment'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','S','System.String','','','''SA''','','varchar','N','SA','','S','dbaccess','iddbdepartment','50')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbaccess' AND field = 'login')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = 'SA',col_scale = '',iskey = 'S',tablename = 'dbaccess',field = 'login',col_len = '50' where tablename = 'dbaccess' AND field = 'login'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','S','System.String','','','''SA''','','varchar','N','SA','','S','dbaccess','login','50')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbaccess' AND field = 'alpha1')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(66)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbaccess',field = 'alpha1',col_len = '66' where tablename = 'dbaccess' AND field = 'alpha1'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(66)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbaccess','alpha1','66')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbaccess' AND field = 'lt')
UPDATE [dbo].[columntypes] set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbaccess',field = 'lt',col_len = '8' where tablename = 'dbaccess' AND field = 'lt'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','''SA''','','datetime','S','SA','','N','dbaccess','lt','8')


IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbaccess' AND field = 'lu')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(64)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbaccess',field = 'lu',col_len = '64' where tablename = 'dbaccess' AND field = 'lu'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(64)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbaccess','lu','64')


-- VERIFICA DI dbaccess IN CUSTOMOBJECT --
IF EXISTS(select * from [dbo].[customobject] where objectname = 'dbaccess')
UPDATE [dbo].[customobject] set isreal = 'S' where objectname = 'dbaccess'
ELSE
INSERT INTO [dbo].[customobject] (objectname, isreal) values('dbaccess', 'S')
-- GENERAZIONE DATI PER dbaccess --
IF exists(SELECT * FROM [dbo].[dbaccess] WHERE iddbdepartment = @iddbdepartment AND login = @userlogin)
UPDATE [dbo].[dbaccess] SET alpha1 = @alpha1,lt = {ts '2005-10-28 15:56:28.267'},lu = '''SA''' WHERE iddbdepartment = 'dip1' AND login = 'SA'
ELSE
INSERT INTO [dbo].[dbaccess] (iddbdepartment,login,alpha1,lt,lu) VALUES ('dip1','SA',@alpha1,{ts '2005-10-28 15:56:28.267'},'''SA''')
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA dbdepartment --
IF NOT EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'[dbo].[dbdepartment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbdepartment] (
iddbdepartment varchar(50) NOT NULL,
description varchar(50) NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkdbdepartment PRIMARY KEY (iddbdepartment
)
)
END
-- VERIFICA STRUTTURA dbdepartment --
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbdepartment' and C.name = 'iddbdepartment')
BEGIN
	ALTER TABLE [dbo].[dbdepartment] ADD iddbdepartment varchar(50) NOT NULL DEFAULT ''
	select @vincolo = nam.name from sysobjects tabl join syscolumns col on col.id = tabl.id join sysconstraints const on const.id = tabl.id and const.colid = col.colid join sysobjects nam on nam.id=const.constid where tabl.name = 'dbdepartment' and col.name = 'iddbdepartment' and nam.xtype = 'D'
	exec ('ALTER TABLE [dbo].[dbdepartment] drop constraint '+@vincolo)
END
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbdepartment' and C.name = 'description')
BEGIN
	ALTER TABLE [dbo].[dbdepartment] ADD description varchar(50) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbdepartment] ALTER COLUMN description varchar(50) NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbdepartment' and C.name = 'lt')
BEGIN
	ALTER TABLE [dbo].[dbdepartment] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [dbo].[dbdepartment] ALTER COLUMN lt datetime NULL
IF NOT exists(select * from [dbo].[sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'dbdepartment' and C.name = 'lu')
BEGIN
	ALTER TABLE [dbo].[dbdepartment] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [dbo].[dbdepartment] ALTER COLUMN lu varchar(64) NULL
-- VERIFICA DI dbdepartment IN COLUMNTYPES --
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbdepartment' AND field = 'iddbdepartment')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'S',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'N',createuser = 'SA',col_scale = '',iskey = 'S',tablename = 'dbdepartment',field = 'iddbdepartment',col_len = '50' where tablename = 'dbdepartment' AND field = 'iddbdepartment'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','S','System.String','','','''SA''','','varchar','N','SA','','S','dbdepartment','iddbdepartment','50')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbdepartment' AND field = 'description')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(50)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbdepartment',field = 'description',col_len = '50' where tablename = 'dbdepartment' AND field = 'description'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(50)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbdepartment','description','50')
IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbdepartment' AND field = 'lt')
UPDATE [dbo].[columntypes] set sqldeclaration = 'datetime',denynull = 'N',systemtype = 'System.DateTime',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'datetime',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbdepartment',field = 'lt',col_len = '8' where tablename = 'dbdepartment' AND field = 'lt'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('datetime','N','System.DateTime','','','''SA''','','datetime','S','SA','','N','dbdepartment','lt','8')

IF exists(SELECT * FROM [dbo].[columntypes] WHERE tablename = 'dbdepartment' AND field = 'lu')
UPDATE [dbo].[columntypes] set sqldeclaration = 'varchar(64)',denynull = 'N',systemtype = 'System.String',defaultvalue = '',format = '',lastmoduser = '''SA''',col_precision = '',sqltype = 'varchar',allownull = 'S',createuser = 'SA',col_scale = '',iskey = 'N',tablename = 'dbdepartment',field = 'lu',col_len = '64' where tablename = 'dbdepartment' AND field = 'lu'
ELSE
INSERT INTO [dbo].[columntypes] (sqldeclaration,denynull,systemtype,defaultvalue,format,lastmoduser,col_precision,sqltype,allownull,createuser,col_scale,iskey,tablename,field,col_len) VALUES('varchar(64)','N','System.String','','','''SA''','','varchar','S','SA','','N','dbdepartment','lu','64')

-- VERIFICA DI dbdepartment IN CUSTOMOBJECT --
IF EXISTS(select * from [dbo].[customobject] where objectname = 'dbdepartment')
UPDATE [dbo].[customobject] set isreal = 'S' where objectname = 'dbdepartment'
ELSE
INSERT INTO [dbo].[customobject] (objectname, isreal) values('dbdepartment', 'S')
-- GENERAZIONE DATI PER dbdepartment --
IF exists(SELECT * FROM [dbo].[dbdepartment] WHERE iddbdepartment = @iddbdepartment)
UPDATE [dbo].[dbdepartment] SET description = null,lt = {ts '2005-10-27 15:15:27.733'},lu = '''SA''' WHERE iddbdepartment = @iddbdepartment
ELSE
INSERT INTO [dbo].[dbdepartment] (iddbdepartment,description,lt,lu) VALUES (@iddbdepartment,null,{ts '2005-10-27 15:15:27.733'},'''SA''')
-- FINE GENERAZIONE SCRIPT --
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

