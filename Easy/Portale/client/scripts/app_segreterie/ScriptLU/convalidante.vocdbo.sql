
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



-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'convalidante')
UPDATE [tabledescr] SET description = 'Insegnamento realmente svolto dallo studente, parte di una 2.2.11 Convalida o riconoscimento',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 16:11:52.553'},lu = 'assistenza',title = 'Insegnamento realmente svolto dallo studente, parte di una convalida o riconoscimento' WHERE tablename = 'convalidante'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('convalidante','Insegnamento realmente svolto dallo studente, parte di una 2.2.11 Convalida o riconoscimento',null,'N',{ts '2018-07-20 16:11:52.553'},'assistenza','Insegnamento realmente svolto dallo studente, parte di una convalida o riconoscimento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'changes' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-18 16:21:45.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'changes' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('changes','convalidante','1',null,null,null,'S',{ts '2019-11-18 16:21:45.663'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'changesother' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Changes other',kind = 'S',lt = {ts '2019-11-18 16:41:07.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'changesother' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('changesother','convalidante','-1',null,null,'Changes other','S',{ts '2019-11-18 16:41:07.137'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:12:14.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','convalidante','8',null,null,null,'S',{ts '2018-07-20 16:12:14.907'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:12:14.910'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','convalidante','64',null,null,null,'S',{ts '2018-07-20 16:12:14.910'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idchangeskind' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Changes kind',kind = 'S',lt = {ts '2019-11-18 16:41:07.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idchangeskind' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idchangeskind','convalidante','4',null,null,'Changes kind','S',{ts '2019-11-18 16:41:07.137'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idconvalida' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Convalida',kind = 'S',lt = {ts '2019-11-18 16:41:07.140'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idconvalida' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idconvalida','convalidante','4',null,null,'Convalida','S',{ts '2019-11-18 16:41:07.140'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idconvalidante' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:12:14.910'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idconvalidante' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idconvalidante','convalidante','4',null,null,null,'S',{ts '2018-07-20 16:12:14.910'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddichiar' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Altro titolo',kind = 'S',lt = {ts '2019-11-18 16:41:07.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddichiar' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddichiar','convalidante','4',null,null,'Altro titolo','S',{ts '2019-11-18 16:41:07.140'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica programmata',kind = 'S',lt = {ts '2020-04-14 16:13:39.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','convalidante','4',null,null,'Didattica programmata','S',{ts '2020-04-14 16:13:39.643'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizione' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione della convalida',kind = 'S',lt = {ts '2020-04-14 16:13:39.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizione' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizione','convalidante','4',null,null,'Iscrizione della convalida','S',{ts '2020-04-14 16:13:39.647'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizione_from' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione del sostenimento',kind = 'S',lt = {ts '2020-04-14 16:13:39.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizione_from' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizione_from','convalidante','4',null,null,'Iscrizione del sostenimento','S',{ts '2020-04-14 16:13:39.647'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizionebmi' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione al bando di mobilità internazionale',kind = 'S',lt = {ts '2020-04-14 16:13:39.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizionebmi' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizionebmi','convalidante','4',null,null,'Iscrizione al bando di mobilità internazionale','S',{ts '2020-04-14 16:13:39.647'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanza' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istanza',kind = 'S',lt = {ts '2019-11-18 16:41:07.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanza' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanza','convalidante','4',null,null,'Istanza','S',{ts '2019-11-18 16:41:07.140'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrstud' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Learning agreements for studies',kind = 'S',lt = {ts '2019-11-18 16:41:07.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrstud' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrstud','convalidante','4',null,null,'Learning agreements for studies','S',{ts '2019-11-18 16:41:07.140'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrtrainer' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Learning agreements for traineership',kind = 'S',lt = {ts '2019-11-18 16:41:07.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrtrainer' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrtrainer','convalidante','4',null,null,'Learning agreements for traineership','S',{ts '2019-11-18 16:41:07.143'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpratica' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Pratica',kind = 'S',lt = {ts '2019-11-18 16:41:07.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpratica' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpratica','convalidante','4',null,null,'Pratica','S',{ts '2019-11-18 16:41:07.143'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-18 16:41:07.143'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','convalidante','4',null,null,'Studente','S',{ts '2019-11-18 16:41:07.143'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsostenimento' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sostenimento',kind = 'S',lt = {ts '2019-11-18 16:41:07.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsostenimento' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsostenimento','convalidante','4',null,null,'Sostenimento','S',{ts '2019-11-18 16:41:07.143'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirocinioprogetto' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto del tirocinio',kind = 'S',lt = {ts '2019-11-18 16:41:07.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirocinioprogetto' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirocinioprogetto','convalidante','4',null,null,'Progetto del tirocinio','S',{ts '2019-11-18 16:41:07.143'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:12:14.910'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','convalidante','8',null,null,null,'S',{ts '2018-07-20 16:12:14.910'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'convalidante')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:12:14.910'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'convalidante'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','convalidante','64',null,null,null,'S',{ts '2018-07-20 16:12:14.910'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3348')
UPDATE [relation] SET childtable = 'convalidante',description = 'convalida di cui ? convalidante',lt = {ts '2018-07-20 16:12:14.553'},lu = 'assistenza',parenttable = 'convalida',title = null WHERE idrelation = '3348'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3348','convalidante','convalida di cui ? convalidante',{ts '2018-07-20 16:12:14.553'},'assistenza','convalida',null)
GO

-- FINE GENERAZIONE SCRIPT --

