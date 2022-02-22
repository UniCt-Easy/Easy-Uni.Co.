
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


-- CREAZIONE TABELLA protocollorifkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollorifkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[protocollorifkind] (
idprotocollorifkind int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkprotocollorifkind PRIMARY KEY (idprotocollorifkind
)
)
END
GO

-- VERIFICA STRUTTURA protocollorifkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollorifkind' and C.name = 'idprotocollorifkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollorifkind] ADD idprotocollorifkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollorifkind') and col.name = 'idprotocollorifkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollorifkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollorifkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollorifkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollorifkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollorifkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollorifkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollorifkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollorifkind] ADD description varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollorifkind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollorifkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollorifkind] ALTER COLUMN description varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollorifkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollorifkind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [protocollorifkind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollorifkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollorifkind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollorifkind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollorifkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollorifkind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollorifkind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollorifkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollorifkind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollorifkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollorifkind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollorifkind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollorifkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollorifkind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI protocollorifkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'protocollorifkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollorifkind','int','ASSISTENZA','idprotocollorifkind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollorifkind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollorifkind','varchar(256)','ASSISTENZA','description','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollorifkind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','protocollorifkind','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollorifkind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','protocollorifkind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI protocollorifkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'protocollorifkind')
UPDATE customobject set isreal = 'S' where objectname = 'protocollorifkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('protocollorifkind', 'S')
GO

-- GENERAZIONE DATI PER protocollorifkind --
IF exists(SELECT * FROM [protocollorifkind] WHERE idprotocollorifkind = '1')
UPDATE [protocollorifkind] SET active = 'S',description = 'Riferimento esterno a un documento informatico comunque reperibile per altra via (es. in un repository condiviso)',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Telematico' WHERE idprotocollorifkind = '1'
ELSE
INSERT INTO [protocollorifkind] (idprotocollorifkind,active,description,lt,lu,sortcode,title) VALUES ('1','S','Riferimento esterno a un documento informatico comunque reperibile per altra via (es. in un repository condiviso)',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Telematico')
GO

IF exists(SELECT * FROM [protocollorifkind] WHERE idprotocollorifkind = '2')
UPDATE [protocollorifkind] SET active = 'S',description = 'Riferimento esterno a un documento cartaceo trasmesso per via tradizionale ',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Cartaceo' WHERE idprotocollorifkind = '2'
ELSE
INSERT INTO [protocollorifkind] (idprotocollorifkind,active,description,lt,lu,sortcode,title) VALUES ('2','S','Riferimento esterno a un documento cartaceo trasmesso per via tradizionale ',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Cartaceo')
GO

IF exists(SELECT * FROM [protocollorifkind] WHERE idprotocollorifkind = '3')
UPDATE [protocollorifkind] SET active = 'S',description = 'Riferimento a un documento informatico contenuto nella struttura MIME che costituisce il messaggio',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'MIME' WHERE idprotocollorifkind = '3'
ELSE
INSERT INTO [protocollorifkind] (idprotocollorifkind,active,description,lt,lu,sortcode,title) VALUES ('3','S','Riferimento a un documento informatico contenuto nella struttura MIME che costituisce il messaggio',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','MIME')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'protocollorifkind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle tipologie di documento protocollabile',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-22 11:13:16.977'},lu = 'assistenza',title = 'Tipologie di documento protocollabile' WHERE tablename = 'protocollorifkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('protocollorifkind','VOCABOLARIO delle tipologie di documento protocollabile','3','S',{ts '2021-02-22 11:13:16.977'},'assistenza','Tipologie di documento protocollabile')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'protocollorifkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:07:01.217'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','protocollorifkind','1',null,null,null,'S',{ts '2018-07-18 16:07:01.217'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'protocollorifkind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:07:01.217'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','protocollorifkind','256',null,null,null,'S',{ts '2018-07-18 16:07:01.217'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprotocollorifkind' AND tablename = 'protocollorifkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:07:01.217'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprotocollorifkind' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprotocollorifkind','protocollorifkind','4',null,null,null,'S',{ts '2018-07-18 16:07:01.217'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'protocollorifkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:07:01.217'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','protocollorifkind','4',null,null,null,'S',{ts '2018-07-18 16:07:01.217'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'protocollorifkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:07:01.217'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','protocollorifkind','50',null,null,null,'S',{ts '2018-07-18 16:07:01.217'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3229')
UPDATE [relation] SET childtable = 'protocollorifkind',description = 'protocollo che descrive',lt = {ts '2018-07-18 16:07:24.947'},lu = 'assistenza',parenttable = 'protocollo',title = null WHERE idrelation = '3229'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3229','protocollorifkind','protocollo che descrive',{ts '2018-07-18 16:07:24.947'},'assistenza','protocollo',null)
GO

-- FINE GENERAZIONE SCRIPT --

