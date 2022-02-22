
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


-- CREAZIONE TABELLA erogazkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[erogazkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[erogazkind] (
iderogazkind int NOT NULL,
active char(1) NOT NULL,
ans varchar(10) NULL,
description varchar(255) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkerogazkind PRIMARY KEY (iderogazkind
)
)
END
GO

-- VERIFICA STRUTTURA erogazkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'iderogazkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD iderogazkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'iderogazkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'ans' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD ans varchar(10) NULL 
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN ans varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD description varchar(255) NULL 
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN description varchar(255) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'erogazkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [erogazkind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('erogazkind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [erogazkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [erogazkind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI erogazkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'erogazkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkind','int','ASSISTENZA','iderogazkind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','erogazkind','varchar(10)','ASSISTENZA','ans','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','erogazkind','varchar(255)','ASSISTENZA','description','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','erogazkind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI erogazkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'erogazkind')
UPDATE customobject set isreal = 'S' where objectname = 'erogazkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('erogazkind', 'S')
GO

-- GENERAZIONE DATI PER erogazkind --
IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '1')
UPDATE [erogazkind] SET active = 'S',ans = 'C',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Convenzionale' WHERE iderogazkind = '1'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('1','S','C',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Convenzionale')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '2')
UPDATE [erogazkind] SET active = 'S',ans = 'T',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Teledidattica' WHERE iderogazkind = '2'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('2','S','T',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Teledidattica')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '3')
UPDATE [erogazkind] SET active = 'S',ans = null,description = 'replicato con didattica frontale e in teledidattica',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Doppia ' WHERE iderogazkind = '3'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('3','S',null,'replicato con didattica frontale e in teledidattica',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Doppia ')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '4')
UPDATE [erogazkind] SET active = 'S',ans = 'P',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Prevalentemente a distanza' WHERE iderogazkind = '4'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('4','S','P',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Prevalentemente a distanza')
GO

IF exists(SELECT * FROM [erogazkind] WHERE iderogazkind = '5')
UPDATE [erogazkind] SET active = 'S',ans = 'B',description = 'insegnamenti o parte di insegnamenti in didattica frontale e didattica in teledidattica',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Blended/Modalità Mista' WHERE iderogazkind = '5'
ELSE
INSERT INTO [erogazkind] (iderogazkind,active,ans,description,lt,lu,sortcode,title) VALUES ('5','S','B','insegnamenti o parte di insegnamenti in didattica frontale e didattica in teledidattica',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Blended/Modalità Mista')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'erogazkind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle modalità di erogazione della didattica',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-20 16:24:33.910'},lu = 'assistenza',title = 'modalità di erogazione della didattica' WHERE tablename = 'erogazkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('erogazkind','VOCABOLARIO delle modalità di erogazione della didattica','2','S',{ts '2018-07-20 16:24:33.910'},'assistenza','modalità di erogazione della didattica')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','erogazkind','1',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','erogazkind','255',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','N','varchar(255)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iderogazkind' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iderogazkind' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iderogazkind','erogazkind','4',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','erogazkind','8',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.777'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','erogazkind','64',null,null,null,'S',{ts '2018-07-19 15:47:30.777'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.777'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','erogazkind','4',null,null,null,'S',{ts '2018-07-19 15:47:30.777'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.777'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','erogazkind','50',null,null,null,'S',{ts '2018-07-19 15:47:30.777'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3273')
UPDATE [relation] SET childtable = 'erogazkind',description = 'didattica di cui si descrive la modalit? di erogazione',lt = {ts '2018-07-19 15:49:09.747'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3273'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3273','erogazkind','didattica di cui si descrive la modalit? di erogazione',{ts '2018-07-19 15:49:09.747'},'assistenza','didprog',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3274')
UPDATE [relation] SET childtable = 'erogazkind',description = 'affidamento dell''insegnamento al docente di cui si descrive la modalit? di erogazione',lt = {ts '2018-07-19 15:51:24.777'},lu = 'assistenza',parenttable = 'affidamento',title = null WHERE idrelation = '3274'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3274','erogazkind','affidamento dell''insegnamento al docente di cui si descrive la modalit? di erogazione',{ts '2018-07-19 15:51:24.777'},'assistenza','affidamento',null)
GO

-- FINE GENERAZIONE SCRIPT --

