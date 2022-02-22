
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
-- CREAZIONE TABELLA learningagrtrainervalut --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[learningagrtrainervalut]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[learningagrtrainervalut] (
idlearningagrtrainervalut int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpklearningagrtrainervalut PRIMARY KEY (idlearningagrtrainervalut
)
)
END
GO

-- VERIFICA STRUTTURA learningagrtrainervalut --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainervalut' and C.name = 'idlearningagrtrainervalut' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainervalut] ADD idlearningagrtrainervalut int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainervalut') and col.name = 'idlearningagrtrainervalut' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainervalut] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainervalut' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainervalut] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainervalut') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainervalut] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainervalut] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainervalut' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainervalut] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainervalut] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainervalut' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainervalut] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainervalut') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainervalut] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainervalut] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainervalut' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainervalut] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainervalut') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainervalut] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainervalut] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainervalut' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainervalut] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainervalut') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainervalut] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainervalut] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainervalut' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainervalut] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainervalut') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainervalut] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainervalut] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI learningagrtrainervalut IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'learningagrtrainervalut'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlearningagrtrainervalut','4','''assistenza''','int','learningagrtrainervalut','','','','','N','S','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','active','1','''assistenza''','char(1)','learningagrtrainervalut','','','','','N','N','char','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','256','''assistenza''','varchar(256)','learningagrtrainervalut','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lt','8','''assistenza''','datetime','learningagrtrainervalut','','','','','N','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lu','64','''assistenza''','varchar(64)','learningagrtrainervalut','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','sortcode','4','''assistenza''','int','learningagrtrainervalut','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','title','50','''assistenza''','varchar(50)','learningagrtrainervalut','','','','','N','N','varchar','assistenza','System.String')
GO

-- VERIFICA DI learningagrtrainervalut IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'learningagrtrainervalut')
UPDATE customobject set isreal = 'S' where objectname = 'learningagrtrainervalut'
ELSE
INSERT INTO customobject (objectname, isreal) values('learningagrtrainervalut', 'S')
GO

-- GENERAZIONE DATI PER learningagrtrainervalut --
IF exists(SELECT * FROM [learningagrtrainervalut] WHERE idlearningagrtrainervalut = '1')
UPDATE [learningagrtrainervalut] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Report finale' WHERE idlearningagrtrainervalut = '1'
ELSE
INSERT INTO [learningagrtrainervalut] (idlearningagrtrainervalut,active,description,lt,lu,sortcode,title) VALUES ('1','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Report finale')
GO

IF exists(SELECT * FROM [learningagrtrainervalut] WHERE idlearningagrtrainervalut = '2')
UPDATE [learningagrtrainervalut] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Intervista' WHERE idlearningagrtrainervalut = '2'
ELSE
INSERT INTO [learningagrtrainervalut] (idlearningagrtrainervalut,active,description,lt,lu,sortcode,title) VALUES ('2','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Intervista')
GO

IF exists(SELECT * FROM [learningagrtrainervalut] WHERE idlearningagrtrainervalut = '3')
UPDATE [learningagrtrainervalut] SET active = 'S',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Rilascio di certificato' WHERE idlearningagrtrainervalut = '3'
ELSE
INSERT INTO [learningagrtrainervalut] (idlearningagrtrainervalut,active,description,lt,lu,sortcode,title) VALUES ('3','S',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Rilascio di certificato')
GO

-- FINE GENERAZIONE SCRIPT --

