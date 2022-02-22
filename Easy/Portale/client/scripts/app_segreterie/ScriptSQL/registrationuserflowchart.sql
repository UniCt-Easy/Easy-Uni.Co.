
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


-- CREAZIONE TABELLA registrationuserflowchart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserflowchart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrationuserflowchart] (
idregistrationuser int NOT NULL,
idflowchart varchar(34) NOT NULL,
 CONSTRAINT xpkregistrationuserflowchart PRIMARY KEY (idregistrationuser,
idflowchart
)
)
END
GO

-- VERIFICA STRUTTURA registrationuserflowchart --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserflowchart' and C.name = 'idregistrationuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserflowchart] ADD idregistrationuser int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuserflowchart') and col.name = 'idregistrationuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuserflowchart] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserflowchart' and C.name = 'idflowchart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserflowchart] ADD idflowchart varchar(34) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuserflowchart') and col.name = 'idflowchart' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuserflowchart] drop constraint '+@vincolo)
END
GO

-- VERIFICA DI registrationuserflowchart IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrationuserflowchart'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrationuserflowchart','varchar(34)','assistenza','idflowchart','34','S','varchar','System.String','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrationuserflowchart','int','assistenza','idregistrationuser','4','S','int','System.Int32','','','''assistenza''','','S')
GO

-- VERIFICA DI registrationuserflowchart IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrationuserflowchart')
UPDATE customobject set isreal = 'S' where objectname = 'registrationuserflowchart'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrationuserflowchart', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registrationuserflowchart')
UPDATE [tabledescr] SET description = 'Autorizzazioni richieste (Nodi dell''organigramma)',idapplication = '2',isdbo = 'S',lt = {ts '2021-03-22 13:33:28.070'},lu = 'assistenza',title = 'Autorizzazioni richieste' WHERE tablename = 'registrationuserflowchart'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registrationuserflowchart','Autorizzazioni richieste (Nodi dell''organigramma)','2','S',{ts '2021-03-22 13:33:28.070'},'assistenza','Autorizzazioni richieste')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idflowchart' AND tablename = 'registrationuserflowchart')
UPDATE [coldescr] SET col_len = '34',col_precision = null,col_scale = null,description = 'Autorizzazione',kind = 'S',lt = {ts '2021-03-22 13:21:16.620'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(34)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idflowchart' AND tablename = 'registrationuserflowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idflowchart','registrationuserflowchart','34',null,null,'Autorizzazione','S',{ts '2021-03-22 13:21:16.620'},'assistenza','S','varchar(34)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrationuser' AND tablename = 'registrationuserflowchart')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 13:20:44.237'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrationuser' AND tablename = 'registrationuserflowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrationuser','registrationuserflowchart','4',null,null,null,'S',{ts '2021-03-22 13:20:44.237'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

