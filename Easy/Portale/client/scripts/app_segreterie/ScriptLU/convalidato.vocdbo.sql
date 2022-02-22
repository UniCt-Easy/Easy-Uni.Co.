
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'convalidato')
UPDATE [tabledescr] SET description = 'Insegnamento riconosciuto allo studente a fronte di un altro sostenimento, parte di 2.2.11 Convalida/Riconoscimento/Dispensa',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 16:13:36.160'},lu = 'assistenza',title = 'Insegnamento riconosciuto allo studente a fronte di un altro sostenimento, parte di una convalida' WHERE tablename = 'convalidato'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('convalidato','Insegnamento riconosciuto allo studente a fronte di un altro sostenimento, parte di 2.2.11 Convalida/Riconoscimento/Dispensa',null,'N',{ts '2018-07-20 16:13:36.160'},'assistenza','Insegnamento riconosciuto allo studente a fronte di un altro sostenimento, parte di una convalida')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'changesother' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Changes other',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'changesother' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('changesother','convalidato','-1',null,null,'Changes other','S',{ts '2019-11-18 16:38:31.997'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:13:37.490'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','convalidato','8',null,null,null,'S',{ts '2018-07-20 16:13:37.490'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:13:37.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','convalidato','64',null,null,null,'S',{ts '2018-07-20 16:13:37.493'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattivform' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'attività formativa',kind = 'S',lt = {ts '2020-04-14 16:17:45.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattivform' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattivform','convalidato','4',null,null,'attività formativa','S',{ts '2020-04-14 16:17:45.457'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idchanges' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Changes',kind = 'S',lt = {ts '2020-07-02 10:47:42.247'},lu = 'mluisas',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idchanges' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idchanges','convalidato','4',null,null,'Changes','S',{ts '2020-07-02 10:47:42.247'},'mluisas','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idchangeskind' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Changes kind',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idchangeskind' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idchangeskind','convalidato','4',null,null,'Changes kind','S',{ts '2019-11-18 16:38:31.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idconvalida' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Convalida',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idconvalida' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idconvalida','convalidato','4',null,null,'Convalida','S',{ts '2019-11-18 16:38:31.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idconvalidato' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Convalidato',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idconvalidato' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idconvalidato','convalidato','4',null,null,'Convalidato','S',{ts '2019-11-18 16:38:31.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddichiar' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dichiarazione convalidata',kind = 'S',lt = {ts '2020-04-14 16:17:45.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddichiar' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddichiar','convalidato','4',null,null,'Dichiarazione convalidata','S',{ts '2020-04-14 16:17:45.457'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica programmata',kind = 'S',lt = {ts '2020-04-14 16:17:45.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','convalidato','4',null,null,'Didattica programmata','S',{ts '2020-04-14 16:17:45.457'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizione' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione della convalida',kind = 'S',lt = {ts '2020-04-14 16:17:45.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizione' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizione','convalidato','4',null,null,'Iscrizione della convalida','S',{ts '2020-04-14 16:17:45.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizione_from' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione del sostenimento',kind = 'S',lt = {ts '2020-04-14 16:17:45.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizione_from' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizione_from','convalidato','4',null,null,'Iscrizione del sostenimento','S',{ts '2020-04-14 16:17:45.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizionebmi' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione al bando di mobilità internazionale',kind = 'S',lt = {ts '2020-04-14 16:17:45.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizionebmi' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizionebmi','convalidato','4',null,null,'Iscrizione al bando di mobilità internazionale','S',{ts '2020-04-14 16:17:45.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanza' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istanza',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanza' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanza','convalidato','4',null,null,'Istanza','S',{ts '2019-11-18 16:38:31.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrstud' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Learning agreements for studies',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrstud' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrstud','convalidato','4',null,null,'Learning agreements for studies','S',{ts '2019-11-18 16:38:31.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrtrainer' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Learning agreements for traineersheep',kind = 'S',lt = {ts '2020-04-14 16:17:45.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrtrainer' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrtrainer','convalidato','4',null,null,'Learning agreements for traineersheep','S',{ts '2020-04-14 16:17:45.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpratica' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Pratica',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpratica' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpratica','convalidato','4',null,null,'Pratica','S',{ts '2019-11-18 16:38:31.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-18 16:38:31.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','convalidato','4',null,null,'Studente','S',{ts '2019-11-18 16:38:31.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:13:37.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','convalidato','8',null,null,null,'S',{ts '2018-07-20 16:13:37.493'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'convalidato')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 16:13:37.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'convalidato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','convalidato','64',null,null,null,'S',{ts '2018-07-20 16:13:37.493'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3349')
UPDATE [relation] SET childtable = 'convalidato',description = 'convalida chesancisce come svolto l''insegnamento indicato',lt = {ts '2018-07-20 16:14:18.707'},lu = 'assistenza',parenttable = 'convalida',title = null WHERE idrelation = '3349'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3349','convalidato','convalida chesancisce come svolto l''insegnamento indicato',{ts '2018-07-20 16:14:18.707'},'assistenza','convalida',null)
GO

-- FINE GENERAZIONE SCRIPT --

