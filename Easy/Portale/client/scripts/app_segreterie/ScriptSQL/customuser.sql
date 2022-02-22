
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


-- CREAZIONE TABELLA customuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[customuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customuser] (
idcustomuser varchar(50) NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
username varchar(50) NOT NULL,
 CONSTRAINT xpkcustomuser PRIMARY KEY (idcustomuser
)
)
END
GO

-- VERIFICA STRUTTURA customuser --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'idcustomuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD idcustomuser varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('customuser') and col.name = 'idcustomuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [customuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lastmodtimestamp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lastmodtimestamp datetime NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lastmodtimestamp datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lastmoduser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lastmoduser varchar(64) NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lastmoduser varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'customuser' and C.name = 'username' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [customuser] ADD username varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('customuser') and col.name = 'username' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [customuser] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [customuser] ALTER COLUMN username varchar(50) NOT NULL
GO

-- VERIFICA DI customuser IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'customuser'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','customuser','varchar(50)','SA','idcustomuser','50','S','varchar','System.String','','','''SA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','customuser','datetime','SA','ct','8','N','datetime','System.DateTime','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','customuser','varchar(64)','SA','cu','64','N','varchar','System.String','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','customuser','datetime','SA','lastmodtimestamp','8','N','datetime','System.DateTime','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','customuser','varchar(64)','SA','lastmoduser','64','N','varchar','System.String','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','customuser','datetime','SA','lt','8','N','datetime','System.DateTime','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','customuser','varchar(64)','SA','lu','64','N','varchar','System.String','','','''SA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','customuser','varchar(50)','SA','username','50','S','varchar','System.String','','','''SA''','','N')
GO

-- VERIFICA DI customuser IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'customuser')
UPDATE customobject set isreal = 'S' where objectname = 'customuser'
ELSE
INSERT INTO customobject (objectname, isreal) values('customuser', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'customuser')
UPDATE [tabledescr] SET description = 'Utenti',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:29.440'},lu = 'nino',title = 'Utenti' WHERE tablename = 'customuser'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('customuser','Utenti',null,'S',{ts '1900-01-01 03:00:29.440'},'nino','Utenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:46.803'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','customuser','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:46.803'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.237'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','customuser','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.237'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcustomuser' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice utente',kind = 'S',lt = {ts '1900-01-01 03:00:19.083'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idcustomuser' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcustomuser','customuser','50',null,null,'Codice utente','S',{ts '1900-01-01 03:00:19.083'},'nino','S','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lastmodtimestamp' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 03:00:26.590'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lastmodtimestamp' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lastmodtimestamp','customuser','8',null,null,'data ultima modifica','S',{ts '1900-01-01 03:00:26.590'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lastmoduser' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Utente ultima modifica',kind = 'S',lt = {ts '1900-01-01 03:00:26.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lastmoduser' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lastmoduser','customuser','64',null,null,'Utente ultima modifica','S',{ts '1900-01-01 03:00:26.937'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.363'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','customuser','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.363'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.393'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','customuser','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.393'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'username' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Nome utente',kind = 'S',lt = {ts '1900-01-01 03:00:19.087'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'username' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('username','customuser','50',null,null,'Nome utente','S',{ts '1900-01-01 03:00:19.087'},'nino','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '2960')
UPDATE [relation] SET childtable = 'customuser',description = 'Nome utente',lt = {ts '2017-05-20 09:20:14.730'},lu = 'lu',parenttable = 'webuser',title = 'Utenti' WHERE idrelation = '2960'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2960','customuser','Nome utente',{ts '2017-05-20 09:20:14.730'},'lu','webuser','Utenti')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3029')
UPDATE [relation] SET childtable = 'customuser',description = 'Nome utente',lt = {ts '2017-05-22 11:17:45.877'},lu = 'nino',parenttable = 'dbaccess',title = 'Utenti' WHERE idrelation = '3029'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3029','customuser','Nome utente',{ts '2017-05-22 11:17:45.877'},'nino','dbaccess','Utenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '2960' AND parentcol = 'username')
UPDATE [relationcol] SET childcol = 'username',lt = {ts '2017-05-20 09:20:14.797'},lu = 'lu' WHERE idrelation = '2960' AND parentcol = 'username'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('2960','username','username',{ts '2017-05-20 09:20:14.797'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

