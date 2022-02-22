
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


-- CREAZIONE TABELLA perfinterazionekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfinterazionekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfinterazionekind] (
idperfinterazionekind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkperfinterazionekind PRIMARY KEY (idperfinterazionekind
)
)
END
GO

-- VERIFICA STRUTTURA perfinterazionekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'idperfinterazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD idperfinterazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazionekind') and col.name = 'idperfinterazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazionekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN title varchar(2048) NULL
GO

-- VERIFICA DI perfinterazionekind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfinterazionekind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfinterazionekind','int','assistenza','idperfinterazionekind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazionekind','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazionekind','varchar(64)','assistenza','cu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazionekind','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazionekind','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazionekind','varchar(2048)','assistenza','title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfinterazionekind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfinterazionekind')
UPDATE customobject set isreal = 'S' where objectname = 'perfinterazionekind'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfinterazionekind', 'S')
GO

-- GENERAZIONE DATI PER perfinterazionekind --
IF exists(SELECT * FROM [perfinterazionekind] WHERE idperfinterazionekind = '1')
UPDATE [perfinterazionekind] SET ct = {ts '2021-07-23 12:58:47.030'},cu = 'seg_psuma{SEGADM}',lt = {ts '2021-07-23 12:58:47.030'},lu = 'seg_psuma{SEGADM}',title = 'Colloquio' WHERE idperfinterazionekind = '1'
ELSE
INSERT INTO [perfinterazionekind] (idperfinterazionekind,ct,cu,lt,lu,title) VALUES ('1',{ts '2021-07-23 12:58:47.030'},'seg_psuma{SEGADM}',{ts '2021-07-23 12:58:47.030'},'seg_psuma{SEGADM}','Colloquio')
GO

IF exists(SELECT * FROM [perfinterazionekind] WHERE idperfinterazionekind = '2')
UPDATE [perfinterazionekind] SET ct = {ts '2021-07-23 12:59:01.033'},cu = 'seg_psuma{SEGADM}',lt = {ts '2021-07-23 12:59:01.033'},lu = 'seg_psuma{SEGADM}',title = 'Risposta' WHERE idperfinterazionekind = '2'
ELSE
INSERT INTO [perfinterazionekind] (idperfinterazionekind,ct,cu,lt,lu,title) VALUES ('2',{ts '2021-07-23 12:59:01.033'},'seg_psuma{SEGADM}',{ts '2021-07-23 12:59:01.033'},'seg_psuma{SEGADM}','Risposta')
GO

IF exists(SELECT * FROM [perfinterazionekind] WHERE idperfinterazionekind = '3')
UPDATE [perfinterazionekind] SET ct = {ts '2021-10-01 15:33:45.147'},cu = 'seg_psuma{PERFADM}',lt = {ts '2021-10-01 15:33:45.147'},lu = 'seg_psuma{PERFADM}',title = 'Riunione' WHERE idperfinterazionekind = '3'
ELSE
INSERT INTO [perfinterazionekind] (idperfinterazionekind,ct,cu,lt,lu,title) VALUES ('3',{ts '2021-10-01 15:33:45.147'},'seg_psuma{PERFADM}',{ts '2021-10-01 15:33:45.147'},'seg_psuma{PERFADM}','Riunione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfinterazionekind')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2021-07-23 12:15:32.313'},lu = 'assistenza',title = 'Tipo di interazione' WHERE tablename = 'perfinterazionekind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfinterazionekind',null,null,'N',{ts '2021-07-23 12:15:32.313'},'assistenza','Tipo di interazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfinterazionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-23 12:15:34.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfinterazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfinterazionekind','8',null,null,null,'S',{ts '2021-07-23 12:15:34.717'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfinterazionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-23 12:15:34.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfinterazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfinterazionekind','64',null,null,null,'S',{ts '2021-07-23 12:15:34.717'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfinterazionekind' AND tablename = 'perfinterazionekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Chiave',kind = 'S',lt = {ts '2021-07-23 12:22:18.067'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfinterazionekind' AND tablename = 'perfinterazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfinterazionekind','perfinterazionekind','4',null,null,'Chiave','S',{ts '2021-07-23 12:22:18.067'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfinterazionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-23 12:15:34.720'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfinterazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfinterazionekind','8',null,null,null,'S',{ts '2021-07-23 12:15:34.720'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfinterazionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-23 12:15:34.720'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfinterazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfinterazionekind','64',null,null,null,'S',{ts '2021-07-23 12:15:34.720'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfinterazionekind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2021-07-23 12:22:18.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfinterazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfinterazionekind','2048',null,null,'Titolo','S',{ts '2021-07-23 12:22:18.067'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

