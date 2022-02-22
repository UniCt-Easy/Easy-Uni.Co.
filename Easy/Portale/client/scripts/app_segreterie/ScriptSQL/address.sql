
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


-- CREAZIONE TABELLA address --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[address]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[address] (
idaddress int NOT NULL,
active char(1) NULL,
codeaddress varchar(20) NOT NULL,
description varchar(60) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkaddress PRIMARY KEY (idaddress
)
)
END
GO

-- VERIFICA STRUTTURA address --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'idaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD idaddress int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('address') and col.name = 'idaddress' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [address] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [address] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'codeaddress' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD codeaddress varchar(20) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('address') and col.name = 'codeaddress' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [address] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [address] ALTER COLUMN codeaddress varchar(20) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD description varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('address') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [address] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [address] ALTER COLUMN description varchar(60) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [address] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'address' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [address] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [address] ALTER COLUMN lu varchar(64) NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukaddress' and id=object_id('address'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukaddress
     ON address (codeaddress )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukaddress
     ON address (codeaddress )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1address' and id=object_id('address'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1address
     ON address (codeaddress )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1address
     ON address (codeaddress )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA DI address IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'address'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','address','int','ASSISTENZA','idaddress','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','address','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','address','varchar(20)','ASSISTENZA','codeaddress','20','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','address','varchar(60)','ASSISTENZA','description','60','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','address','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','address','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI address IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'address')
UPDATE customobject set isreal = 'S' where objectname = 'address'
ELSE
INSERT INTO customobject (objectname, isreal) values('address', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'address')
UPDATE [tabledescr] SET description = 'Tipo Indirizzo  (anagrafica)',idapplication = null,isdbo = 'S',lt = {ts '2017-05-20 10:15:37.403'},lu = 'nino',title = 'Tipo Indirizzo  (anagrafica)' WHERE tablename = 'address'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('address','Tipo Indirizzo  (anagrafica)',null,'S',{ts '2017-05-20 10:15:37.403'},'nino','Tipo Indirizzo  (anagrafica)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'address')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.010'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'address'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','address','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.010'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codeaddress' AND tablename = 'address')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '1900-01-01 03:00:17.643'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codeaddress' AND tablename = 'address'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codeaddress','address','20',null,null,'Codice','S',{ts '1900-01-01 03:00:17.643'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'address')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:50.353'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'address'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','address','60',null,null,'Descrizione','S',{ts '1900-01-01 02:59:50.353'},'nino','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaddress' AND tablename = 'address')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '#',kind = 'S',lt = {ts '1900-01-01 03:00:30.107'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaddress' AND tablename = 'address'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaddress','address','4',null,null,'#','S',{ts '1900-01-01 03:00:30.107'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'address')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:40.707'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'address'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','address','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:40.707'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'address')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:37.740'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'address'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','address','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:37.740'},'nino','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

