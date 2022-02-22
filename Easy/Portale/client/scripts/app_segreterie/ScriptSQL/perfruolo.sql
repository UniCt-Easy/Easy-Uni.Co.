
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


-- CREAZIONE TABELLA perfruolo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfruolo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfruolo] (
idperfruolo varchar(50) NOT NULL,
aggiorna char(1) NULL,
crea char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
leggi char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oper char(1) NULL,
valuta char(1) NULL,
 CONSTRAINT xpkperfruolo PRIMARY KEY (idperfruolo
)
)
END
GO

-- VERIFICA STRUTTURA perfruolo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD idperfruolo varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'idperfruolo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'aggiorna' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD aggiorna char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN aggiorna char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'crea' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD crea char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN crea char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'leggi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD leggi char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN leggi char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'oper' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD oper char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN oper char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'valuta' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD valuta char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN valuta char(1) NULL
GO

-- VERIFICA DI perfruolo IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfruolo'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfruolo','varchar(50)','assistenza','idperfruolo','50','S','varchar','System.String','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfruolo','char(1)','Generator','aggiorna','1','N','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfruolo','char(1)','Generator','crea','1','N','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfruolo','datetime','Generator','ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfruolo','varchar(64)','Generator','cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfruolo','char(1)','Generator','leggi','1','N','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfruolo','datetime','Generator','lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfruolo','varchar(64)','Generator','lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfruolo','char(1)','Generator','oper','1','N','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfruolo','char(1)','Generator','valuta','1','N','char','System.String','','','','','N')
GO

-- VERIFICA DI perfruolo IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfruolo')
UPDATE customobject set isreal = 'S' where objectname = 'perfruolo'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfruolo', 'S')
GO

-- GENERAZIONE DATI PER perfruolo --
IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Approvatore')
UPDATE [perfruolo] SET aggiorna = null,crea = null,ct = {ts '2022-02-08 12:58:04.023'},cu = 'seg_psuma{SEGADM}',leggi = null,lt = {ts '2022-02-08 12:58:04.023'},lu = 'seg_psuma{SEGADM}',oper = null,valuta = null WHERE idperfruolo = 'Approvatore'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Approvatore',null,null,{ts '2022-02-08 12:58:04.023'},'seg_psuma{SEGADM}',null,{ts '2022-02-08 12:58:04.023'},'seg_psuma{SEGADM}',null,null)
GO

IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Responsabile')
UPDATE [perfruolo] SET aggiorna = 'S',crea = null,ct = {ts '2022-02-08 12:58:04.103'},cu = 'seg_psuma{SEGADM}',leggi = 'S',lt = {ts '2022-02-16 11:12:34.720'},lu = 'prima.div.1{PERFADM}',oper = null,valuta = null WHERE idperfruolo = 'Responsabile'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Responsabile','S',null,{ts '2022-02-08 12:58:04.103'},'seg_psuma{SEGADM}','S',{ts '2022-02-16 11:12:34.720'},'prima.div.1{PERFADM}',null,null)
GO

IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Valutato')
UPDATE [perfruolo] SET aggiorna = null,crea = null,ct = {ts '2022-02-08 12:58:04.107'},cu = 'seg_psuma{SEGADM}',leggi = null,lt = {ts '2022-02-08 12:58:04.107'},lu = 'seg_psuma{SEGADM}',oper = null,valuta = null WHERE idperfruolo = 'Valutato'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Valutato',null,null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,null)
GO

IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Valutatore')
UPDATE [perfruolo] SET aggiorna = null,crea = null,ct = {ts '2022-02-08 12:58:04.107'},cu = 'seg_psuma{SEGADM}',leggi = null,lt = {ts '2022-02-08 12:58:04.107'},lu = 'seg_psuma{SEGADM}',oper = null,valuta = null WHERE idperfruolo = 'Valutatore'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Valutatore',null,null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,null)
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfruolo')
UPDATE [tabledescr] SET description = 'Tipologie ruoli',idapplication = '2',isdbo = 'S',lt = {ts '2022-02-16 09:43:42.593'},lu = 'Generator',title = 'Tipologie ruoli' WHERE tablename = 'perfruolo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfruolo','Tipologie ruoli','2','S',{ts '2022-02-16 09:43:42.593'},'Generator','Tipologie ruoli')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aggiorna' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-10 15:42:10.013'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'aggiorna' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aggiorna','perfruolo','1',null,null,'','S',{ts '2022-02-10 15:42:10.013'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'crea' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-10 15:42:10.013'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'crea' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('crea','perfruolo','1',null,null,'','S',{ts '2022-02-10 15:42:10.013'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'create' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:38:54.387'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'create' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('create','perfruolo','1',null,null,'','S',{ts '2022-02-08 12:38:54.387'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:58:25.700'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfruolo','8',null,null,'','S',{ts '2022-02-08 12:58:25.700'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:58:25.700'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfruolo','64',null,null,'','S',{ts '2022-02-08 12:58:25.700'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-07 12:35:03.830'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo','perfruolo','50',null,null,null,'S',{ts '2021-06-07 12:35:03.830'},'assistenza','S','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'leggi' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-10 15:42:10.013'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'leggi' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('leggi','perfruolo','1',null,null,'','S',{ts '2022-02-10 15:42:10.013'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:58:25.700'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfruolo','8',null,null,'','S',{ts '2022-02-08 12:58:25.700'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:58:25.700'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfruolo','64',null,null,'','S',{ts '2022-02-08 12:58:25.700'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oper' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:38:54.387'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'oper' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oper','perfruolo','1',null,null,'','S',{ts '2022-02-08 12:38:54.387'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'read' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:38:54.387'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'read' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('read','perfruolo','1',null,null,'','S',{ts '2022-02-08 12:38:54.387'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'update' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-08 12:38:54.387'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'update' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('update','perfruolo','1',null,null,'','S',{ts '2022-02-08 12:38:54.387'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valuta' AND tablename = 'perfruolo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:43:42.600'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'valuta' AND tablename = 'perfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valuta','perfruolo','1',null,null,'','S',{ts '2022-02-16 09:43:42.600'},'Generator','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

