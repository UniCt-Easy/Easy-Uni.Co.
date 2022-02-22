
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


-- CREAZIONE TABELLA registrationuserstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrationuserstatus] (
idregistrationuserstatus int NOT NULL,
title varchar(64) NULL,
 CONSTRAINT xpkregistrationuserstatus PRIMARY KEY (idregistrationuserstatus
)
)
END
GO

-- VERIFICA STRUTTURA registrationuserstatus --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserstatus' and C.name = 'idregistrationuserstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserstatus] ADD idregistrationuserstatus int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuserstatus') and col.name = 'idregistrationuserstatus' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuserstatus] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserstatus' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserstatus] ADD title varchar(64) NULL 
END
ELSE
	ALTER TABLE [registrationuserstatus] ALTER COLUMN title varchar(64) NULL
GO

-- VERIFICA DI registrationuserstatus IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrationuserstatus'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrationuserstatus','int','assistenza','idregistrationuserstatus','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrationuserstatus','varchar(64)','assistenza','title','64','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI registrationuserstatus IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrationuserstatus')
UPDATE customobject set isreal = 'S' where objectname = 'registrationuserstatus'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrationuserstatus', 'S')
GO

-- GENERAZIONE DATI PER registrationuserstatus --
IF exists(SELECT * FROM [registrationuserstatus] WHERE idregistrationuserstatus = '1')
UPDATE [registrationuserstatus] SET title = 'In attesa' WHERE idregistrationuserstatus = '1'
ELSE
INSERT INTO [registrationuserstatus] (idregistrationuserstatus,title) VALUES ('1','In attesa')
GO

IF exists(SELECT * FROM [registrationuserstatus] WHERE idregistrationuserstatus = '2')
UPDATE [registrationuserstatus] SET title = 'Autorizzata' WHERE idregistrationuserstatus = '2'
ELSE
INSERT INTO [registrationuserstatus] (idregistrationuserstatus,title) VALUES ('2','Autorizzata')
GO

IF exists(SELECT * FROM [registrationuserstatus] WHERE idregistrationuserstatus = '3')
UPDATE [registrationuserstatus] SET title = 'Rifiutata' WHERE idregistrationuserstatus = '3'
ELSE
INSERT INTO [registrationuserstatus] (idregistrationuserstatus,title) VALUES ('3','Rifiutata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registrationuserstatus')
UPDATE [tabledescr] SET description = 'Stati della richiesta di registrazione',idapplication = '2',isdbo = 'S',lt = {ts '2021-03-22 13:33:01.187'},lu = 'assistenza',title = 'Stati della richiesta di registrazione' WHERE tablename = 'registrationuserstatus'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registrationuserstatus','Stati della richiesta di registrazione','2','S',{ts '2021-03-22 13:33:01.187'},'assistenza','Stati della richiesta di registrazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrationuserstatus' AND tablename = 'registrationuserstatus')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 13:33:05.400'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrationuserstatus' AND tablename = 'registrationuserstatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrationuserstatus','registrationuserstatus','4',null,null,null,'S',{ts '2021-03-22 13:33:05.400'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'registrationuserstatus')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2021-03-22 13:33:20.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'registrationuserstatus'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','registrationuserstatus','64',null,null,'Stato','S',{ts '2021-03-22 13:33:20.753'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

