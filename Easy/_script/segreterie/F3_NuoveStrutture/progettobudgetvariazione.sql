
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


-- CREAZIONE TABELLA progettobudgetvariazione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettobudgetvariazione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettobudgetvariazione] (
idprogettobudgetvariazione int NOT NULL,
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
idaccmotive varchar(36) NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(60) NULL,
newamount decimal(16,2) NULL,
 CONSTRAINT xpkprogettobudgetvariazione PRIMARY KEY (idprogettobudgetvariazione,
idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudgetvariazione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudgetvariazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudgetvariazione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudgetvariazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idaccmotive varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idaccmotive varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'newamount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD newamount decimal(16,2) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN newamount decimal(16,2) NULL
GO

-- VERIFICA DI progettobudgetvariazione IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettobudgetvariazione'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudgetvariazione','int','assistenza','idprogetto','4','N','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudgetvariazione','int','assistenza','idprogettobudget','4','N','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudgetvariazione','int','assistenza','idprogettobudgetvariazione','4','N','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(60)','assistenza','cu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(36)','assistenza','idaccmotive','36','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(36)','assistenza','idupb','36','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(60)','assistenza','lu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','decimal(16,2)','assistenza','newamount','9','N','decimal','System.Decimal','','2','''assistenza''','16','N')
GO

-- VERIFICA DI progettobudgetvariazione IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettobudgetvariazione')
UPDATE customobject set isreal = 'S' where objectname = 'progettobudgetvariazione'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettobudgetvariazione', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettobudgetvariazione')
UPDATE [tabledescr] SET description = 'Variazioni di budget del progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-11-30 10:50:04.907'},lu = 'assistenza',title = 'Variazioni di budget' WHERE tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettobudgetvariazione','Variazioni di budget del progetto',null,'N',{ts '2020-11-30 10:50:04.907'},'assistenza','Variazioni di budget')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettobudgetvariazione','8',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettobudgetvariazione','60',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Causale economico patrimoniale',kind = 'S',lt = {ts '2020-11-30 10:54:15.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccmotive' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive','progettobudgetvariazione','4',null,null,'Causale economico patrimoniale','S',{ts '2020-11-30 10:54:15.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettobudgetvariazione','4',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudget' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudget' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudget','progettobudgetvariazione','4',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudgetvariazione' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudgetvariazione' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudgetvariazione','progettobudgetvariazione','4',null,null,null,'S',{ts '2020-11-30 10:50:07.967'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Unità previsionale di base (UPB)',kind = 'S',lt = {ts '2020-11-30 10:54:15.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idupb' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','progettobudgetvariazione','4',null,null,'Unità previsionale di base (UPB)','S',{ts '2020-11-30 10:54:15.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettobudgetvariazione','8',null,null,null,'S',{ts '2020-11-30 10:50:07.967'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettobudgetvariazione','60',null,null,null,'S',{ts '2020-11-30 10:50:07.967'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newamount' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '9',col_precision = '16',col_scale = '2',description = 'Nuovo budget',kind = 'S',lt = {ts '2020-11-30 10:54:15.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(16,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'newamount' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newamount','progettobudgetvariazione','9','16','2','Nuovo budget','S',{ts '2020-11-30 10:54:15.167'},'assistenza','N','decimal(16,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

