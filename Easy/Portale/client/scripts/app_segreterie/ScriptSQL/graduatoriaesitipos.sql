
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
-- CREAZIONE TABELLA graduatoriaesitipos --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[graduatoriaesitipos]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[graduatoriaesitipos] (
idgraduatoriaesitipos int NOT NULL,
idgraduatoriaesiti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcorsostudio int NULL,
idreg_studenti int NULL,
idtipologiastudente int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
pos int NULL,
punteggio decimal(9,2) NULL,
 CONSTRAINT xpkgraduatoriaesitipos PRIMARY KEY (idgraduatoriaesitipos,
idgraduatoriaesiti
)
)
END
GO

-- VERIFICA STRUTTURA graduatoriaesitipos --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'idgraduatoriaesitipos' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD idgraduatoriaesitipos int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesitipos') and col.name = 'idgraduatoriaesitipos' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesitipos] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'idgraduatoriaesiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD idgraduatoriaesiti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesitipos') and col.name = 'idgraduatoriaesiti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesitipos] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesitipos') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesitipos] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesitipos') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesitipos] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'idreg_studenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD idreg_studenti int NULL 
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN idreg_studenti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'idtipologiastudente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD idtipologiastudente int NULL 
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN idtipologiastudente int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesitipos') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesitipos] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriaesitipos') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriaesitipos] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'pos' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD pos int NULL 
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN pos int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriaesitipos' and C.name = 'punteggio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriaesitipos] ADD punteggio decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [graduatoriaesitipos] ALTER COLUMN punteggio decimal(9,2) NULL
GO

-- VERIFICA DI graduatoriaesitipos IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'graduatoriaesitipos'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesitipos','int','ASSISTENZA','idgraduatoriaesiti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesitipos','int','ASSISTENZA','idgraduatoriaesitipos','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesitipos','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesitipos','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesitipos','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesitipos','int','ASSISTENZA','idreg_studenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesitipos','int','ASSISTENZA','idtipologiastudente','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesitipos','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriaesitipos','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesitipos','int','ASSISTENZA','pos','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriaesitipos','decimal(9,2)','ASSISTENZA','punteggio','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

-- VERIFICA DI graduatoriaesitipos IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'graduatoriaesitipos')
UPDATE customobject set isreal = 'S' where objectname = 'graduatoriaesitipos'
ELSE
INSERT INTO customobject (objectname, isreal) values('graduatoriaesitipos', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'graduatoriaesitipos')
UPDATE [tabledescr] SET description = 'Singoli esiti della 2.4.36 Graduatoria',idapplication = null,isdbo = 'N',lt = {ts '2018-07-18 17:51:19.313'},lu = 'assistenza',title = 'Singoli esiti della graduatoria' WHERE tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('graduatoriaesitipos','Singoli esiti della 2.4.36 Graduatoria',null,'N',{ts '2018-07-18 17:51:19.313'},'assistenza','Singoli esiti della graduatoria')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:51:22.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','graduatoriaesitipos','8',null,null,null,'S',{ts '2018-07-18 17:51:22.387'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:51:22.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','graduatoriaesitipos','64',null,null,null,'S',{ts '2018-07-18 17:51:22.387'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Corso di studio',kind = 'S',lt = {ts '2020-09-10 09:54:58.817'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','graduatoriaesitipos','4',null,null,'Corso di studio','S',{ts '2020-09-10 09:54:58.817'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoriaesiti' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-13 16:26:24.067'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoriaesiti' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoriaesiti','graduatoriaesitipos','4',null,null,null,'S',{ts '2019-11-13 16:26:24.067'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoriaesitipos' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:51:22.387'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoriaesitipos' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoriaesitipos','graduatoriaesitipos','4',null,null,null,'S',{ts '2018-07-18 17:51:22.387'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_studenti' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-02-22 17:26:23.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_studenti' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_studenti','graduatoriaesitipos','4',null,null,'Studente','S',{ts '2019-02-22 17:26:23.077'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipologiastudente' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 13:17:03.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipologiastudente' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipologiastudente','graduatoriaesitipos','4',null,null,null,'S',{ts '2020-03-04 13:17:03.770'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:51:22.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','graduatoriaesitipos','8',null,null,null,'S',{ts '2018-07-18 17:51:22.387'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:51:22.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','graduatoriaesitipos','64',null,null,null,'S',{ts '2018-07-18 17:51:22.387'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pos' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Posizione',kind = 'S',lt = {ts '2019-11-13 16:25:40.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'pos' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pos','graduatoriaesitipos','4',null,null,'Posizione','S',{ts '2019-11-13 16:25:40.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'punteggio' AND tablename = 'graduatoriaesitipos')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2018-07-18 17:51:22.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'punteggio' AND tablename = 'graduatoriaesitipos'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('punteggio','graduatoriaesitipos','5','9','2',null,'S',{ts '2018-07-18 17:51:22.387'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3259')
UPDATE [relation] SET childtable = 'graduatoriaesitipos',description = 'contenitore degli esiti',lt = {ts '2018-07-18 17:51:39.577'},lu = 'assistenza',parenttable = 'graduatoriaesiti',title = null WHERE idrelation = '3259'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3259','graduatoriaesitipos','contenitore degli esiti',{ts '2018-07-18 17:51:39.577'},'assistenza','graduatoriaesiti',null)
GO

-- FINE GENERAZIONE SCRIPT --

