
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


-- CREAZIONE TABELLA strutturaresponsabile --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaresponsabile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[strutturaresponsabile] (
idstrutturaresponsabile int NOT NULL,
idstruttura int NOT NULL,
idperfruolo varchar(50) NULL,
idreg int NULL,
start date NULL,
stop date NULL,
 CONSTRAINT xpkstrutturaresponsabile PRIMARY KEY (idstrutturaresponsabile,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA strutturaresponsabile --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idstrutturaresponsabile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idstrutturaresponsabile int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturaresponsabile') and col.name = 'idstrutturaresponsabile' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturaresponsabile] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturaresponsabile') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturaresponsabile] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idperfruolo varchar(50) NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN idperfruolo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD start date NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD stop date NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN stop date NULL
GO

-- VERIFICA DI strutturaresponsabile IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'strutturaresponsabile'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaresponsabile','int','assistenza','idstruttura','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaresponsabile','int','assistenza','idstrutturaresponsabile','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaresponsabile','varchar(50)','assistenza','idperfruolo','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaresponsabile','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaresponsabile','date','assistenza','start','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaresponsabile','date','assistenza','stop','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

-- VERIFICA DI strutturaresponsabile IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'strutturaresponsabile')
UPDATE customobject set isreal = 'S' where objectname = 'strutturaresponsabile'
ELSE
INSERT INTO customobject (objectname, isreal) values('strutturaresponsabile', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'strutturaresponsabile')
UPDATE [tabledescr] SET description = 'Responsabili, valutatori e approvatori',idapplication = '2',isdbo = 'S',lt = {ts '2021-12-01 11:32:52.010'},lu = 'Generator',title = 'Responsabili, valutatori e approvatori' WHERE tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('strutturaresponsabile','Responsabili, valutatori e approvatori','2','S',{ts '2021-12-01 11:32:52.010'},'Generator','Responsabili, valutatori e approvatori')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Ruolo ',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo','strutturaresponsabile','50',null,null,'Ruolo ','S',{ts '2021-11-19 10:17:24.327'},'Generator','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Membro del personale',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','strutturaresponsabile','4',null,null,'Membro del personale','S',{ts '2021-11-19 10:17:24.327'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','strutturaresponsabile','4',null,null,'','S',{ts '2021-11-19 10:17:24.327'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstrutturaresponsabile' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstrutturaresponsabile' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstrutturaresponsabile','strutturaresponsabile','4',null,null,'','S',{ts '2021-11-19 10:17:24.327'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio validità',kind = 'S',lt = {ts '2021-11-30 16:15:12.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','strutturaresponsabile','3',null,null,'Data inizio validità','S',{ts '2021-11-30 16:15:12.060'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine validità',kind = 'S',lt = {ts '2021-11-30 16:15:12.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','strutturaresponsabile','3',null,null,'Data fine validità','S',{ts '2021-11-30 16:15:12.060'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --

