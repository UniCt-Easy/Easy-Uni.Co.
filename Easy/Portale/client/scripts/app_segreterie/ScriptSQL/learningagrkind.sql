
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
-- CREAZIONE TABELLA learningagrkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[learningagrkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[learningagrkind] (
idlearningagrkind int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NULL,
 CONSTRAINT xpklearningagrkind PRIMARY KEY (idlearningagrkind
)
)
END
GO

-- VERIFICA STRUTTURA learningagrkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrkind' and C.name = 'idlearningagrkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrkind] ADD idlearningagrkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrkind') and col.name = 'idlearningagrkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrkind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [learningagrkind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrkind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrkind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrkind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrkind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrkind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrkind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrkind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrkind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrkind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrkind] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [learningagrkind] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI learningagrkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'learningagrkind'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlearningagrkind','4','''assistenza''','int','learningagrkind','','','','','N','S','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','active','1','''assistenza''','char(1)','learningagrkind','','','','','N','N','char','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','256','''assistenza''','varchar(256)','learningagrkind','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lt','8','''assistenza''','datetime','learningagrkind','','','','','N','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lu','64','''assistenza''','varchar(64)','learningagrkind','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','sortcode','4','''assistenza''','int','learningagrkind','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','title','50','''assistenza''','varchar(50)','learningagrkind','','','','','S','N','varchar','assistenza','System.String')
GO

-- VERIFICA DI learningagrkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'learningagrkind')
UPDATE customobject set isreal = 'S' where objectname = 'learningagrkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('learningagrkind', 'S')
GO

-- GENERAZIONE DATI PER learningagrkind --
IF exists(SELECT * FROM [learningagrkind] WHERE idlearningagrkind = '1')
UPDATE [learningagrkind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'before the mobility' WHERE idlearningagrkind = '1'
ELSE
INSERT INTO [learningagrkind] (idlearningagrkind,active,description,lt,lu,sortcode,title) VALUES ('1','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','before the mobility')
GO

IF exists(SELECT * FROM [learningagrkind] WHERE idlearningagrkind = '2')
UPDATE [learningagrkind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'during the mobility' WHERE idlearningagrkind = '2'
ELSE
INSERT INTO [learningagrkind] (idlearningagrkind,active,description,lt,lu,sortcode,title) VALUES ('2','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','during the mobility')
GO

IF exists(SELECT * FROM [learningagrkind] WHERE idlearningagrkind = '3')
UPDATE [learningagrkind] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'after the mobility' WHERE idlearningagrkind = '3'
ELSE
INSERT INTO [learningagrkind] (idlearningagrkind,active,description,lt,lu,sortcode,title) VALUES ('3','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','after the mobility')
GO

-- FINE GENERAZIONE SCRIPT --

