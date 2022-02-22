
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
-- CREAZIONE TABELLA learningagrtrainerkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[learningagrtrainerkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[learningagrtrainerkind] (
idlearningagrtrainerkind int NOT NULL,
active char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpklearningagrtrainerkind PRIMARY KEY (idlearningagrtrainerkind
)
)
END
GO

-- VERIFICA STRUTTURA learningagrtrainerkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainerkind' and C.name = 'idlearningagrtrainerkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainerkind] ADD idlearningagrtrainerkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainerkind') and col.name = 'idlearningagrtrainerkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainerkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainerkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainerkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainerkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainerkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainerkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainerkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainerkind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainerkind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainerkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainerkind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainerkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainerkind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainerkind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainerkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainerkind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainerkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainerkind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainerkind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainerkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainerkind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainerkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainerkind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainerkind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainerkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainerkind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI learningagrtrainerkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'learningagrtrainerkind'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlearningagrtrainerkind','4','''assistenza''','int','learningagrtrainerkind','','','','','N','S','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','active','1','''assistenza''','char(1)','learningagrtrainerkind','','','','','N','N','char','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lt','8','''assistenza''','datetime','learningagrtrainerkind','','','','','N','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lu','64','''assistenza''','varchar(64)','learningagrtrainerkind','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','sortcode','4','''assistenza''','int','learningagrtrainerkind','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','title','50','''assistenza''','varchar(50)','learningagrtrainerkind','','','','','N','N','varchar','assistenza','System.String')
GO

-- VERIFICA DI learningagrtrainerkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'learningagrtrainerkind')
UPDATE customobject set isreal = 'S' where objectname = 'learningagrtrainerkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('learningagrtrainerkind', 'S')
GO

-- GENERAZIONE DATI PER learningagrtrainerkind --
IF exists(SELECT * FROM [learningagrtrainerkind] WHERE idlearningagrtrainerkind = '1')
UPDATE [learningagrtrainerkind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Curriculare' WHERE idlearningagrtrainerkind = '1'
ELSE
INSERT INTO [learningagrtrainerkind] (idlearningagrtrainerkind,active,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Curriculare')
GO

IF exists(SELECT * FROM [learningagrtrainerkind] WHERE idlearningagrtrainerkind = '2')
UPDATE [learningagrtrainerkind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Volontario' WHERE idlearningagrtrainerkind = '2'
ELSE
INSERT INTO [learningagrtrainerkind] (idlearningagrtrainerkind,active,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Volontario')
GO

IF exists(SELECT * FROM [learningagrtrainerkind] WHERE idlearningagrtrainerkind = '3')
UPDATE [learningagrtrainerkind] SET active = 'S',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Neolaureato' WHERE idlearningagrtrainerkind = '3'
ELSE
INSERT INTO [learningagrtrainerkind] (idlearningagrtrainerkind,active,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Neolaureato')
GO

-- FINE GENERAZIONE SCRIPT --

