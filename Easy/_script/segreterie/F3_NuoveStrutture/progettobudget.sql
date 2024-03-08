
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA progettobudget --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettobudget]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettobudget] (
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
budget decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idprogettotipocosto int NULL,
idworkpackage int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
 CONSTRAINT xpkprogettobudget PRIMARY KEY (idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudget --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD budget decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN budget decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettotipocosto int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idprogettotipocosto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idworkpackage int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idworkpackage int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN sortcode int NULL
GO

-- VERIFICA DI progettobudget IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettobudget'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','int','assistenza','idprogettobudget','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','decimal(9,2)','assistenza','budget','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','idprogettotipocosto','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','idworkpackage','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','sortcode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI progettobudget IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettobudget')
UPDATE customobject set isreal = 'S' where objectname = 'progettobudget'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettobudget', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettobudget')
UPDATE [tabledescr] SET description = 'Budget per le categorie di costo di un progetto ',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 12:14:40.277'},lu = 'assistenza',title = 'Budget per le categorie di costo di un progetto ' WHERE tablename = 'progettobudget'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettobudget','Budget per le categorie di costo di un progetto ',null,'N',{ts '2020-06-18 12:14:40.277'},'assistenza','Budget per le categorie di costo di un progetto ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Budget iniziale',kind = 'S',lt = {ts '2020-12-09 16:32:07.130'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progettobudget','5','9','2','Budget iniziale','S',{ts '2020-12-09 16:32:07.130'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudget','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voce di costo',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettobudget','4',null,null,'Voce di costo','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','progettobudget','4',null,null,'Workpackage','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine di visualizzazione',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','progettobudget','4',null,null,'Ordine di visualizzazione','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

