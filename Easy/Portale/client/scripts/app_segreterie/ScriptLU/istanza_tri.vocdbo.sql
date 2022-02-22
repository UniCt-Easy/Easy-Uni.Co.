
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'istanza_tri')
UPDATE [tabledescr] SET description = '2.5.4 Istanza di Trasferimento in Ingresso, estende istanza',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 13:13:01.787'},lu = 'assistenza',title = 'Istanza di Trasferimento in Ingresso' WHERE tablename = 'istanza_tri'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('istanza_tri','2.5.4 Istanza di Trasferimento in Ingresso, estende istanza',null,'N',{ts '2018-07-20 13:13:01.787'},'assistenza','Istanza di Trasferimento in Ingresso')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aaprimaiscr' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico di prima iscrizione',kind = 'S',lt = {ts '2019-02-25 10:03:26.227'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aaprimaiscr' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aaprimaiscr','istanza_tri','9',null,null,'Anno accademico di prima iscrizione','S',{ts '2019-02-25 10:03:26.227'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 13:13:04.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','istanza_tri','8',null,null,null,'S',{ts '2018-07-20 13:13:04.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 13:13:04.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','istanza_tri','64',null,null,null,'S',{ts '2018-07-20 13:13:04.677'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddichiar_titolo' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dichiarazione di titolo di studio in corso',kind = 'S',lt = {ts '2019-02-27 15:44:22.730'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddichiar_titolo' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddichiar_titolo','istanza_tri','4',null,null,'Dichiarazione di titolo di studio in corso','S',{ts '2019-02-27 15:44:22.730'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica programmata',kind = 'S',lt = {ts '2020-04-14 15:55:27.530'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','istanza_tri','4',null,null,'Didattica programmata','S',{ts '2020-04-14 15:55:27.530'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizione' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione',kind = 'S',lt = {ts '2020-04-14 15:55:27.530'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizione' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizione','istanza_tri','4',null,null,'Iscrizione','S',{ts '2020-04-14 15:55:27.530'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanza' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 13:13:04.677'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanza' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanza','istanza_tri','4',null,null,null,'S',{ts '2018-07-20 13:13:04.677'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanzakind' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-04 12:54:54.780'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanzakind' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanzakind','istanza_tri','4',null,null,null,'S',{ts '2020-05-04 12:54:54.780'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-14 13:10:44.700'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','istanza_tri','4',null,null,'Studente','S',{ts '2019-11-14 13:10:44.700'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istituti' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto di provenienza',kind = 'S',lt = {ts '2019-02-25 10:03:26.230'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istituti' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istituti','istanza_tri','4',null,null,'Istituto di provenienza','S',{ts '2019-02-25 10:03:26.230'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 13:13:04.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','istanza_tri','8',null,null,null,'S',{ts '2018-07-20 13:13:04.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'istanza_tri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 13:13:04.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'istanza_tri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','istanza_tri','64',null,null,null,'S',{ts '2018-07-20 13:13:04.677'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3322')
UPDATE [relation] SET childtable = 'istanza_tri',description = 'dati di base della istanza',lt = {ts '2018-07-20 13:13:19.457'},lu = 'assistenza',parenttable = 'istanza',title = null WHERE idrelation = '3322'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3322','istanza_tri','dati di base della istanza',{ts '2018-07-20 13:13:19.457'},'assistenza','istanza',null)
GO

-- FINE GENERAZIONE SCRIPT --

