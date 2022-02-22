
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


-- CREAZIONE TABELLA corsostudiolivello --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudiolivello]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[corsostudiolivello] (
idcorsostudiolivello int NOT NULL,
idcorsostudiokind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NULL,
 CONSTRAINT xpkcorsostudiolivello PRIMARY KEY (idcorsostudiolivello
)
)
END
GO

-- VERIFICA STRUTTURA corsostudiolivello --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'idcorsostudiolivello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD idcorsostudiolivello int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiolivello') and col.name = 'idcorsostudiolivello' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiolivello] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD idcorsostudiokind int NULL 
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN idcorsostudiokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiolivello') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiolivello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudiolivello') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudiolivello] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudiolivello' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudiolivello] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [corsostudiolivello] ALTER COLUMN title varchar(50) NULL
GO

-- VERIFICA DI corsostudiolivello IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'corsostudiolivello'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiolivello','int','ASSISTENZA','idcorsostudiolivello','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiolivello','int','ASSISTENZA','idcorsostudiokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiolivello','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudiolivello','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudiolivello','varchar(50)','ASSISTENZA','title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI corsostudiolivello IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'corsostudiolivello')
UPDATE customobject set isreal = 'S' where objectname = 'corsostudiolivello'
ELSE
INSERT INTO customobject (objectname, isreal) values('corsostudiolivello', 'S')
GO

-- GENERAZIONE DATI PER corsostudiolivello --
IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '1')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '11',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Primo livello' WHERE idcorsostudiolivello = '1'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('1','11',{ts '2018-06-11 11:35:00.653'},'ferdinando','Primo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '2')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '11',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Secondo livello' WHERE idcorsostudiolivello = '2'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('2','11',{ts '2018-06-11 11:35:00.653'},'ferdinando','Secondo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '3')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Primo livello' WHERE idcorsostudiolivello = '3'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('3','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','Primo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '4')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '2',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Secondo livello' WHERE idcorsostudiolivello = '4'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('4','2',{ts '2018-06-11 11:35:00.653'},'ferdinando','Secondo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '5')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Primo livello' WHERE idcorsostudiolivello = '5'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('5','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','Primo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '6')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '3',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Secondo livello' WHERE idcorsostudiolivello = '6'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('6','3',{ts '2018-06-11 11:35:00.653'},'ferdinando','Secondo livello')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '7')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Corso di laurea' WHERE idcorsostudiolivello = '7'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('7','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Corso di laurea')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '8')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Corso di laurea magistrale' WHERE idcorsostudiolivello = '8'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('8','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Corso di laurea magistrale')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '9')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '1',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'Corso di laurea magistrale c. u.' WHERE idcorsostudiolivello = '9'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('9','1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Corso di laurea magistrale c. u.')
GO

IF exists(SELECT * FROM [corsostudiolivello] WHERE idcorsostudiolivello = '10')
UPDATE [corsostudiolivello] SET idcorsostudiokind = '6',lt = {ts '2020-05-15 16:08:59.883'},lu = 'ASSISTENZA',title = 'test_e2e_cHokFVhPWtPtjHRBvLcfROEYtVqXujOvnhdMcWNjT' WHERE idcorsostudiolivello = '10'
ELSE
INSERT INTO [corsostudiolivello] (idcorsostudiolivello,idcorsostudiokind,lt,lu,title) VALUES ('10','6',{ts '2020-05-15 16:08:59.883'},'ASSISTENZA','test_e2e_cHokFVhPWtPtjHRBvLcfROEYtVqXujOvnhdMcWNjT')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudiolivello')
UPDATE [tabledescr] SET description = 'VOCABOLARIO dei livelli dei  2.4.2 Corso di studio ',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:25:03.270'},lu = 'assistenza',title = 'Livelli dei corsi di studio' WHERE tablename = 'corsostudiolivello'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudiolivello','VOCABOLARIO dei livelli dei  2.4.2 Corso di studio ',null,'N',{ts '2018-07-20 11:25:03.270'},'assistenza','Livelli dei corsi di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia del corso di studi',kind = 'S',lt = {ts '2019-09-05 11:33:32.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','corsostudiolivello','4',null,null,'Tipologia del corso di studi','S',{ts '2019-09-05 11:33:32.520'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-09-05 11:33:55.317'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiolivello','corsostudiolivello','4',null,null,'Identificativo','S',{ts '2019-09-05 11:33:55.317'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:22:10.800'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudiolivello','8',null,null,null,'S',{ts '2018-07-18 16:22:10.800'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:22:10.800'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudiolivello','64',null,null,null,'S',{ts '2018-07-18 16:22:10.800'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Livello',kind = 'S',lt = {ts '2019-09-05 11:33:55.317'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','corsostudiolivello','50',null,null,'Livello','S',{ts '2019-09-05 11:33:55.317'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3237')
UPDATE [relation] SET childtable = 'corsostudiolivello',description = 'corso di studio di cui descrive il livello',lt = {ts '2018-07-18 16:22:39.727'},lu = 'assistenza',parenttable = 'corsostudio',title = null WHERE idrelation = '3237'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3237','corsostudiolivello','corso di studio di cui descrive il livello',{ts '2018-07-18 16:22:39.727'},'assistenza','corsostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --

