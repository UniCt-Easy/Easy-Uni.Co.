
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
-- CREAZIONE TABELLA inquadramento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[inquadramento] (
idinquadramento int NOT NULL,
idcontrattokind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkinquadramento PRIMARY KEY (idinquadramento,
idcontrattokind
)
)
END
GO

-- VERIFICA STRUTTURA inquadramento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD idinquadramento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'idinquadramento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('inquadramento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [inquadramento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inquadramento' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inquadramento] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [inquadramento] ALTER COLUMN title varchar(2048) NULL
GO

-- VERIFICA DI inquadramento IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'inquadramento'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','int','ASSISTENZA','idinquadramento','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','inquadramento','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','inquadramento','varchar(2048)','ASSISTENZA','title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI inquadramento IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'inquadramento')
UPDATE customobject set isreal = 'S' where objectname = 'inquadramento'
ELSE
INSERT INTO customobject (objectname, isreal) values('inquadramento', 'S')
GO

-- GENERAZIONE DATI PER inquadramento --
IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '1')
UPDATE [inquadramento] SET ct = {ts '2020-07-15 10:15:12.097'},cu = 'riccardotest{0001}',lt = {ts '2020-07-15 10:16:15.640'},lu = 'riccardotest{0001}',title = 'I progetto economico - classe 0' WHERE idcontrattokind = '1' AND idinquadramento = '1'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,ct,cu,lt,lu,title) VALUES ('1','1',{ts '2020-07-15 10:15:12.097'},'riccardotest{0001}',{ts '2020-07-15 10:16:15.640'},'riccardotest{0001}','I progetto economico - classe 0')
GO

IF exists(SELECT * FROM [inquadramento] WHERE idcontrattokind = '1' AND idinquadramento = '2')
UPDATE [inquadramento] SET ct = {ts '2020-07-15 10:16:15.543'},cu = 'riccardotest{0001}',lt = {ts '2020-07-15 10:16:15.543'},lu = 'riccardotest{0001}',title = 'I progetto economico - classe I' WHERE idcontrattokind = '1' AND idinquadramento = '2'
ELSE
INSERT INTO [inquadramento] (idcontrattokind,idinquadramento,ct,cu,lt,lu,title) VALUES ('1','2',{ts '2020-07-15 10:16:15.543'},'riccardotest{0001}',{ts '2020-07-15 10:16:15.543'},'riccardotest{0001}','I progetto economico - classe I')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'inquadramento')
UPDATE [tabledescr] SET description = 'Inquadramento',idapplication = null,isdbo = 'N',lt = {ts '2020-07-14 16:13:11.157'},lu = 'assistenza',title = 'Inquadramento' WHERE tablename = 'inquadramento'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('inquadramento','Inquadramento',null,'N',{ts '2020-07-14 16:13:11.157'},'assistenza','Inquadramento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','inquadramento','8',null,null,null,'S',{ts '2020-07-14 16:13:13.993'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','inquadramento','64',null,null,null,'S',{ts '2020-07-14 16:13:13.993'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','inquadramento','4',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinquadramento' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinquadramento' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinquadramento','inquadramento','4',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','inquadramento','8',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','inquadramento','64',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','inquadramento','2048',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

