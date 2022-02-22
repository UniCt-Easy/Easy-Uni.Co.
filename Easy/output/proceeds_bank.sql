
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


-- CREAZIONE TABELLA proceeds_bank --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[proceeds_bank]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [proceeds_bank] (
kpro int NOT NULL,
idpro int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
 CONSTRAINT xpkproceeds_bank PRIMARY KEY (kpro,
idpro
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceeds_bank' and id=object_id('proceeds_bank'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds_bank
     ON proceeds_bank
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds_bank
     ON proceeds_bank
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1proceeds_bank' and id=object_id('proceeds_bank'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds_bank
     ON proceeds_bank
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1proceeds_bank
     ON proceeds_bank
     (
     kpro     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA STRUTTURA proceeds_bank --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'kpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD kpro int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'kpro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'idpro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD idpro int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'idpro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'amount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD amount decimal(19,2) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'amount' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN amount decimal(19,2) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD description varchar(200) NULL 
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN description varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('proceeds_bank') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [proceeds_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'proceeds_bank' and C.name = 'nbill' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [proceeds_bank] ADD nbill int NULL 
END
ELSE
	ALTER TABLE [proceeds_bank] ALTER COLUMN nbill int NULL
GO

-- VERIFICA DI proceeds_bank IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'proceeds_bank'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','N','System.Int32','int','S','proceeds_bank','N','','4','idpro','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','proceeds_bank','S','','4','kpro','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','proceeds_bank','S','','9','amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','datetime','','N','System.DateTime','datetime','N','proceeds_bank','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','N','System.String','varchar(64)','N','proceeds_bank','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','S','System.String','varchar(200)','N','proceeds_bank','N','','200','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','N','System.Int32','int','N','proceeds_bank','S','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','datetime','','N','System.DateTime','datetime','N','proceeds_bank','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','N','System.String','varchar(64)','N','proceeds_bank','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','S','System.Int32','int','N','proceeds_bank','N','','4','nbill','')
GO

-- VERIFICA DI proceeds_bank IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'proceeds_bank')
UPDATE customobject set isreal = 'S' where objectname = 'proceeds_bank'
ELSE
INSERT INTO customobject (objectname, isreal) values('proceeds_bank', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

