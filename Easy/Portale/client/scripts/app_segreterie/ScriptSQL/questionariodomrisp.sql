
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
-- CREAZIONE TABELLA questionariodomrisp --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionariodomrisp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[questionariodomrisp] (
idquestionariodomrisp int NOT NULL,
idquestionariodom int NOT NULL,
idquestionario int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
indicedom int NULL,
indicerisp int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
max decimal(9,2) NULL,
min decimal(9,2) NULL,
multiplacontxt char(1) NULL,
punteggio decimal(9,2) NULL,
risposta varchar(2048) NOT NULL,
 CONSTRAINT xpkquestionariodomrisp PRIMARY KEY (idquestionariodomrisp,
idquestionariodom,
idquestionario
)
)
END
GO

-- VERIFICA STRUTTURA questionariodomrisp --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'idquestionariodomrisp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD idquestionariodomrisp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'idquestionariodomrisp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'idquestionariodom' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD idquestionariodom int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'idquestionariodom' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'idquestionario' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD idquestionario int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'idquestionario' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'indicedom' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD indicedom int NULL 
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN indicedom int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'indicerisp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD indicerisp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'indicerisp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN indicerisp int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'max' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD max decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN max decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'min' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD min decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN min decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'multiplacontxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD multiplacontxt char(1) NULL 
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN multiplacontxt char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'punteggio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD punteggio decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN punteggio decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionariodomrisp' and C.name = 'risposta' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionariodomrisp] ADD risposta varchar(2048) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionariodomrisp') and col.name = 'risposta' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionariodomrisp] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionariodomrisp] ALTER COLUMN risposta varchar(2048) NOT NULL
GO

-- VERIFICA DI questionariodomrisp IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'questionariodomrisp'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','int','ASSISTENZA','idquestionario','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','int','ASSISTENZA','idquestionariodom','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','int','ASSISTENZA','idquestionariodomrisp','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomrisp','int','ASSISTENZA','indicedom','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','int','ASSISTENZA','indicerisp','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomrisp','decimal(9,2)','ASSISTENZA','max','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomrisp','decimal(9,2)','ASSISTENZA','min','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomrisp','char(1)','ASSISTENZA','multiplacontxt','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','questionariodomrisp','decimal(9,2)','ASSISTENZA','punteggio','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','questionariodomrisp','varchar(2048)','ASSISTENZA','risposta','2048','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI questionariodomrisp IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'questionariodomrisp')
UPDATE customobject set isreal = 'S' where objectname = 'questionariodomrisp'
ELSE
INSERT INTO customobject (objectname, isreal) values('questionariodomrisp', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'questionariodomrisp')
UPDATE [tabledescr] SET description = 'Risposte che il compilatore pu? scegliere per rispondere ad una domanda. parte di 2.4.33 Questionari',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 15:37:39.320'},lu = 'assistenza',title = 'Risposte che il compilatore pu? scegliere per rispondere ad una domanda' WHERE tablename = 'questionariodomrisp'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('questionariodomrisp','Risposte che il compilatore pu? scegliere per rispondere ad una domanda. parte di 2.4.33 Questionari',null,'N',{ts '2018-07-20 15:37:39.320'},'assistenza','Risposte che il compilatore pu? scegliere per rispondere ad una domanda')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.337'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','questionariodomrisp','8',null,null,null,'S',{ts '2018-07-20 15:37:44.337'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.337'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','questionariodomrisp','64',null,null,null,'S',{ts '2018-07-20 15:37:44.337'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idquestionario' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Questionario',kind = 'S',lt = {ts '2019-12-20 13:32:14.500'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idquestionario' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idquestionario','questionariodomrisp','4',null,null,'Questionario','S',{ts '2019-12-20 13:32:14.500'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idquestionariodom' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Domanda',kind = 'S',lt = {ts '2019-12-20 13:32:14.500'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idquestionariodom' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idquestionariodom','questionariodomrisp','4',null,null,'Domanda','S',{ts '2019-12-20 13:32:14.500'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idquestionariodomrisp' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.337'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idquestionariodomrisp' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idquestionariodomrisp','questionariodomrisp','4',null,null,null,'S',{ts '2018-07-20 15:37:44.337'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicedom' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.337'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicedom' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicedom','questionariodomrisp','4',null,null,null,'S',{ts '2018-07-20 15:37:44.337'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicerisp' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordinamento',kind = 'S',lt = {ts '2019-12-20 13:32:14.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicerisp' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicerisp','questionariodomrisp','4',null,null,'Ordinamento','S',{ts '2019-12-20 13:32:14.503'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.337'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','questionariodomrisp','8',null,null,null,'S',{ts '2018-07-20 15:37:44.337'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.337'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','questionariodomrisp','64',null,null,null,'S',{ts '2018-07-20 15:37:44.337'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'max' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Valore numerico massimo',kind = 'S',lt = {ts '2019-12-20 13:32:14.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'max' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('max','questionariodomrisp','5','9','2','Valore numerico massimo','S',{ts '2019-12-20 13:32:14.503'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'min' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Valore numerico minimo',kind = 'S',lt = {ts '2019-12-20 13:32:14.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'min' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('min','questionariodomrisp','5','9','2','Valore numerico minimo','S',{ts '2019-12-20 13:32:14.507'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'multiplacontxt' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Risposta multipla con campo testuale',kind = 'S',lt = {ts '2019-12-20 13:32:14.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'multiplacontxt' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('multiplacontxt','questionariodomrisp','1',null,null,'Risposta multipla con campo testuale','S',{ts '2019-12-20 13:32:14.507'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'punteggio' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.340'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'punteggio' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('punteggio','questionariodomrisp','5','9','2',null,'S',{ts '2018-07-20 15:37:44.340'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'risposta' AND tablename = 'questionariodomrisp')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:37:44.340'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'risposta' AND tablename = 'questionariodomrisp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('risposta','questionariodomrisp','2048',null,null,null,'S',{ts '2018-07-20 15:37:44.340'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3335')
UPDATE [relation] SET childtable = 'questionariodomrisp',description = 'damanda di cui ? una risposta possibile',lt = {ts '2018-07-20 15:38:07.927'},lu = 'assistenza',parenttable = 'questionariodom',title = null WHERE idrelation = '3335'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3335','questionariodomrisp','damanda di cui ? una risposta possibile',{ts '2018-07-20 15:38:07.927'},'assistenza','questionariodom',null)
GO

-- FINE GENERAZIONE SCRIPT --

