
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


-- CREAZIONE TABELLA tipoattform --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tipoattform]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tipoattform] (
idtipoattform int NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1) NOT NULL,
 CONSTRAINT xpktipoattform PRIMARY KEY (idtipoattform
)
)
END
GO

-- VERIFICA STRUTTURA tipoattform --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD idtipoattform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'idtipoattform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD title varchar(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN title varchar(1) NOT NULL
GO

-- VERIFICA DI tipoattform IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tipoattform'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattform','int','ASSISTENZA','idtipoattform','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tipoattform','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattform','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattform','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tipoattform','varchar(1)','ASSISTENZA','title','1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tipoattform IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tipoattform')
UPDATE customobject set isreal = 'S' where objectname = 'tipoattform'
ELSE
INSERT INTO customobject (objectname, isreal) values('tipoattform', 'S')
GO

-- GENERAZIONE DATI PER tipoattform --
IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '1')
UPDATE [tipoattform] SET description = 'Attività formative relative alla formazione di base',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A' WHERE idtipoattform = '1'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('1','Attività formative relative alla formazione di base',{ts '2018-06-11 11:35:00.653'},'ferdinando','A')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '2')
UPDATE [tipoattform] SET description = 'Attività formative caratterizzanti il livello del corso',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'B' WHERE idtipoattform = '2'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('2','Attività formative caratterizzanti il livello del corso',{ts '2018-06-11 11:35:00.653'},'ferdinando','B')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '3')
UPDATE [tipoattform] SET description = 'Attività formative un uno o più ambiti affini o integrativi',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C' WHERE idtipoattform = '3'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('3','Attività formative un uno o più ambiti affini o integrativi',{ts '2018-06-11 11:35:00.653'},'ferdinando','C')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '4')
UPDATE [tipoattform] SET description = 'Attività formative scelte dallo studente',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'D' WHERE idtipoattform = '4'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('4','Attività formative scelte dallo studente',{ts '2018-06-11 11:35:00.653'},'ferdinando','D')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '5')
UPDATE [tipoattform] SET description = 'Attività formative relative alla prova finale e al conseguimento del titolo',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'E' WHERE idtipoattform = '5'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('5','Attività formative relative alla prova finale e al conseguimento del titolo',{ts '2018-06-11 11:35:00.653'},'ferdinando','E')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '6')
UPDATE [tipoattform] SET description = 'Altre attività volte alla conoscenza di una lingua, abilità informatiche, relazionali o utili nell''inserimento del mondo del lavoro, tirocini formativi e di orientamento, ecc.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'F' WHERE idtipoattform = '6'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('6','Altre attività volte alla conoscenza di una lingua, abilità informatiche, relazionali o utili nell''inserimento del mondo del lavoro, tirocini formativi e di orientamento, ecc.',{ts '2018-06-11 11:35:00.653'},'ferdinando','F')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '7')
UPDATE [tipoattform] SET description = 'Attività formative in ambiti disciplinari affini o integrativi a quelli di base e caratterizzanti, anche con riguardo alle culture di contesto e alla formazione interdisciplinare ',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'R' WHERE idtipoattform = '7'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('7','Attività formative in ambiti disciplinari affini o integrativi a quelli di base e caratterizzanti, anche con riguardo alle culture di contesto e alla formazione interdisciplinare ',{ts '2018-06-11 11:35:00.653'},'ferdinando','R')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '8')
UPDATE [tipoattform] SET description = 'Attività formative per stages, tirocinipresso imprese o enti pubblici o privati, ordini professionali',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'S' WHERE idtipoattform = '8'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('8','Attività formative per stages, tirocinipresso imprese o enti pubblici o privati, ordini professionali',{ts '2018-06-11 11:35:00.653'},'ferdinando','S')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '14')
UPDATE [tipoattform] SET description = '-',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = '9' WHERE idtipoattform = '14'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('14','-',{ts '2018-06-11 11:35:00.653'},'ferdinando','9')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '15')
UPDATE [tipoattform] SET description = 'Attività formative caratterizzanti transitate ed affini',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'T' WHERE idtipoattform = '15'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('15','Attività formative caratterizzanti transitate ed affini',{ts '2018-06-11 11:35:00.653'},'ferdinando','T')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tipoattform')
UPDATE [tabledescr] SET description = 'VOCABOLARIO classificazione delle attività formative del MIUR',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 15:38:37.880'},lu = 'assistenza',title = 'VOCABOLARIO classificazione delle attività formative del MIUR' WHERE tablename = 'tipoattform'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tipoattform','VOCABOLARIO classificazione delle attività formative del MIUR','3','S',{ts '2021-02-19 15:38:37.880'},'assistenza','VOCABOLARIO classificazione delle attività formative del MIUR')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'tipoattform')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2019-09-20 18:42:34.627'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'tipoattform'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','tipoattform','256',null,null,'Descrizione','S',{ts '2019-09-20 18:42:34.627'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipoattform' AND tablename = 'tipoattform')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:08:05.573'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipoattform' AND tablename = 'tipoattform'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipoattform','tipoattform','4',null,null,null,'S',{ts '2018-07-18 17:08:05.573'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tipoattform')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:08:05.573'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tipoattform'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tipoattform','8',null,null,null,'S',{ts '2018-07-18 17:08:05.573'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tipoattform')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:08:05.573'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tipoattform'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tipoattform','64',null,null,null,'S',{ts '2018-07-18 17:08:05.573'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'tipoattform')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-20 18:42:34.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'tipoattform'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','tipoattform','1',null,null,'Denominazione','S',{ts '2019-09-20 18:42:34.630'},'assistenza','N','varchar(1)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

