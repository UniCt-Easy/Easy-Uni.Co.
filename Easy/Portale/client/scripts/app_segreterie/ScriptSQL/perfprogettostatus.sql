
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


-- CREAZIONE TABELLA perfprogettostatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettostatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettostatus] (
idperfprogettostatus int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfprogettostatus PRIMARY KEY (idperfprogettostatus
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettostatus --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'idperfprogettostatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD idperfprogettostatus int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'idperfprogettostatus' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN title varchar(1024) NULL
GO

-- VERIFICA DI perfprogettostatus IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettostatus'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettostatus','int','assistenza','idperfprogettostatus','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettostatus','char(1)','assistenza','active','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettostatus','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettostatus','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettostatus','varchar(max)','assistenza','description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettostatus','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettostatus','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettostatus','varchar(1024)','assistenza','title','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfprogettostatus IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettostatus')
UPDATE customobject set isreal = 'S' where objectname = 'perfprogettostatus'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettostatus', 'S')
GO

-- GENERAZIONE DATI PER perfprogettostatus --
IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '1')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-05-24 13:15:52.607'},cu = 'seg_psuma',description = 'In corso',lt = {ts '2021-05-24 13:15:52.607'},lu = 'seg_psuma',title = 'In corso' WHERE idperfprogettostatus = '1'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('1','S',{ts '2021-05-24 13:15:52.607'},'seg_psuma','In corso',{ts '2021-05-24 13:15:52.607'},'seg_psuma','In corso')
GO

IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '2')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-05-24 13:15:52.687'},cu = 'seg_psuma',description = 'Concluso',lt = {ts '2021-05-24 13:15:52.687'},lu = 'seg_psuma',title = 'Concluso' WHERE idperfprogettostatus = '2'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('2','S',{ts '2021-05-24 13:15:52.687'},'seg_psuma','Concluso',{ts '2021-05-24 13:15:52.687'},'seg_psuma','Concluso')
GO

IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '3')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-05-24 13:15:52.763'},cu = 'seg_psuma',description = 'Sospeso',lt = {ts '2021-05-24 13:15:52.763'},lu = 'seg_psuma',title = 'Sospeso' WHERE idperfprogettostatus = '3'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('3','S',{ts '2021-05-24 13:15:52.763'},'seg_psuma','Sospeso',{ts '2021-05-24 13:15:52.763'},'seg_psuma','Sospeso')
GO

IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '4')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-07-23 15:32:51.940'},cu = 'ferdinando.giannetti{SEGADM}',description = 'Da utilizzare come primo status in fase di ideazione del progetto strategico.',lt = {ts '2021-07-23 15:33:26.530'},lu = 'ferdinando.giannetti{SEGADM}',title = 'In bozza' WHERE idperfprogettostatus = '4'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('4','S',{ts '2021-07-23 15:32:51.940'},'ferdinando.giannetti{SEGADM}','Da utilizzare come primo status in fase di ideazione del progetto strategico.',{ts '2021-07-23 15:33:26.530'},'ferdinando.giannetti{SEGADM}','In bozza')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfprogettostatus')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2021-05-24 16:58:40.293'},lu = 'assistenza',title = 'Stati dei progetti' WHERE tablename = 'perfprogettostatus'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfprogettostatus',null,null,'N',{ts '2021-05-24 16:58:40.293'},'assistenza','Stati dei progetti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attivo',kind = 'S',lt = {ts '2021-05-24 16:59:14.313'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','perfprogettostatus','1',null,null,'Attivo','S',{ts '2021-05-24 16:59:14.313'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 16:58:44.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfprogettostatus','8',null,null,null,'S',{ts '2021-05-24 16:58:44.807'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 16:58:44.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfprogettostatus','64',null,null,null,'S',{ts '2021-05-24 16:58:44.807'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-05-24 16:59:14.313'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfprogettostatus','-1',null,null,'Descrizione','S',{ts '2021-05-24 16:59:14.313'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettostatus' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 16:58:44.807'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettostatus' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettostatus','perfprogettostatus','4',null,null,null,'S',{ts '2021-05-24 16:58:44.807'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 16:58:44.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfprogettostatus','8',null,null,null,'S',{ts '2021-05-24 16:58:44.807'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 16:58:44.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfprogettostatus','64',null,null,null,'S',{ts '2021-05-24 16:58:44.807'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfprogettostatus')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2021-05-24 16:59:14.313'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfprogettostatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfprogettostatus','1024',null,null,'Stato','S',{ts '2021-05-24 16:59:14.313'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

