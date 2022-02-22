
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
-- CREAZIONE TABELLA esonero_carriera --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[esonero_carriera]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[esonero_carriera] (
idesonero int NOT NULL,
annofcmax int NULL,
annofcmin int NULL,
annoiscrmax int NULL,
annoiscrmin int NULL,
cfaaprecmax decimal(9,2) NULL,
cfaaprecmin decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
parttime char(1) NULL,
tutticfaaprec char(1) NULL,
 CONSTRAINT xpkesonero_carriera PRIMARY KEY (idesonero
)
)
END
GO

-- VERIFICA STRUTTURA esonero_carriera --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'idesonero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD idesonero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('esonero_carriera') and col.name = 'idesonero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [esonero_carriera] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'annofcmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD annofcmax int NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN annofcmax int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'annofcmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD annofcmin int NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN annofcmin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'annoiscrmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD annoiscrmax int NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN annoiscrmax int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'annoiscrmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD annoiscrmin int NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN annoiscrmin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'cfaaprecmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD cfaaprecmax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN cfaaprecmax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'cfaaprecmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD cfaaprecmin decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN cfaaprecmin decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('esonero_carriera') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [esonero_carriera] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('esonero_carriera') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [esonero_carriera] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('esonero_carriera') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [esonero_carriera] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('esonero_carriera') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [esonero_carriera] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD parttime char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN parttime char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_carriera' and C.name = 'tutticfaaprec' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_carriera] ADD tutticfaaprec char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_carriera] ALTER COLUMN tutticfaaprec char(1) NULL
GO

-- VERIFICA DI esonero_carriera IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'esonero_carriera'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonero_carriera','int','ASSISTENZA','idesonero','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','int','ASSISTENZA','annofcmax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','int','ASSISTENZA','annofcmin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','int','ASSISTENZA','annoiscrmax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','int','ASSISTENZA','annoiscrmin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','decimal(9,2)','ASSISTENZA','cfaaprecmax','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','decimal(9,2)','ASSISTENZA','cfaaprecmin','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonero_carriera','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonero_carriera','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonero_carriera','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonero_carriera','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','char(1)','ASSISTENZA','parttime','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_carriera','char(1)','ASSISTENZA','tutticfaaprec','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI esonero_carriera IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'esonero_carriera')
UPDATE customobject set isreal = 'S' where objectname = 'esonero_carriera'
ELSE
INSERT INTO customobject (objectname, isreal) values('esonero_carriera', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'esonero_carriera')
UPDATE [tabledescr] SET description = 'Parte di 2.3.6 Esoneri
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 17:57:03.130'},lu = 'assistenza',title = 'Parte di 2.3.6 Esoneri' WHERE tablename = 'esonero_carriera'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('esonero_carriera','Parte di 2.3.6 Esoneri
',null,'N',{ts '2018-07-27 17:57:03.130'},'assistenza','Parte di 2.3.6 Esoneri')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'annofcmax' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno fuori corso massimo',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annofcmax' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annofcmax','esonero_carriera','4',null,null,'Anno fuori corso massimo','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annofcmin' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno fuori corso minimo',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annofcmin' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annofcmin','esonero_carriera','4',null,null,'Anno fuori corso minimo','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annoiscrmax' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno iscrizione massimo',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annoiscrmax' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annoiscrmax','esonero_carriera','4',null,null,'Anno iscrizione massimo','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annoiscrmin' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno iscrizione minimo',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annoiscrmin' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annoiscrmin','esonero_carriera','4',null,null,'Anno iscrizione minimo','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfaaprecmax' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti massimi anno precedente',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfaaprecmax' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfaaprecmax','esonero_carriera','5','9','2','Crediti massimi anno precedente','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfaaprecmin' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti minimi anno precedente',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfaaprecmin' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfaaprecmin','esonero_carriera','5','9','2','Crediti minimi anno precedente','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:57:04.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','esonero_carriera','8',null,null,null,'S',{ts '2018-07-27 17:57:04.240'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:57:04.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','esonero_carriera','64',null,null,null,'S',{ts '2018-07-27 17:57:04.240'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idesonero' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:57:04.240'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idesonero' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idesonero','esonero_carriera','4',null,null,null,'S',{ts '2018-07-27 17:57:04.240'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:57:04.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','esonero_carriera','8',null,null,null,'S',{ts '2018-07-27 17:57:04.240'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:57:04.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','esonero_carriera','64',null,null,null,'S',{ts '2018-07-27 17:57:04.240'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parttime' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Part-time',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'parttime' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parttime','esonero_carriera','1',null,null,'Part-time','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tutticfaaprec' AND tablename = 'esonero_carriera')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Conseguiti tutti i crediti dell''anno precedente',kind = 'S',lt = {ts '2020-01-07 11:12:02.927'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tutticfaaprec' AND tablename = 'esonero_carriera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tutticfaaprec','esonero_carriera','1',null,null,'Conseguiti tutti i crediti dell''anno precedente','S',{ts '2020-01-07 11:12:02.927'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3413')
UPDATE [relation] SET childtable = 'esonero_carriera',description = 'dati di base dell''esonero',lt = {ts '2018-07-27 17:57:54.130'},lu = 'assistenza',parenttable = 'esonero',title = null WHERE idrelation = '3413'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3413','esonero_carriera','dati di base dell''esonero',{ts '2018-07-27 17:57:54.130'},'assistenza','esonero',null)
GO

-- FINE GENERAZIONE SCRIPT --

