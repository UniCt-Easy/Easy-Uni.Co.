
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA flowchartrestrictedfunction --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[flowchartrestrictedfunction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [flowchartrestrictedfunction] (
idflowchart varchar(34) NOT NULL,
idrestrictedfunction int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkflowchartrestrictedfunction PRIMARY KEY (idflowchart,
idrestrictedfunction
)
)
END
GO

-- VERIFICA STRUTTURA flowchartrestrictedfunction --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartrestrictedfunction' and C.name = 'idflowchart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartrestrictedfunction] ADD idflowchart varchar(34) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartrestrictedfunction') and col.name = 'idflowchart' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartrestrictedfunction] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartrestrictedfunction' and C.name = 'idrestrictedfunction' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartrestrictedfunction] ADD idrestrictedfunction int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartrestrictedfunction') and col.name = 'idrestrictedfunction' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartrestrictedfunction] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartrestrictedfunction' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartrestrictedfunction] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartrestrictedfunction') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartrestrictedfunction] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartrestrictedfunction] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartrestrictedfunction' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartrestrictedfunction] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartrestrictedfunction') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartrestrictedfunction] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartrestrictedfunction] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartrestrictedfunction' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartrestrictedfunction] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartrestrictedfunction') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartrestrictedfunction] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartrestrictedfunction] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartrestrictedfunction' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [flowchartrestrictedfunction] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('flowchartrestrictedfunction') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [flowchartrestrictedfunction] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [flowchartrestrictedfunction] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI flowchartrestrictedfunction IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'flowchartrestrictedfunction'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartrestrictedfunction','varchar(34)','SARA','idflowchart','34','S','varchar','System.String','','','''SARA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartrestrictedfunction','int','SARA','idrestrictedfunction','4','S','int','System.Int32','','','''SARA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartrestrictedfunction','datetime','SARA','ct','8','S','datetime','System.DateTime','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartrestrictedfunction','varchar(64)','SARA','cu','64','S','varchar','System.String','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartrestrictedfunction','datetime','SARA','lt','8','S','datetime','System.DateTime','','','''SARA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartrestrictedfunction','varchar(64)','SARA','lu','64','S','varchar','System.String','','','''SARA''','','N')
GO

-- VERIFICA DI flowchartrestrictedfunction IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'flowchartrestrictedfunction')
UPDATE customobject set isreal = 'S' where objectname = 'flowchartrestrictedfunction'
ELSE
INSERT INTO customobject (objectname, isreal) values('flowchartrestrictedfunction', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'flowchartrestrictedfunction')
UPDATE [tabledescr] SET description = 'Restrizioni associate alla voce di organigramma',idapplication = '1',isdbo = 'N',lt = {ts '2017-05-20 14:56:28.520'},lu = 'nino',title = 'Restrizioni associate alla voce di organigramma' WHERE tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('flowchartrestrictedfunction','Restrizioni associate alla voce di organigramma','1','N',{ts '2017-05-20 14:56:28.520'},'nino','Restrizioni associate alla voce di organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:47.227'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','flowchartrestrictedfunction','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:47.227'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.660'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','flowchartrestrictedfunction','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.660'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idflowchart' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '34',col_precision = null,col_scale = null,description = 'Id della voce di organigramma (tabella flowchart)',kind = 'S',lt = {ts '1900-01-01 03:00:14.803'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(34)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idflowchart' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idflowchart','flowchartrestrictedfunction','34',null,null,'Id della voce di organigramma (tabella flowchart)','S',{ts '1900-01-01 03:00:14.803'},'nino','S','varchar(34)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrestrictedfunction' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID Operativit� (tabella restrictedfunction)',kind = 'S',lt = {ts '1900-01-01 03:00:30.763'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrestrictedfunction' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrestrictedfunction','flowchartrestrictedfunction','4',null,null,'ID Operativit� (tabella restrictedfunction)','S',{ts '1900-01-01 03:00:30.763'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.823'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','flowchartrestrictedfunction','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.823'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.857'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','flowchartrestrictedfunction','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.857'},'nino','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '813')
UPDATE [relation] SET childtable = 'flowchartrestrictedfunction',description = 'Id della voce di organigramma (tabella flowchart)',lt = {ts '2017-05-20 09:19:50.833'},lu = 'lu',parenttable = 'flowchart',title = 'Restrizioni associate alla voce di organigramma' WHERE idrelation = '813'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('813','flowchartrestrictedfunction','Id della voce di organigramma (tabella flowchart)',{ts '2017-05-20 09:19:50.833'},'lu','flowchart','Restrizioni associate alla voce di organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2147')
UPDATE [relation] SET childtable = 'flowchartrestrictedfunction',description = 'ID Operativit� (tabella restrictedfunction)',lt = {ts '2017-05-20 09:20:07.207'},lu = 'lu',parenttable = 'restrictedfunction',title = 'Restrizioni associate alla voce di organigramma' WHERE idrelation = '2147'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2147','flowchartrestrictedfunction','ID Operativit� (tabella restrictedfunction)',{ts '2017-05-20 09:20:07.207'},'lu','restrictedfunction','Restrizioni associate alla voce di organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '813' AND parentcol = 'idflowchart')
UPDATE [relationcol] SET childcol = 'idflowchart',lt = {ts '2017-05-20 09:19:50.900'},lu = 'lu' WHERE idrelation = '813' AND parentcol = 'idflowchart'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('813','idflowchart','idflowchart',{ts '2017-05-20 09:19:50.900'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --
