
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
-- CREAZIONE TABELLA accmotive --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[accmotive] (
idaccmotive varchar(36) NOT NULL,
active char(1) NULL,
codemotive varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
expensekind varchar(2) NULL,
flag int NULL,
flagamm char(1) NULL,
flagdep char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridaccmotive varchar(36) NULL,
title varchar(150) NOT NULL,
 CONSTRAINT xpkaccmotive PRIMARY KEY (idaccmotive
)
)
END
GO

-- VERIFICA STRUTTURA accmotive --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD idaccmotive varchar(36) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accmotive') and col.name = 'idaccmotive' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accmotive] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'codemotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD codemotive varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accmotive') and col.name = 'codemotive' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accmotive] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN codemotive varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accmotive') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accmotive] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accmotive') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accmotive] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'expensekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD expensekind varchar(2) NULL 
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN expensekind varchar(2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD flag int NULL 
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN flag int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'flagamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD flagamm char(1) NULL 
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN flagamm char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'flagdep' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD flagdep char(1) NULL 
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN flagdep char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accmotive') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accmotive] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accmotive') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accmotive] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'paridaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD paridaccmotive varchar(36) NULL 
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN paridaccmotive varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accmotive' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [accmotive] ADD title varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('accmotive') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [accmotive] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [accmotive] ALTER COLUMN title varchar(150) NOT NULL
GO

-- VERIFICA DI accmotive IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accmotive'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotive','varchar(36)','ASSISTENZA','idaccmotive','36','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotive','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotive','varchar(50)','ASSISTENZA','codemotive','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotive','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotive','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotive','varchar(2)','ASSISTENZA','expensekind','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotive','int','ASSISTENZA','flag','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotive','char(1)','ASSISTENZA','flagamm','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotive','char(1)','ASSISTENZA','flagdep','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotive','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotive','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','accmotive','varchar(36)','ASSISTENZA','paridaccmotive','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','accmotive','varchar(150)','ASSISTENZA','title','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI accmotive IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accmotive')
UPDATE customobject set isreal = 'S' where objectname = 'accmotive'
ELSE
INSERT INTO customobject (objectname, isreal) values('accmotive', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'accmotive')
UPDATE [tabledescr] SET description = 'Piano dei conti',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:28.633'},lu = 'nino',title = 'Piano dei conti' WHERE tablename = 'accmotive'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('accmotive','Piano dei conti',null,'S',{ts '1900-01-01 03:00:28.633'},'nino','Piano dei conti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'attivo',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','accmotive','1','0','0','attivo','S',{ts '2017-05-19 07:53:10.197'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codemotive' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '50',col_precision = '0',col_scale = '0',description = 'Codice causale',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codemotive' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codemotive','accmotive','50','0','0','Codice causale','S',{ts '2017-05-19 07:53:10.197'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data creazione',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','accmotive','8','0','0','data creazione','S',{ts '2017-05-19 07:53:10.197'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome utente creazione',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','accmotive','64','0','0','nome utente creazione','S',{ts '2017-05-19 07:53:10.197'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'expensekind' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '2',col_precision = '0',col_scale = '0',description = 'Tipo spesa PCC (COrrente o CApitale)',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(2)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'expensekind' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('expensekind','accmotive','2','0','0','Tipo spesa PCC (COrrente o CApitale)','S',{ts '2017-05-19 07:53:10.197'},'nino','N','varchar(2)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'flag',kind = 'B',lt = {ts '2017-05-19 07:54:06.810'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'flag' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag','accmotive','4','0','0','flag','B',{ts '2017-05-19 07:54:06.810'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagamm' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Utilizzabile dall''Amministrazione',kind = 'C',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagamm' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagamm','accmotive','1','0','0','Utilizzabile dall''Amministrazione','C',{ts '2017-05-19 07:53:10.197'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagdep' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Utilizzabile dai dipartimenti',kind = 'C',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagdep' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagdep','accmotive','1','0','0','Utilizzabile dai dipartimenti','C',{ts '2017-05-19 07:53:10.197'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '36',col_precision = '0',col_scale = '0',description = 'id causale (tabella acccmotive)',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive','accmotive','36','0','0','id causale (tabella acccmotive)','S',{ts '2017-05-19 07:53:10.197'},'nino','S','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data ultima modifica',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','accmotive','8','0','0','data ultima modifica','S',{ts '2017-05-19 07:53:10.197'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','accmotive','64','0','0','nome ultimo utente modifica','S',{ts '2017-05-19 07:53:10.197'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridaccmotive' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '36',col_precision = '0',col_scale = '0',description = 'chiave della riga parent (idaccmotive)',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'paridaccmotive' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridaccmotive','accmotive','36','0','0','chiave della riga parent (idaccmotive)','S',{ts '2017-05-19 07:53:10.197'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'accmotive')
UPDATE [coldescr] SET col_len = '150',col_precision = '0',col_scale = '0',description = 'Denominazione',kind = 'S',lt = {ts '2017-05-19 07:53:10.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'accmotive'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','accmotive','150','0','0','Denominazione','S',{ts '2017-05-19 07:53:10.197'},'nino','N','varchar(150)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colbit --
IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '0' AND tablename = 'accmotive')
UPDATE [colbit] SET description = null,lt = {ts '2017-05-19 07:54:06.810'},lu = 'nino',title = 'Vieta il salvataggio della fattura in assenza di contratto' WHERE colname = 'flag' AND nbit = '0' AND tablename = 'accmotive'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','0','accmotive',null,{ts '2017-05-19 07:54:06.810'},'nino','Vieta il salvataggio della fattura in assenza di contratto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagamm' AND tablename = 'accmotive' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-04 09:11:40.973'},lu = 'Nino',title = 'Non utilizzabile dall''Amministrazione' WHERE colname = 'flagamm' AND tablename = 'accmotive' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagamm','accmotive','N',null,{ts '2016-02-04 09:11:40.973'},'Nino','Non utilizzabile dall''Amministrazione')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagamm' AND tablename = 'accmotive' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Utilizzabile dall''Amministrazione' WHERE colname = 'flagamm' AND tablename = 'accmotive' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagamm','accmotive','S',null,{ts '2016-01-29 14:10:19.543'},'lu','Utilizzabile dall''Amministrazione')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagdep' AND tablename = 'accmotive' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Non è vero che: "Utilizzabile dai dipartimenti"' WHERE colname = 'flagdep' AND tablename = 'accmotive' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagdep','accmotive','N',null,{ts '2016-01-29 14:10:19.543'},'lu','Non è vero che: "Utilizzabile dai dipartimenti"')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagdep' AND tablename = 'accmotive' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Utilizzabile dai dipartimenti' WHERE colname = 'flagdep' AND tablename = 'accmotive' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagdep','accmotive','S',null,{ts '2016-01-29 14:10:19.543'},'lu','Utilizzabile dai dipartimenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '2987')
UPDATE [relation] SET childtable = 'accmotive',description = 'chiave della riga parent (idaccmotive)',lt = {ts '2017-05-22 07:55:42.033'},lu = 'nino',parenttable = 'accmotive',title = 'Piano dei conti' WHERE idrelation = '2987'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2987','accmotive','chiave della riga parent (idaccmotive)',{ts '2017-05-22 07:55:42.033'},'nino','accmotive','Piano dei conti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '2987' AND parentcol = 'idaccmotive')
UPDATE [relationcol] SET childcol = 'paridaccmotive',lt = {ts '2017-05-22 07:55:42.043'},lu = 'nino' WHERE idrelation = '2987' AND parentcol = 'idaccmotive'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('2987','idaccmotive','paridaccmotive',{ts '2017-05-22 07:55:42.043'},'nino')
GO

-- FINE GENERAZIONE SCRIPT --

