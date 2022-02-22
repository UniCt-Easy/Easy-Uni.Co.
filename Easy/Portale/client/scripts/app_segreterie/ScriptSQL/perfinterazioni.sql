
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


-- CREAZIONE TABELLA perfinterazioni --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfinterazioni]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfinterazioni] (
idperfvalutazionepersonale int NOT NULL,
idperfinterazioni int NOT NULL,
commenti varchar(max) NULL,
commentival varchar(max) NULL,
data datetime NULL,
idperfinterazionekind int NOT NULL,
 CONSTRAINT xpkperfinterazioni PRIMARY KEY (idperfvalutazionepersonale,
idperfinterazioni
)
)
END
GO

-- VERIFICA STRUTTURA perfinterazioni --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazioni') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'idperfinterazioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD idperfinterazioni int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazioni') and col.name = 'idperfinterazioni' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazioni] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'commenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD commenti varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN commenti varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'commentival' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD commentival varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN commentival varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazioni' and C.name = 'idperfinterazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazioni] ADD idperfinterazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazioni') and col.name = 'idperfinterazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazioni] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfinterazioni] ALTER COLUMN idperfinterazionekind int NOT NULL
GO

-- VERIFICA DI perfinterazioni IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfinterazioni'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfinterazioni','int','assistenza','idperfinterazioni','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfinterazioni','int','assistenza','idperfvalutazionepersonale','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazioni','varchar(max)','assistenza','commenti','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazioni','varchar(max)','assistenza','commentival','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfinterazioni','datetime','assistenza','data','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfinterazioni','int','assistenza','idperfinterazionekind','4','S','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI perfinterazioni IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfinterazioni')
UPDATE customobject set isreal = 'S' where objectname = 'perfinterazioni'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfinterazioni', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfinterazioni')
UPDATE [tabledescr] SET description = 'Interazioni',idapplication = '2',isdbo = 'S',lt = {ts '2021-09-15 16:48:59.077'},lu = 'Generator',title = 'Interazioni' WHERE tablename = 'perfinterazioni'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfinterazioni','Interazioni','2','S',{ts '2021-09-15 16:48:59.077'},'Generator','Interazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'commenti' AND tablename = 'perfinterazioni')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Commenti valutato',kind = 'S',lt = {ts '2021-07-27 09:25:21.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'commenti' AND tablename = 'perfinterazioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('commenti','perfinterazioni','-1',null,null,'Commenti valutato','S',{ts '2021-07-27 09:25:21.100'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'commentival' AND tablename = 'perfinterazioni')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Commenti valutatore',kind = 'S',lt = {ts '2021-07-27 14:46:36.107'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'commentival' AND tablename = 'perfinterazioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('commentival','perfinterazioni','-1',null,null,'Commenti valutatore','S',{ts '2021-07-27 14:46:36.107'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'perfinterazioni')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data',kind = 'S',lt = {ts '2021-07-27 14:05:47.107'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'perfinterazioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','perfinterazioni','8',null,null,'Data','S',{ts '2021-07-27 14:05:47.107'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfinterazionekind' AND tablename = 'perfinterazioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di interazione',kind = 'S',lt = {ts '2021-07-27 09:25:21.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfinterazionekind' AND tablename = 'perfinterazioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfinterazionekind','perfinterazioni','4',null,null,'Tipo di interazione','S',{ts '2021-07-27 09:25:21.100'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfinterazioni' AND tablename = 'perfinterazioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-27 14:05:47.107'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfinterazioni' AND tablename = 'perfinterazioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfinterazioni','perfinterazioni','4',null,null,null,'S',{ts '2021-07-27 14:05:47.107'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfinterazioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-27 09:24:37.187'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfinterazioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazionepersonale','perfinterazioni','4',null,null,null,'S',{ts '2021-07-27 09:24:37.187'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

