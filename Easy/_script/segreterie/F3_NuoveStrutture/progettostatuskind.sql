
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


--[DBO]--
-- CREAZIONE TABELLA progettostatuskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettostatuskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettostatuskind] (
idprogettostatuskind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkprogettostatuskind PRIMARY KEY (idprogettostatuskind
)
)
END
GO

-- VERIFICA STRUTTURA progettostatuskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD idprogettostatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'idprogettostatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI progettostatuskind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettostatuskind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettostatuskind','int','ASSISTENZA','idprogettostatuskind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettostatuskind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettostatuskind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettostatuskind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettostatuskind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettostatuskind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettostatuskind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettostatuskind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettostatuskind')
UPDATE customobject set isreal = 'S' where objectname = 'progettostatuskind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettostatuskind', 'S')
GO

-- GENERAZIONE DATI PER progettostatuskind --
IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '1')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '1',title = 'Bozza' WHERE idprogettostatuskind = '1'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('1',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','1','Bozza')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '2')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '2',title = 'Inserito' WHERE idprogettostatuskind = '2'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('2',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','2','Inserito')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '3')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '3',title = 'Non presentato' WHERE idprogettostatuskind = '3'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('3',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','3','Non presentato')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '4')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '4',title = 'Presentato' WHERE idprogettostatuskind = '4'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('4',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','4','Presentato')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '5')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinandio',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '5',title = 'Escluso' WHERE idprogettostatuskind = '5'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('5',{ts '2019-10-19 09:05:00.000'},'ferdinandio',{ts '2019-10-19 09:05:00.000'},'ferdinando','5','Escluso')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '6')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '6',title = 'Approvato in negoziazione' WHERE idprogettostatuskind = '6'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('6',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','6','Approvato in negoziazione')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '7')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '7',title = 'Validazione risorse umane' WHERE idprogettostatuskind = '7'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('7',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','7','Validazione risorse umane')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '8')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '8',title = 'Operativo' WHERE idprogettostatuskind = '8'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('8',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','8','Operativo')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '9')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '9',title = 'Rinuncia-Trasferimento-Revoca' WHERE idprogettostatuskind = '9'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('9',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','9','Rinuncia-Trasferimento-Revoca')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '10')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '10',title = 'Sospeso' WHERE idprogettostatuskind = '10'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('10',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','10','Sospeso')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '11')
UPDATE [progettostatuskind] SET ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '11',title = 'Concluso' WHERE idprogettostatuskind = '11'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,ct,cu,lt,lu,sortcode,title) VALUES ('11',{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','11','Concluso')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettostatuskind')
UPDATE [tabledescr] SET description = 'Stato dei 2.7.1 progetti o attivit?',idapplication = null,isdbo = 'N',lt = {ts '2020-06-12 15:43:50.317'},lu = 'assistenza',title = 'Stato dei progetti o attivit?' WHERE tablename = 'progettostatuskind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettostatuskind','Stato dei 2.7.1 progetti o attivit?',null,'N',{ts '2020-06-12 15:43:50.317'},'assistenza','Stato dei progetti o attivit?')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:43:52.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettostatuskind','8',null,null,null,'S',{ts '2020-06-12 15:43:52.663'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettostatuskind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:43:52.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettostatuskind','64',null,null,null,'S',{ts '2020-06-12 15:43:52.663'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:43:52.663'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progettostatuskind','4',null,null,null,'S',{ts '2020-06-12 15:43:52.663'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettostatuskind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:43:52.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettostatuskind','8',null,null,null,'S',{ts '2020-06-12 15:43:52.663'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettostatuskind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:43:52.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettostatuskind','64',null,null,null,'S',{ts '2020-06-12 15:43:52.663'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'progettostatuskind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:43:52.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','progettostatuskind','4',null,null,null,'S',{ts '2020-06-12 15:43:52.663'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettostatuskind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-12 15:43:52.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettostatuskind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettostatuskind','50',null,null,null,'S',{ts '2020-06-12 15:43:52.663'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

