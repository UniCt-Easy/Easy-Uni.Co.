
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


-- CREAZIONE TABELLA classescuolacaratteristica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolacaratteristica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classescuolacaratteristica] (
idclassescuolacaratteristica int NOT NULL,
cf decimal(9,2) NULL,
cfmax decimal(9,2) NULL,
cfmin decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idambitoareadisc int NULL,
idclassescuola int NOT NULL,
idsasd int NULL,
idsasdgruppo int NULL,
idtipoattform int NULL,
idtipoattform_2 int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obblig char(1) NOT NULL,
profess char(1) NOT NULL,
 CONSTRAINT xpkclassescuolacaratteristica PRIMARY KEY (idclassescuolacaratteristica
)
)
END
GO

-- VERIFICA STRUTTURA classescuolacaratteristica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idclassescuolacaratteristica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idclassescuolacaratteristica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'idclassescuolacaratteristica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cf decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cf decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cfmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cfmax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cfmax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cfmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cfmin decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cfmin decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idambitoareadisc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idambitoareadisc int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idambitoareadisc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idclassescuola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idclassescuola int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'idclassescuola' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idclassescuola int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idsasdgruppo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idsasdgruppo int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idsasdgruppo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idtipoattform int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idtipoattform int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'idtipoattform_2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD idtipoattform_2 int NULL 
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN idtipoattform_2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'obblig' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD obblig char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'obblig' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN obblig char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolacaratteristica' and C.name = 'profess' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolacaratteristica] ADD profess char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolacaratteristica') and col.name = 'profess' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolacaratteristica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuolacaratteristica] ALTER COLUMN profess char(1) NOT NULL
GO

-- VERIFICA DI classescuolacaratteristica IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'classescuolacaratteristica'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','int','ASSISTENZA','idclassescuolacaratteristica','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','decimal(9,2)','ASSISTENZA','cf','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','decimal(9,2)','ASSISTENZA','cfmax','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','decimal(9,2)','ASSISTENZA','cfmin','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','int','ASSISTENZA','idambitoareadisc','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','int','ASSISTENZA','idclassescuola','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','int','ASSISTENZA','idsasdgruppo','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','int','ASSISTENZA','idtipoattform','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','classescuolacaratteristica','int','ASSISTENZA','idtipoattform_2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','char(1)','ASSISTENZA','obblig','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','classescuolacaratteristica','char(1)','ASSISTENZA','profess','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI classescuolacaratteristica IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'classescuolacaratteristica')
UPDATE customobject set isreal = 'S' where objectname = 'classescuolacaratteristica'
ELSE
INSERT INTO customobject (objectname, isreal) values('classescuolacaratteristica', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'classescuolacaratteristica')
UPDATE [tabledescr] SET description = 'Caratteristiche della classe o scuola (solitamente dei minimi o dei totali)',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 15:57:29.160'},lu = 'assistenza',title = 'Caratteristiche della classe o scuola (solitamente dei minimi o dei totali)' WHERE tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('classescuolacaratteristica','Caratteristiche della classe o scuola (solitamente dei minimi o dei totali)',null,'N',{ts '2018-07-19 15:57:29.160'},'assistenza','Caratteristiche della classe o scuola (solitamente dei minimi o dei totali)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cf' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','classescuolacaratteristica','5','9','2','Crediti','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfmax' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti max',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfmax' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfmax','classescuolacaratteristica','5','9','2','Crediti max','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfmin' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti min',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfmin' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfmin','classescuolacaratteristica','5','9','2','Crediti min','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:57:31.713'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','classescuolacaratteristica','8',null,null,null,'S',{ts '2018-07-19 15:57:31.713'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:57:31.713'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','classescuolacaratteristica','64',null,null,null,'S',{ts '2018-07-19 15:57:31.713'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idambitoareadisc' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ambito o area disciplinare',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idambitoareadisc' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idambitoareadisc','classescuolacaratteristica','4',null,null,'Ambito o area disciplinare','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcaratteristica' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:57:31.713'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcaratteristica' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcaratteristica','classescuolacaratteristica','4',null,null,null,'S',{ts '2018-07-19 15:57:31.713'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuola' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-03-28 09:26:59.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassescuola' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuola','classescuolacaratteristica','4',null,null,null,'S',{ts '2019-03-28 09:26:59.387'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuolacaratteristica' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-03-28 09:26:59.383'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassescuolacaratteristica' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuolacaratteristica','classescuolacaratteristica','4',null,null,null,'S',{ts '2019-03-28 09:26:59.383'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','classescuolacaratteristica','4',null,null,'SASD','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasdgruppo' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Gruppo',kind = 'S',lt = {ts '2020-05-15 12:20:54.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasdgruppo' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasdgruppo','classescuolacaratteristica','4',null,null,'Gruppo','S',{ts '2020-05-15 12:20:54.907'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipoattform' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di attività formativa',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipoattform' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipoattform','classescuolacaratteristica','4',null,null,'Tipo di attività formativa','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipoattform_2' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo della seconda attività formativa',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipoattform_2' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipoattform_2','classescuolacaratteristica','4',null,null,'Tipo della seconda attività formativa','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:57:31.713'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','classescuolacaratteristica','8',null,null,null,'S',{ts '2018-07-19 15:57:31.713'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:57:31.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','classescuolacaratteristica','64',null,null,null,'S',{ts '2018-07-19 15:57:31.717'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obblig' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Obbligatorio',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'obblig' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obblig','classescuolacaratteristica','1',null,null,'Obbligatorio','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'profess' AND tablename = 'classescuolacaratteristica')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Professionalizzante',kind = 'S',lt = {ts '2019-03-28 09:29:34.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'profess' AND tablename = 'classescuolacaratteristica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('profess','classescuolacaratteristica','1',null,null,'Professionalizzante','S',{ts '2019-03-28 09:29:34.610'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3277')
UPDATE [relation] SET childtable = 'classescuolacaratteristica',description = 'classe di laurea o scuola di diploma che si sta definendo',lt = {ts '2018-07-19 15:59:23.943'},lu = 'assistenza',parenttable = 'classescuola',title = null WHERE idrelation = '3277'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3277','classescuolacaratteristica','classe di laurea o scuola di diploma che si sta definendo',{ts '2018-07-19 15:59:23.943'},'assistenza','classescuola',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3278')
UPDATE [relation] SET childtable = 'classescuolacaratteristica',description = 'caratteristica che si sta attribuendo alla classe di laurea o scuola di diploma',lt = {ts '2018-07-19 15:59:23.970'},lu = 'assistenza',parenttable = 'caratteristica',title = null WHERE idrelation = '3278'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3278','classescuolacaratteristica','caratteristica che si sta attribuendo alla classe di laurea o scuola di diploma',{ts '2018-07-19 15:59:23.970'},'assistenza','caratteristica',null)
GO

-- FINE GENERAZIONE SCRIPT --

