
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


-- CREAZIONE TABELLA accordoscambiomidett --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomidett]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accordoscambiomidett] (
idaccordoscambiomidett int NOT NULL,
idreg_istitutiesteri int NOT NULL,
idaccordoscambiomi int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idisced2013 int NULL,
idtorkind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numdocincoming int NULL,
numdocoutgoing int NULL,
numpersincoming int NULL,
numpersoutgoing int NULL,
numstulearincoming int NULL,
numstulearoutgoing int NULL,
numstutraincoming int NULL,
numstutraoutgoing int NULL,
stipula date NULL,
stop date NULL,
 CONSTRAINT xpkaccordoscambiomidett PRIMARY KEY (idaccordoscambiomidett,
idreg_istitutiesteri,
idaccordoscambiomi
)
)
END
GO

-- VERIFICA STRUTTURA accordoscambiomidett --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'idaccordoscambiomidett' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD idaccordoscambiomidett int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidett') and col.name = 'idaccordoscambiomidett' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidett] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'idreg_istitutiesteri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD idreg_istitutiesteri int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidett') and col.name = 'idreg_istitutiesteri' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidett] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'idaccordoscambiomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD idaccordoscambiomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidett') and col.name = 'idaccordoscambiomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidett] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidett') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidett] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidett') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidett] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'idisced2013' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD idisced2013 int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN idisced2013 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'idtorkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD idtorkind int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN idtorkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidett') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidett] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accordoscambiomidett') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accordoscambiomidett] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numdocincoming' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numdocincoming int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numdocincoming int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numdocoutgoing' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numdocoutgoing int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numdocoutgoing int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numpersincoming' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numpersincoming int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numpersincoming int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numpersoutgoing' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numpersoutgoing int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numpersoutgoing int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numstulearincoming' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numstulearincoming int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numstulearincoming int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numstulearoutgoing' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numstulearoutgoing int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numstulearoutgoing int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numstutraincoming' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numstutraincoming int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numstutraincoming int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'numstutraoutgoing' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD numstutraoutgoing int NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN numstutraoutgoing int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'stipula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD stipula date NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN stipula date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accordoscambiomidett' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accordoscambiomidett] ADD stop date NULL 
END
ELSE
	ALTER TABLE [accordoscambiomidett] ALTER COLUMN stop date NULL
GO

-- VERIFICA DI accordoscambiomidett IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accordoscambiomidett'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidett','int','ASSISTENZA','idaccordoscambiomi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidett','int','ASSISTENZA','idaccordoscambiomidett','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidett','int','ASSISTENZA','idreg_istitutiesteri','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidett','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidett','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','idisced2013','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','idtorkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidett','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accordoscambiomidett','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numdocincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numdocoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numpersincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numpersoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numstulearincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numstulearoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numstutraincoming','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','int','ASSISTENZA','numstutraoutgoing','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','date','ASSISTENZA','stipula','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accordoscambiomidett','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accordoscambiomidett IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accordoscambiomidett')
UPDATE customobject set isreal = 'S' where objectname = 'accordoscambiomidett'
ELSE
INSERT INTO customobject (objectname, isreal) values('accordoscambiomidett', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'accordoscambiomidett')
UPDATE [tabledescr] SET description = '2.5.30 Dettaglio accordo di mobilità internazionale con istituti',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 16:19:17.190'},lu = 'assistenza',title = 'Dettaglio accordo di mobilità internazionale con istituti' WHERE tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('accordoscambiomidett','2.5.30 Dettaglio accordo di mobilità internazionale con istituti',null,'N',{ts '2018-07-20 16:19:17.190'},'assistenza','Dettaglio accordo di mobilità internazionale con istituti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:19:19.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','accordoscambiomidett','8',null,null,null,'S',{ts '2018-07-20 16:19:19.600'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:19:19.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','accordoscambiomidett','64',null,null,null,'S',{ts '2018-07-20 16:19:19.600'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomi' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 15:45:42.300'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomi' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomi','accordoscambiomidett','4',null,null,null,'S',{ts '2019-11-28 15:45:42.300'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomidett' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:19:19.600'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomidett' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomidett','accordoscambiomidett','4',null,null,null,'S',{ts '2018-07-20 16:19:19.600'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idisced2013' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classificazione ISCED 2013',kind = 'S',lt = {ts '2019-11-28 15:54:39.107'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idisced2013' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idisced2013','accordoscambiomidett','4',null,null,'Classificazione ISCED 2013','S',{ts '2019-11-28 15:54:39.107'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istitutiesteri' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto estero',kind = 'S',lt = {ts '2019-11-28 15:59:22.377'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istitutiesteri' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istitutiesteri','accordoscambiomidett','4',null,null,'Istituto estero','S',{ts '2019-11-28 15:59:22.377'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtorkind' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Modalità di invio del trascript of record',kind = 'S',lt = {ts '2019-11-28 15:54:39.107'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtorkind' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtorkind','accordoscambiomidett','4',null,null,'Modalità di invio del trascript of record','S',{ts '2019-11-28 15:54:39.107'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:19:19.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','accordoscambiomidett','8',null,null,null,'S',{ts '2018-07-20 16:19:19.600'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:19:19.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','accordoscambiomidett','64',null,null,null,'S',{ts '2018-07-20 16:19:19.600'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numdocincoming' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di docenti incoming',kind = 'S',lt = {ts '2019-11-28 15:52:46.763'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numdocincoming' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numdocincoming','accordoscambiomidett','4',null,null,'Numero di docenti incoming','S',{ts '2019-11-28 15:52:46.763'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numdocoutgoing' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di docenti outgoing',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numdocoutgoing' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numdocoutgoing','accordoscambiomidett','4',null,null,'Numero di docenti outgoing','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numpersincoming' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di personale incoming',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numpersincoming' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numpersincoming','accordoscambiomidett','4',null,null,'Numero di personale incoming','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numpersoutgoing' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di personale outgoing',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numpersoutgoing' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numpersoutgoing','accordoscambiomidett','4',null,null,'Numero di personale outgoing','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numstulearincoming' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di studenti incoming for learning',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numstulearincoming' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numstulearincoming','accordoscambiomidett','4',null,null,'Numero di studenti incoming for learning','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numstulearoutgoing' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di studenti outgoing for learning',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numstulearoutgoing' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numstulearoutgoing','accordoscambiomidett','4',null,null,'Numero di studenti outgoing for learning','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numstutraincoming' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di studenti incoming for traineeship',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numstutraincoming' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numstutraincoming','accordoscambiomidett','4',null,null,'Numero di studenti incoming for traineeship','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numstutraoutgoing' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di studenti outgoing for traineeship',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numstutraoutgoing' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numstutraoutgoing','accordoscambiomidett','4',null,null,'Numero di studenti outgoing for traineeship','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipula' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di stipula',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stipula' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipula','accordoscambiomidett','3',null,null,'Data di stipula','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'accordoscambiomidett')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di termine dell''accordo',kind = 'S',lt = {ts '2019-11-28 15:52:46.767'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','accordoscambiomidett','3',null,null,'Data di termine dell''accordo','S',{ts '2019-11-28 15:52:46.767'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --

