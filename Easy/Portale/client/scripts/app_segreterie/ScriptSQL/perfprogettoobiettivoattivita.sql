
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


-- CREAZIONE TABELLA perfprogettoobiettivoattivita --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivoattivita]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettoobiettivoattivita] (
idperfprogetto int NOT NULL,
idperfprogettoobiettivo int NOT NULL,
idperfprogettoobiettivoattivita int NOT NULL,
completamento decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datafineeffettiva datetime NULL,
datafineprevista datetime NULL,
datainizioeffettiva datetime NULL,
datainizioprevista datetime NULL,
description varchar(max) NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridperfprogettoobiettivoattivita int NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfprogettoobiettivoattivita PRIMARY KEY (idperfprogetto,
idperfprogettoobiettivo,
idperfprogettoobiettivoattivita
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettoobiettivoattivita --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idperfprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idperfprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'idperfprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idperfprogettoobiettivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idperfprogettoobiettivo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'idperfprogettoobiettivo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idperfprogettoobiettivoattivita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idperfprogettoobiettivoattivita int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'idperfprogettoobiettivoattivita' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'completamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD completamento decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN completamento decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datafineeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datafineeffettiva datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datafineeffettiva datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datafineprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datafineprevista datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datafineprevista datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datainizioeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datainizioeffettiva datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datainizioeffettiva datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD datainizioprevista datetime NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN datainizioprevista datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettoobiettivoattivita') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettoobiettivoattivita] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'paridperfprogettoobiettivoattivita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD paridperfprogettoobiettivoattivita int NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN paridperfprogettoobiettivoattivita int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettoobiettivoattivita' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettoobiettivoattivita] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfprogettoobiettivoattivita] ALTER COLUMN title varchar(1024) NULL
GO

-- VERIFICA DI perfprogettoobiettivoattivita IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettoobiettivoattivita'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivita','int','assistenza','idperfprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivita','int','assistenza','idperfprogettoobiettivo','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivita','int','assistenza','idperfprogettoobiettivoattivita','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','decimal(19,2)','assistenza','completamento','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivita','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivita','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','datetime','assistenza','datafineeffettiva','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','datetime','assistenza','datafineprevista','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','datetime','assistenza','datainizioeffettiva','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','datetime','assistenza','datainizioprevista','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','varchar(max)','assistenza','description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivita','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivoattivita','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','int','assistenza','paridperfprogettoobiettivoattivita','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivoattivita','varchar(1024)','assistenza','title','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfprogettoobiettivoattivita IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettoobiettivoattivita')
UPDATE customobject set isreal = 'S' where objectname = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettoobiettivoattivita', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfprogettoobiettivoattivita')
UPDATE [tabledescr] SET description = null,idapplication = null,isdbo = 'N',lt = {ts '2021-05-27 10:57:02.477'},lu = 'assistenza',title = 'Attività' WHERE tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfprogettoobiettivoattivita',null,null,'N',{ts '2021-05-27 10:57:02.477'},'assistenza','Attività')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'completamento' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento',kind = 'S',lt = {ts '2021-05-27 11:04:45.397'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'completamento' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('completamento','perfprogettoobiettivoattivita','9','19','2','Percentuale di completamento','S',{ts '2021-05-27 11:04:45.397'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 10:57:06.517'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfprogettoobiettivoattivita','8',null,null,null,'S',{ts '2021-05-27 10:57:06.517'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 10:57:06.517'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfprogettoobiettivoattivita','64',null,null,null,'S',{ts '2021-05-27 10:57:06.517'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineeffettiva' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data fine effettiva',kind = 'S',lt = {ts '2021-05-27 11:04:45.397'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datafineeffettiva' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineeffettiva','perfprogettoobiettivoattivita','8',null,null,'Data fine effettiva','S',{ts '2021-05-27 11:04:45.397'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineprevista' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data fine prevista',kind = 'S',lt = {ts '2021-07-30 12:38:46.660'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datafineprevista' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineprevista','perfprogettoobiettivoattivita','8',null,null,'Data fine prevista','S',{ts '2021-07-30 12:38:46.660'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioeffettiva' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data inizio effettiva',kind = 'S',lt = {ts '2021-05-27 11:04:45.397'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datainizioeffettiva' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioeffettiva','perfprogettoobiettivoattivita','8',null,null,'Data inizio effettiva','S',{ts '2021-05-27 11:04:45.397'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2021-07-30 12:38:46.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','perfprogettoobiettivoattivita','8',null,null,'Data inizio prevista','S',{ts '2021-07-30 12:38:46.663'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-05-27 11:04:45.397'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfprogettoobiettivoattivita','-1',null,null,'Descrizione','S',{ts '2021-05-27 11:04:45.397'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-15 18:16:20.757'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogetto','perfprogettoobiettivoattivita','4',null,null,null,'S',{ts '2021-07-15 18:16:20.757'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettoobiettivo' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-15 18:16:20.757'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettoobiettivo' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettoobiettivo','perfprogettoobiettivoattivita','4',null,null,null,'S',{ts '2021-07-15 18:16:20.757'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettoobiettivoattivita' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 10:57:06.520'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettoobiettivoattivita' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettoobiettivoattivita','perfprogettoobiettivoattivita','4',null,null,null,'S',{ts '2021-05-27 10:57:06.520'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Chi svolge l’attività',kind = 'S',lt = {ts '2021-07-23 13:02:40.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','perfprogettoobiettivoattivita','4',null,null,'Chi svolge l’attività','S',{ts '2021-07-23 13:02:40.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 10:57:06.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfprogettoobiettivoattivita','8',null,null,null,'S',{ts '2021-05-27 10:57:06.520'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-27 10:57:06.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfprogettoobiettivoattivita','64',null,null,null,'S',{ts '2021-05-27 10:57:06.520'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridperfprogettoobiettivoattivita' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attività madre',kind = 'S',lt = {ts '2021-06-16 16:51:35.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'paridperfprogettoobiettivoattivita' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridperfprogettoobiettivoattivita','perfprogettoobiettivoattivita','4',null,null,'Attività madre','S',{ts '2021-06-16 16:51:35.827'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfprogettoobiettivoattivita')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2021-05-27 11:04:45.397'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfprogettoobiettivoattivita'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfprogettoobiettivoattivita','1024',null,null,'Titolo','S',{ts '2021-05-27 11:04:45.397'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

