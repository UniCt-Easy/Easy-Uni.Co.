
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


-- CREAZIONE TABELLA sasdaffini --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdaffini]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sasdaffini] (
idsasd int NOT NULL,
idsasd_affine int NOT NULL,
affinita int NOT NULL,
 CONSTRAINT xpksasdaffini PRIMARY KEY (idsasd,
idsasd_affine
)
)
END
GO

-- VERIFICA STRUTTURA sasdaffini --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdaffini' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdaffini] ADD idsasd int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdaffini') and col.name = 'idsasd' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdaffini] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdaffini' and C.name = 'idsasd_affine' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdaffini] ADD idsasd_affine int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdaffini') and col.name = 'idsasd_affine' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdaffini] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sasdaffini' and C.name = 'affinita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sasdaffini] ADD affinita int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sasdaffini') and col.name = 'affinita' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sasdaffini] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sasdaffini] ALTER COLUMN affinita int NOT NULL
GO

-- VERIFICA DI sasdaffini IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sasdaffini'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdaffini','int','assistenza','idsasd','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdaffini','int','assistenza','idsasd_affine','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sasdaffini','int','assistenza','affinita','4','S','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI sasdaffini IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sasdaffini')
UPDATE customobject set isreal = 'S' where objectname = 'sasdaffini'
ELSE
INSERT INTO customobject (objectname, isreal) values('sasdaffini', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sasdaffini')
UPDATE [tabledescr] SET description = 'SASD affini',idapplication = '2',isdbo = 'N',lt = {ts '2021-05-21 10:22:39.843'},lu = 'assistenza',title = 'SASD affini' WHERE tablename = 'sasdaffini'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sasdaffini','SASD affini','2','N',{ts '2021-05-21 10:22:39.843'},'assistenza','SASD affini')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'affinita' AND tablename = 'sasdaffini')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Affinità',kind = 'S',lt = {ts '2021-05-21 10:24:23.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'affinita' AND tablename = 'sasdaffini'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('affinita','sasdaffini','4',null,null,'Affinità','S',{ts '2021-05-21 10:24:23.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'sasdaffini')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2021-05-21 10:24:23.043'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'sasdaffini'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','sasdaffini','4',null,null,'SASD','S',{ts '2021-05-21 10:24:23.043'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd_affine' AND tablename = 'sasdaffini')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD affine',kind = 'S',lt = {ts '2021-05-21 10:24:23.043'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd_affine' AND tablename = 'sasdaffini'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd_affine','sasdaffini','4',null,null,'SASD affine','S',{ts '2021-05-21 10:24:23.043'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

