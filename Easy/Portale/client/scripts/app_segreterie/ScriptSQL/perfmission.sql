
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


-- CREAZIONE TABELLA perfmission --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfmission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfmission] (
idperfmission int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkperfmission PRIMARY KEY (idperfmission
)
)
END
GO

-- VERIFICA STRUTTURA perfmission --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'idperfmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD idperfmission int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfmission') and col.name = 'idperfmission' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfmission] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN title varchar(2048) NULL
GO

-- VERIFICA DI perfmission IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfmission'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfmission','int','assistenza','idperfmission','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfmission','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfmission','varchar(64)','assistenza','cu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfmission','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfmission','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfmission','varchar(2048)','assistenza','title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfmission IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfmission')
UPDATE customobject set isreal = 'S' where objectname = 'perfmission'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfmission', 'S')
GO

-- GENERAZIONE DATI PER perfmission --
IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '1')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:28:09.143'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:28:27.050'},lu = 'seg_fcaprilli{SEGADM}',title = 'Didattica' WHERE idperfmission = '1'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('1',{ts '2021-05-31 14:28:09.143'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:28:27.050'},'seg_fcaprilli{SEGADM}','Didattica')
GO

IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '2')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:28:36.273'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:28:36.273'},lu = 'seg_fcaprilli{SEGADM}',title = 'Ricerca' WHERE idperfmission = '2'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('2',{ts '2021-05-31 14:28:36.273'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:28:36.273'},'seg_fcaprilli{SEGADM}','Ricerca')
GO

IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '3')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:28:51.353'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:28:51.353'},lu = 'seg_fcaprilli{SEGADM}',title = 'Amministrazione e finanza' WHERE idperfmission = '3'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('3',{ts '2021-05-31 14:28:51.353'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:28:51.353'},'seg_fcaprilli{SEGADM}','Amministrazione e finanza')
GO

IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '4')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:29:05.007'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:29:05.007'},lu = 'seg_fcaprilli{SEGADM}',title = 'Trasparenza e anticorruzione' WHERE idperfmission = '4'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('4',{ts '2021-05-31 14:29:05.007'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:29:05.007'},'seg_fcaprilli{SEGADM}','Trasparenza e anticorruzione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfmission')
UPDATE [tabledescr] SET description = 'Missioni istituzionali',idapplication = null,isdbo = 'N',lt = {ts '2021-05-31 12:07:32.343'},lu = 'assistenza',title = 'Missioni istituzionali' WHERE tablename = 'perfmission'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfmission','Missioni istituzionali',null,'N',{ts '2021-05-31 12:07:32.343'},'assistenza','Missioni istituzionali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfmission')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:07:35.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfmission'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfmission','8',null,null,null,'S',{ts '2021-05-31 12:07:35.687'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfmission')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:07:35.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfmission'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfmission','64',null,null,null,'S',{ts '2021-05-31 12:07:35.687'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfmission' AND tablename = 'perfmission')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:07:35.687'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfmission' AND tablename = 'perfmission'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfmission','perfmission','4',null,null,null,'S',{ts '2021-05-31 12:07:35.687'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfmission')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:07:35.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfmission'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfmission','8',null,null,null,'S',{ts '2021-05-31 12:07:35.687'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfmission')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:07:35.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfmission'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfmission','64',null,null,null,'S',{ts '2021-05-31 12:07:35.687'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfmission')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2021-05-31 12:07:55.837'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfmission'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfmission','2048',null,null,'Titolo','S',{ts '2021-05-31 12:07:55.837'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

