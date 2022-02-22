
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


-- CREAZIONE TABELLA perfschedacambiostato --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfschedacambiostato]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfschedacambiostato] (
idperfschedacambiostato int NOT NULL,
idperfruolo varchar(50) NULL,
idperfruolo_mail varchar(50) NULL,
idperfschedastatus int NULL,
idperfschedastatus_to int NULL,
 CONSTRAINT xpkperfschedacambiostato PRIMARY KEY (idperfschedacambiostato
)
)
END
GO

-- VERIFICA STRUTTURA perfschedacambiostato --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfschedacambiostato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfschedacambiostato int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfschedacambiostato') and col.name = 'idperfschedacambiostato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfschedacambiostato] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfruolo varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfruolo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfruolo_mail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfruolo_mail varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfruolo_mail varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfschedastatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfschedastatus int NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfschedastatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfschedastatus_to' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfschedastatus_to int NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfschedastatus_to int NULL
GO

-- VERIFICA DI perfschedacambiostato IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfschedacambiostato'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostato','int','assistenza','idperfschedacambiostato','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostato','varchar(50)','assistenza','idperfruolo','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostato','varchar(50)','assistenza','idperfruolo_mail','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostato','int','assistenza','idperfschedastatus','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostato','int','assistenza','idperfschedastatus_to','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI perfschedacambiostato IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfschedacambiostato')
UPDATE customobject set isreal = 'S' where objectname = 'perfschedacambiostato'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfschedacambiostato', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfschedacambiostato')
UPDATE [tabledescr] SET description = 'Cambi di stato delle schede',idapplication = null,isdbo = 'N',lt = {ts '2021-05-24 14:43:07.117'},lu = 'assistenza',title = 'Cambi di stato' WHERE tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfschedacambiostato','Cambi di stato delle schede',null,'N',{ts '2021-05-24 14:43:07.117'},'assistenza','Cambi di stato')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Chi lo può cambiare',kind = 'S',lt = {ts '2021-06-07 13:01:42.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo','perfschedacambiostato','50',null,null,'Chi lo può cambiare','S',{ts '2021-06-07 13:01:42.357'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo_mail' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Chi viene avvisato via e-mail',kind = 'S',lt = {ts '2021-06-07 13:01:42.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo_mail' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo_mail','perfschedacambiostato','50',null,null,'Chi viene avvisato via e-mail','S',{ts '2021-06-07 13:01:42.357'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedacambiostato' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:43:09.787'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedacambiostato' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedacambiostato','perfschedacambiostato','4',null,null,null,'S',{ts '2021-05-24 14:43:09.787'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedastatus' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Da',kind = 'S',lt = {ts '2021-05-24 14:44:28.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedastatus' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedastatus','perfschedacambiostato','4',null,null,'Da','S',{ts '2021-05-24 14:44:28.830'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedastatus_to' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'A',kind = 'S',lt = {ts '2021-05-24 14:44:28.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedastatus_to' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedastatus_to','perfschedacambiostato','4',null,null,'A','S',{ts '2021-05-24 14:44:28.830'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

