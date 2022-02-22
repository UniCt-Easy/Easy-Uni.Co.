
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


-- CREAZIONE TABELLA registrationuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrationuser] (
idregistrationuser int NOT NULL,
cf varchar(16) NULL,
email varchar(1024) NULL,
esercizio int NULL,
forename varchar(49) NULL,
idregistrationuserstatus int NULL,
login varchar(60) NULL,
matricola varchar(50) NULL,
surname varchar(50) NULL,
userkind int NULL,
usertype varchar(50) NULL,
 CONSTRAINT xpkregistrationuser PRIMARY KEY (idregistrationuser
)
)
END
GO

-- VERIFICA STRUTTURA registrationuser --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'idregistrationuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD idregistrationuser int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuser') and col.name = 'idregistrationuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD cf varchar(16) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN cf varchar(16) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD email varchar(1024) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN email varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'esercizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD esercizio int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN esercizio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'forename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD forename varchar(49) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN forename varchar(49) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'idregistrationuserstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD idregistrationuserstatus int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN idregistrationuserstatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'login' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD login varchar(60) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN login varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'matricola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD matricola varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN matricola varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'surname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD surname varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN surname varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'userkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD userkind int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN userkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'usertype' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD usertype varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN usertype varchar(50) NULL
GO

-- VERIFICA DI registrationuser IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrationuser'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrationuser','int','assistenza','idregistrationuser','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','varchar(16)','assistenza','cf','16','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','varchar(1024)','assistenza','email','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','int','assistenza','esercizio','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','varchar(49)','assistenza','forename','49','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','int','assistenza','idregistrationuserstatus','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','varchar(60)','assistenza','login','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','varchar(50)','assistenza','matricola','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','varchar(50)','assistenza','surname','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','int','assistenza','userkind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuser','varchar(50)','assistenza','usertype','50','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI registrationuser IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrationuser')
UPDATE customobject set isreal = 'S' where objectname = 'registrationuser'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrationuser', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registrationuser')
UPDATE [tabledescr] SET description = 'Richiesta di accesso',idapplication = '2',isdbo = 'S',lt = {ts '2022-02-11 15:57:29.243'},lu = 'Generator',title = 'Richiesta di accesso' WHERE tablename = 'registrationuser'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registrationuser','Richiesta di accesso','2','S',{ts '2022-02-11 15:57:29.243'},'Generator','Richiesta di accesso')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'Codice fiscale',kind = 'S',lt = {ts '2021-03-22 12:40:23.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(16)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cf' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','registrationuser','16',null,null,'Codice fiscale','S',{ts '2021-03-22 12:40:23.503'},'assistenza','N','varchar(16)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'E-Mail',kind = 'S',lt = {ts '2021-03-22 12:40:23.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email','registrationuser','1024',null,null,'E-Mail','S',{ts '2021-03-22 12:40:23.507'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'esercizio' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'esercizio' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('esercizio','registrationuser','4',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'forename' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '49',col_precision = null,col_scale = null,description = 'Nome',kind = 'S',lt = {ts '2021-03-22 12:40:23.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(49)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'forename' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('forename','registrationuser','49',null,null,'Nome','S',{ts '2021-03-22 12:40:23.510'},'assistenza','N','varchar(49)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrationuser' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrationuser' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrationuser','registrationuser','4',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrationuserstatus' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato della richiesta',kind = 'S',lt = {ts '2021-03-22 13:50:21.817'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrationuserstatus' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrationuserstatus','registrationuser','4',null,null,'Stato della richiesta','S',{ts '2021-03-22 13:50:21.817'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'login' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'login' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('login','registrationuser','60',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'matricola' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'matricola' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('matricola','registrationuser','50',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surname' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome',kind = 'S',lt = {ts '2021-03-22 12:40:23.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surname' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surname','registrationuser','50',null,null,'Cognome','S',{ts '2021-03-22 12:40:23.510'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'userkind' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di accesso',kind = 'S',lt = {ts '2021-03-22 12:40:23.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'userkind' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('userkind','registrationuser','4',null,null,'Tipologia di accesso','S',{ts '2021-03-22 12:40:23.510'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'usertype' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Categoria di utente',kind = 'S',lt = {ts '2021-03-22 12:40:23.513'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'usertype' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('usertype','registrationuser','50',null,null,'Categoria di utente','S',{ts '2021-03-22 12:40:23.513'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

