
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


-- CREAZIONE TABELLA registryaddress --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaddress]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryaddress] (
idreg int NOT NULL,
start date NOT NULL,
idaddresskind int NOT NULL,
active char(1) NULL,
address varchar(100) NULL,
annotations varchar(400) NULL,
cap varchar(20) NULL,
ct datetime NULL,
cu varchar(64) NULL,
flagforeign char(1) NULL,
idcity int NULL,
idnation int NULL,
location varchar(50) NULL,
lt datetime NULL,
lu varchar(64) NULL,
officename varchar(50) NULL,
recipientagency varchar(50) NULL,
stop date NULL,
 CONSTRAINT xpkregistryaddress PRIMARY KEY (idreg,
start,
idaddresskind
)
)
END
GO

-- VERIFICA STRUTTURA registryaddress --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryaddress') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryaddress] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD start date NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryaddress') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryaddress] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idaddresskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD idaddresskind int NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryaddress') and col.name = 'idaddresskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryaddress] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'address' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD address varchar(100) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN address varchar(100) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'annotations' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD annotations varchar(400) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN annotations varchar(400) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'cap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD cap varchar(20) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN cap varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'flagforeign' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD flagforeign char(1) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN flagforeign char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'location' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD location varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN location varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'officename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD officename varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN officename varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'recipientagency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD recipientagency varchar(50) NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN recipientagency varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryaddress' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryaddress] ADD stop date NULL 
END
ELSE
	ALTER TABLE [registryaddress] ALTER COLUMN stop date NULL
GO

-- VERIFICA DI registryaddress IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryaddress'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaddress','int','assistenza','idaddresskind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaddress','int','assistenza','idreg','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryaddress','date','assistenza','start','3','S','date','System.DateTime','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','char(1)','assistenza','active','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(100)','assistenza','address','100','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(400)','assistenza','annotations','400','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(20)','assistenza','cap','20','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(64)','assistenza','cu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','char(1)','assistenza','flagforeign','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','int','assistenza','idcity','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','int','assistenza','idnation','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(50)','assistenza','location','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(50)','assistenza','officename','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','varchar(50)','assistenza','recipientagency','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryaddress','date','assistenza','stop','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

-- VERIFICA DI registryaddress IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryaddress')
UPDATE customobject set isreal = 'S' where objectname = 'registryaddress'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryaddress', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registryaddress')
UPDATE [tabledescr] SET description = 'Indirizzo di anagrafica',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 12:18:55.307'},lu = 'assistenza',title = 'Indirizzo' WHERE tablename = 'registryaddress'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registryaddress','Indirizzo di anagrafica','3','S',{ts '2021-02-19 12:18:55.307'},'assistenza','Indirizzo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.383'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','registryaddress','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.383'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'address' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'n. operazione',kind = 'S',lt = {ts '1900-01-01 03:00:15.043'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'address' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('address','registryaddress','100',null,null,'n. operazione','S',{ts '1900-01-01 03:00:15.043'},'nino','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annotations' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '400',col_precision = null,col_scale = null,description = 'Annotazioni',kind = 'S',lt = {ts '1900-01-01 03:00:05.050'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(400)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'annotations' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annotations','registryaddress','400',null,null,'Annotazioni','S',{ts '1900-01-01 03:00:05.050'},'nino','N','varchar(400)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cap' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice avv. postale',kind = 'S',lt = {ts '1900-01-01 03:00:09.873'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cap' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cap','registryaddress','20',null,null,'Codice avv. postale','S',{ts '1900-01-01 03:00:09.873'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.143'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registryaddress','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.143'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.577'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registryaddress','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.577'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagforeign' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Estero',kind = 'C',lt = {ts '2016-02-07 08:46:47.867'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagforeign' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagforeign','registryaddress','1',null,null,'Estero','C',{ts '2016-02-07 08:46:47.867'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaddresskind' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'tipo indirizzo (idaddress di tabella address)',kind = 'S',lt = {ts '2016-10-09 09:49:52.547'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaddresskind' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaddresskind','registryaddress','4',null,null,'tipo indirizzo (idaddress di tabella address)','S',{ts '2016-10-09 09:49:52.547'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id città (tabella geo_city)',kind = 'S',lt = {ts '1900-01-01 03:00:02.250'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','registryaddress','4',null,null,'id città (tabella geo_city)','S',{ts '1900-01-01 03:00:02.250'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id nazione (tabella geo_nation)',kind = 'S',lt = {ts '1900-01-01 03:00:14.993'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','registryaddress','4',null,null,'Id nazione (tabella geo_nation)','S',{ts '1900-01-01 03:00:14.993'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:52.463'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registryaddress','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:52.463'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ubicazione',kind = 'S',lt = {ts '1900-01-01 03:00:11.417'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','registryaddress','50',null,null,'ubicazione','S',{ts '1900-01-01 03:00:11.417'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:42.900'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registryaddress','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:42.900'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:39.930'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registryaddress','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:39.930'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'officename' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Nome ufficio',kind = 'S',lt = {ts '1900-01-01 03:00:22.800'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'officename' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('officename','registryaddress','50',null,null,'Nome ufficio','S',{ts '1900-01-01 03:00:22.800'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'recipientagency' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Ente di provenienza (per anagrafe prestazioni)',kind = 'S',lt = {ts '2016-10-09 09:49:52.547'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'recipientagency' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('recipientagency','registryaddress','50',null,null,'Ente di provenienza (per anagrafe prestazioni)','S',{ts '2016-10-09 09:49:52.547'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '2021-05-18 10:13:52.953'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','registryaddress','3',null,null,'data inizio','S',{ts '2021-05-18 10:13:52.953'},'assistenza','S','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'registryaddress')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '2021-05-18 10:13:52.957'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'registryaddress'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','registryaddress','3',null,null,'data fine','S',{ts '2021-05-18 10:13:52.957'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagforeign' AND tablename = 'registryaddress' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:46:47.867'},lu = 'Nino',title = 'Italia' WHERE colname = 'flagforeign' AND tablename = 'registryaddress' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagforeign','registryaddress','N',null,{ts '2016-02-07 08:46:47.867'},'Nino','Italia')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagforeign' AND tablename = 'registryaddress' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:46:47.867'},lu = 'Nino',title = 'Estero' WHERE colname = 'flagforeign' AND tablename = 'registryaddress' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagforeign','registryaddress','S',null,{ts '2016-02-07 08:46:47.867'},'Nino','Estero')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '847')
UPDATE [relation] SET childtable = 'registryaddress',description = 'Codice avv. postale',lt = {ts '2017-05-20 09:19:52.217'},lu = 'lu',parenttable = 'geo_cap',title = 'Indirizzo' WHERE idrelation = '847'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('847','registryaddress','Codice avv. postale',{ts '2017-05-20 09:19:52.217'},'lu','geo_cap','Indirizzo')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '870')
UPDATE [relation] SET childtable = 'registryaddress',description = 'id città (tabella geo_city)',lt = {ts '2017-05-20 09:19:52.420'},lu = 'lu',parenttable = 'geo_city',title = 'Indirizzo' WHERE idrelation = '870'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('870','registryaddress','id città (tabella geo_city)',{ts '2017-05-20 09:19:52.420'},'lu','geo_city','Indirizzo')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '894')
UPDATE [relation] SET childtable = 'registryaddress',description = 'Id nazione (tabella geo_nation)',lt = {ts '2017-05-20 09:19:52.760'},lu = 'lu',parenttable = 'geo_nation',title = 'Indirizzo' WHERE idrelation = '894'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('894','registryaddress','Id nazione (tabella geo_nation)',{ts '2017-05-20 09:19:52.760'},'lu','geo_nation','Indirizzo')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2091')
UPDATE [relation] SET childtable = 'registryaddress',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:05.860'},lu = 'lu',parenttable = 'registry',title = 'Indirizzo' WHERE idrelation = '2091'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2091','registryaddress','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:05.860'},'lu','registry','Indirizzo')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2129')
UPDATE [relation] SET childtable = 'registryaddress',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:06.810'},lu = 'lu',parenttable = 'registrytaxablestatus',title = 'Indirizzo' WHERE idrelation = '2129'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2129','registryaddress','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:06.810'},'lu','registrytaxablestatus','Indirizzo')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2961')
UPDATE [relation] SET childtable = 'registryaddress',description = 'tipo indirizzo (idaddress di tabella address)',lt = {ts '2017-05-20 10:55:21.350'},lu = 'lu',parenttable = 'address',title = 'Indirizzo' WHERE idrelation = '2961'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2961','registryaddress','tipo indirizzo (idaddress di tabella address)',{ts '2017-05-20 10:55:21.350'},'lu','address','Indirizzo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '847' AND parentcol = 'cap')
UPDATE [relationcol] SET childcol = 'cap',lt = {ts '2017-05-20 09:19:52.360'},lu = 'lu' WHERE idrelation = '847' AND parentcol = 'cap'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('847','cap','cap',{ts '2017-05-20 09:19:52.360'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

