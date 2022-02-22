
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


-- CREAZIONE TABELLA sospensione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sospensione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sospensione] (
idsospensione int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idaula int NULL,
idedificio int NULL,
idreg int NULL,
idsede int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
motivo varchar(1024) NULL,
start datetime NOT NULL,
stop datetime NULL,
 CONSTRAINT xpksospensione PRIMARY KEY (idsospensione
)
)
END
GO

-- VERIFICA STRUTTURA sospensione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'idsospensione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD idsospensione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sospensione') and col.name = 'idsospensione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sospensione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sospensione') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sospensione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sospensione') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sospensione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'idaula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD idaula int NULL 
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN idaula int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'idedificio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD idedificio int NULL 
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN idedificio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD idsede int NULL 
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN idsede int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sospensione') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sospensione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sospensione') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sospensione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'motivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD motivo varchar(1024) NULL 
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN motivo varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD start datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sospensione') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sospensione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN start datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sospensione' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sospensione] ADD stop datetime NULL 
END
ELSE
	ALTER TABLE [sospensione] ALTER COLUMN stop datetime NULL
GO

-- VERIFICA DI sospensione IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sospensione'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sospensione','int','ASSISTENZA','idsospensione','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sospensione','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sospensione','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sospensione','int','ASSISTENZA','idaula','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sospensione','int','ASSISTENZA','idedificio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sospensione','int','ASSISTENZA','idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sospensione','int','ASSISTENZA','idsede','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sospensione','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sospensione','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sospensione','varchar(1024)','ASSISTENZA','motivo','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sospensione','datetime','ASSISTENZA','start','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sospensione','datetime','ASSISTENZA','stop','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI sospensione IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sospensione')
UPDATE customobject set isreal = 'S' where objectname = 'sospensione'
ELSE
INSERT INTO customobject (objectname, isreal) values('sospensione', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sospensione')
UPDATE [tabledescr] SET description = 'sospenione di attività, che sia di una carriera, didattica del docente o di utilizzabilità di un''aula',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-26 11:58:18.297'},lu = 'assistenza',title = 'Sospenione delle attività' WHERE tablename = 'sospensione'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sospensione','sospenione di attività, che sia di una carriera, didattica del docente o di utilizzabilità di un''aula','3','S',{ts '2021-02-26 11:58:18.297'},'assistenza','Sospenione delle attività')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','sospensione','8',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','sospensione','64',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaula' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Aula',kind = 'S',lt = {ts '2019-09-24 16:29:12.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaula' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaula','sospensione','4',null,null,'Aula','S',{ts '2019-09-24 16:29:12.827'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idedificio' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Edificio',kind = 'S',lt = {ts '2019-09-24 16:29:12.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idedificio' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idedificio','sospensione','4',null,null,'Edificio','S',{ts '2019-09-24 16:29:12.827'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente, Studente o Istituto',kind = 'S',lt = {ts '2018-12-05 16:13:14.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','sospensione','4',null,null,'Docente, Studente o Istituto','S',{ts '2018-12-05 16:13:14.753'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-09-24 16:29:12.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','sospensione','4',null,null,'Sede','S',{ts '2019-09-24 16:29:12.827'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsospensione' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-05 16:13:14.753'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsospensione' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsospensione','sospensione','4',null,null,'Codice','S',{ts '2018-12-05 16:13:14.753'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','sospensione','8',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','sospensione','64',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'motivo' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-21 18:47:07.023'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'motivo' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('motivo','sospensione','1024',null,null,null,'S',{ts '2018-11-21 18:47:07.023'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Inizio',kind = 'S',lt = {ts '2018-11-21 16:08:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','sospensione','8',null,null,'Inizio','S',{ts '2018-11-21 16:08:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Fine',kind = 'S',lt = {ts '2019-01-23 11:25:48.820'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','sospensione','8',null,null,'Fine','S',{ts '2019-01-23 11:25:48.820'},'assistenza','N','datetime','datetime','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3441')
UPDATE [relation] SET childtable = 'sospensione',description = 'Sospensioni',lt = {ts '2018-12-07 18:37:51.957'},lu = 'assistenza',parenttable = 'docenti',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3441'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3441','sospensione','Sospensioni',{ts '2018-12-07 18:37:51.957'},'assistenza','docenti','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3449')
UPDATE [relation] SET childtable = 'sospensione',description = 'Interruzioni delle attivit?',lt = {ts '2018-12-07 19:03:50.690'},lu = 'assistenza',parenttable = 'registry_istituti',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3449'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3449','sospensione','Interruzioni delle attivit?',{ts '2018-12-07 19:03:50.690'},'assistenza','registry_istituti','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3450')
UPDATE [relation] SET childtable = 'sospensione',description = 'Interruzioni delle attivit?',lt = {ts '2018-12-07 19:04:40.737'},lu = 'assistenza',parenttable = 'location_edifici',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3450'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3450','sospensione','Interruzioni delle attivit?',{ts '2018-12-07 19:04:40.737'},'assistenza','location_edifici','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3451')
UPDATE [relation] SET childtable = 'sospensione',description = 'Interruzioni delle attivit?',lt = {ts '2018-12-07 19:05:39.647'},lu = 'assistenza',parenttable = 'location_aula',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3451'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3451','sospensione','Interruzioni delle attivit?',{ts '2018-12-07 19:05:39.647'},'assistenza','location_aula','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

-- FINE GENERAZIONE SCRIPT --

