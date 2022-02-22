
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
-- CREAZIONE TABELLA valutazionekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[valutazionekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[valutazionekind] (
idvalutazionekind int NOT NULL,
active char(19) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkvalutazionekind PRIMARY KEY (idvalutazionekind
)
)
END
GO

-- VERIFICA STRUTTURA valutazionekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'idvalutazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD idvalutazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'idvalutazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD active char(19) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN active char(19) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI valutazionekind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'valutazionekind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','int','ASSISTENZA','idvalutazionekind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','char(19)','ASSISTENZA','active','19','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','valutazionekind','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','valutazionekind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI valutazionekind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'valutazionekind')
UPDATE customobject set isreal = 'S' where objectname = 'valutazionekind'
ELSE
INSERT INTO customobject (objectname, isreal) values('valutazionekind', 'S')
GO

-- GENERAZIONE DATI PER valutazionekind --
IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '1')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'prova scritta' WHERE idvalutazionekind = '1'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','prova scritta')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '2')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'prova orale' WHERE idvalutazionekind = '2'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','prova orale')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '3')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-01-09 21:02:07.797'},lu = 'riccardotest',sortcode = '3',title = 'prova pratica' WHERE idvalutazionekind = '3'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-01-09 21:02:07.797'},'riccardotest','3','prova pratica')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '4')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-01-09 21:02:21.283'},lu = 'riccardotest',sortcode = '4',title = 'test attitudinale' WHERE idvalutazionekind = '4'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-01-09 21:02:21.283'},'riccardotest','4','test attitudinale')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '5')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'valutazione di un progetto' WHERE idvalutazionekind = '5'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','5','valutazione di un progetto')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '6')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'tirocinio' WHERE idvalutazionekind = '6'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','6','tirocinio')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '7')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'laboratorio' WHERE idvalutazionekind = '7'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','7','laboratorio')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '8')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2020-01-21 18:16:21.273'},cu = 'riccardotest',description = null,lt = {ts '2020-01-21 18:16:21.273'},lu = 'riccardotest',sortcode = '8',title = 'Dettato' WHERE idvalutazionekind = '8'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S                  ',{ts '2020-01-21 18:16:21.273'},'riccardotest',null,{ts '2020-01-21 18:16:21.273'},'riccardotest','8','Dettato')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'valutazionekind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile da loro delle modalit? di valutazione delle prove d?esame',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 15:01:15.853'},lu = 'assistenza',title = 'VOCABOLARIO modificabile da loro delle modalit? di valutazione delle prove d?esame' WHERE tablename = 'valutazionekind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('valutazionekind','VOCABOLARIO modificabile da loro delle modalit? di valutazione delle prove d?esame',null,'N',{ts '2018-07-19 15:01:15.853'},'assistenza','VOCABOLARIO modificabile da loro delle modalit? di valutazione delle prove d?esame')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '19',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(19)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','valutazionekind','19',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','char(19)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','valutazionekind','8',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','valutazionekind','64',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','valutazionekind','256',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idvalutazionekind' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idvalutazionekind' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idvalutazionekind','valutazionekind','4',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','valutazionekind','8',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','valutazionekind','64',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','valutazionekind','4',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'valutazionekind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:00:54.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'valutazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','valutazionekind','50',null,null,null,'S',{ts '2018-07-19 15:00:54.527'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3263')
UPDATE [relation] SET childtable = 'valutazionekind',description = 'prova d''esame di cui descrive la modalit? di valutazione',lt = {ts '2018-07-19 15:08:27.807'},lu = 'assistenza',parenttable = 'prova',title = null WHERE idrelation = '3263'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3263','valutazionekind','prova d''esame di cui descrive la modalit? di valutazione',{ts '2018-07-19 15:08:27.807'},'assistenza','prova',null)
GO

-- FINE GENERAZIONE SCRIPT --

