
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


-- CREAZIONE TABELLA partnerkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[partnerkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[partnerkind] (
idpartnerkind int NOT NULL,
active char(1) NULL,
description varchar(max) NULL,
sortcode int NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkpartnerkind PRIMARY KEY (idpartnerkind
)
)
END
GO

-- VERIFICA STRUTTURA partnerkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'idpartnerkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD idpartnerkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('partnerkind') and col.name = 'idpartnerkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [partnerkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'partnerkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [partnerkind] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [partnerkind] ALTER COLUMN title varchar(2048) NULL
GO

-- VERIFICA DI partnerkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'partnerkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','partnerkind','int','assistenza','idpartnerkind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkind','char(1)','assistenza','active','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkind','varchar(max)','assistenza','description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkind','int','assistenza','sortcode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','partnerkind','varchar(2048)','assistenza','title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI partnerkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'partnerkind')
UPDATE customobject set isreal = 'S' where objectname = 'partnerkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('partnerkind', 'S')
GO

-- GENERAZIONE DATI PER partnerkind --
IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '1')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '1',title = 'Partners - Associated Partners (AP)' WHERE idpartnerkind = '1'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('1','S',null,'1','Partners - Associated Partners (AP)')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '2')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '2',title = 'Soggetto terzo - Third parties giving inkind contributions to the action (TP) ' WHERE idpartnerkind = '2'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('2','S',null,'2','Soggetto terzo - Third parties giving inkind contributions to the action (TP) ')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '3')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '3',title = 'Soggetto attuatore' WHERE idpartnerkind = '3'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('3','S',null,'3','Soggetto attuatore')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '4')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '4',title = 'Coordinatore - Coordinator (COO)' WHERE idpartnerkind = '4'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('4','S',null,'4','Coordinatore - Coordinator (COO)')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '5')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '5',title = 'Beneficiari - Beneficiaries (BEN)' WHERE idpartnerkind = '5'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('5','S',null,'5','Beneficiari - Beneficiaries (BEN)')
GO

IF exists(SELECT * FROM [partnerkind] WHERE idpartnerkind = '6')
UPDATE [partnerkind] SET active = 'S',description = null,sortcode = '6',title = 'Entità affiliate - Affiliated entities (AE)' WHERE idpartnerkind = '6'
ELSE
INSERT INTO [partnerkind] (idpartnerkind,active,description,sortcode,title) VALUES ('6','S',null,'6','Entità affiliate - Affiliated entities (AE)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'partnerkind')
UPDATE [tabledescr] SET description = 'Tipi di partnership',idapplication = '3',isdbo = 'S',lt = {ts '2021-06-18 13:08:50.613'},lu = 'assistenza',title = 'Tipi di partnership' WHERE tablename = 'partnerkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('partnerkind','Tipi di partnership','3','S',{ts '2021-06-18 13:08:50.613'},'assistenza','Tipi di partnership')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.913'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','partnerkind','1',null,null,null,'S',{ts '2021-06-18 13:08:53.913'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','partnerkind','-1',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpartnerkind' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpartnerkind' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpartnerkind','partnerkind','4',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','partnerkind','4',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','partnerkind','2048',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

