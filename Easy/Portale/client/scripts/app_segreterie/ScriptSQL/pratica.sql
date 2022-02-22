
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


-- CREAZIONE TABELLA pratica --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pratica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pratica] (
idpratica int NOT NULL,
idistanza int NOT NULL,
idreg int NOT NULL,
iddidprog int NOT NULL,
idiscrizione int NOT NULL,
idcorsostudio int NOT NULL,
idistanzakind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
iddichiar int NULL,
idiscrizione_from int NULL,
idstatuskind int NOT NULL,
idtitolostudio int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
protanno int NULL,
protnumero int NULL,
 CONSTRAINT xpkpratica PRIMARY KEY (idpratica,
idistanza,
idreg,
iddidprog,
idiscrizione,
idcorsostudio,
idistanzakind
)
)
END
GO

-- VERIFICA STRUTTURA pratica --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idpratica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idpratica int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'idpratica' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idistanza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idistanza int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'idistanza' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idiscrizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idiscrizione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'idiscrizione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idistanzakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idistanzakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'idistanzakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'iddichiar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD iddichiar int NULL 
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN iddichiar int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idiscrizione_from' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idiscrizione_from int NULL 
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN idiscrizione_from int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idstatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idstatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'idstatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN idstatuskind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'idtitolostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD idtitolostudio int NULL 
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN idtitolostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pratica') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pratica] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD protanno int NULL 
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN protanno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pratica' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pratica] ADD protnumero int NULL 
END
ELSE
	ALTER TABLE [pratica] ALTER COLUMN protnumero int NULL
GO

-- VERIFICA DI pratica IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pratica'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','idpratica','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pratica','int','ASSISTENZA','iddichiar','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pratica','int','ASSISTENZA','idiscrizione_from','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','int','ASSISTENZA','idstatuskind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pratica','int','ASSISTENZA','idtitolostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pratica','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pratica','int','ASSISTENZA','protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pratica','int','ASSISTENZA','protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI pratica IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pratica')
UPDATE customobject set isreal = 'S' where objectname = 'pratica'
ELSE
INSERT INTO customobject (objectname, isreal) values('pratica', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'pratica')
UPDATE [tabledescr] SET description = '2.2.12 Pratica di Convalida/Abbreviazione della carriera/Riconoscimento crediti',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 10:31:29.520'},lu = 'assistenza',title = 'Pratica di Convalida/Abbreviazione della carriera/Riconoscimento crediti' WHERE tablename = 'pratica'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('pratica','2.2.12 Pratica di Convalida/Abbreviazione della carriera/Riconoscimento crediti',null,'N',{ts '2018-07-20 10:31:29.520'},'assistenza','Pratica di Convalida/Abbreviazione della carriera/Riconoscimento crediti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:31:30.817'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','pratica','8',null,null,null,'S',{ts '2018-07-20 10:31:30.817'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:31:30.820'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','pratica','64',null,null,null,'S',{ts '2018-07-20 10:31:30.820'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Corso di studio',kind = 'S',lt = {ts '2020-07-01 16:55:37.217'},lu = 'mluisas',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','pratica','4',null,null,'Corso di studio','S',{ts '2020-07-01 16:55:37.217'},'mluisas','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddichiar' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dichiarazione da convalidare',kind = 'S',lt = {ts '2020-04-14 16:07:55.590'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddichiar' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddichiar','pratica','4',null,null,'Dichiarazione da convalidare','S',{ts '2020-04-14 16:07:55.590'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica programmata',kind = 'S',lt = {ts '2020-04-14 16:07:55.590'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','pratica','4',null,null,'Didattica programmata','S',{ts '2020-04-14 16:07:55.590'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizione' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione',kind = 'S',lt = {ts '2020-04-14 16:07:55.590'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizione' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizione','pratica','4',null,null,'Iscrizione','S',{ts '2020-04-14 16:07:55.590'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizione_from' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione da cui si vogliono convalidare i sostenimenti',kind = 'S',lt = {ts '2020-04-14 16:07:55.590'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizione_from' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizione_from','pratica','4',null,null,'Iscrizione da cui si vogliono convalidare i sostenimenti','S',{ts '2020-04-14 16:07:55.590'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanza' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istanza',kind = 'S',lt = {ts '2019-11-13 17:48:53.323'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanza' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanza','pratica','4',null,null,'Istanza','S',{ts '2019-11-13 17:48:53.323'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanzakind' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di istanza',kind = 'S',lt = {ts '2020-07-01 16:56:04.127'},lu = 'mluisas',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanzakind' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanzakind','pratica','4',null,null,'Tipologia di istanza','S',{ts '2020-07-01 16:56:04.127'},'mluisas','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpratica' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:31:30.820'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpratica' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpratica','pratica','4',null,null,null,'S',{ts '2018-07-20 10:31:30.820'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-13 17:31:15.347'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','pratica','4',null,null,'Studente','S',{ts '2019-11-13 17:31:15.347'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstatuskind' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2019-11-13 17:48:53.323'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstatuskind' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstatuskind','pratica','4',null,null,'Stato','S',{ts '2019-11-13 17:48:53.323'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtitolostudio' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Titolo studio da cui si vogliono convalidare i sostenimenti',kind = 'S',lt = {ts '2020-04-14 16:07:55.590'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtitolostudio' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtitolostudio','pratica','4',null,null,'Titolo studio da cui si vogliono convalidare i sostenimenti','S',{ts '2020-04-14 16:07:55.590'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:31:30.820'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','pratica','8',null,null,null,'S',{ts '2018-07-20 10:31:30.820'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:31:30.820'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','pratica','64',null,null,null,'S',{ts '2018-07-20 10:31:30.820'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protanno' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di protocollo',kind = 'S',lt = {ts '2019-11-13 17:48:53.323'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protanno' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protanno','pratica','4',null,null,'Anno di protocollo','S',{ts '2019-11-13 17:48:53.323'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protnumero' AND tablename = 'pratica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di protocollo',kind = 'S',lt = {ts '2019-11-13 17:48:53.323'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protnumero' AND tablename = 'pratica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protnumero','pratica','4',null,null,'Numero di protocollo','S',{ts '2019-11-13 17:48:53.323'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3306')
UPDATE [relation] SET childtable = 'pratica',description = 'istanza dello studente che ha richiesto una convalida,abbreviazione,riconoscimento',lt = {ts '2018-07-20 10:36:10.840'},lu = 'assistenza',parenttable = 'istanza',title = null WHERE idrelation = '3306'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3306','pratica','istanza dello studente che ha richiesto una convalida,abbreviazione,riconoscimento',{ts '2018-07-20 10:36:10.840'},'assistenza','istanza',null)
GO

-- FINE GENERAZIONE SCRIPT --

