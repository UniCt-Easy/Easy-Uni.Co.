
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'istanza_tru')
UPDATE [tabledescr] SET description = '2.5.7 Istanza di Trasferimento in Uscita, estende istanza',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 13:14:12.647'},lu = 'assistenza',title = 'Istanza di Trasferimento in Uscita' WHERE tablename = 'istanza_tru'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('istanza_tru','2.5.7 Istanza di Trasferimento in Uscita, estende istanza',null,'N',{ts '2018-07-20 13:14:12.647'},'assistenza','Istanza di Trasferimento in Uscita')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:04:12.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','istanza_tru','8',null,null,null,'S',{ts '2019-02-25 10:04:12.057'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:04:12.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','istanza_tru','64',null,null,null,'S',{ts '2019-02-25 10:04:12.060'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanza' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:04:12.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanza' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanza','istanza_tru','4',null,null,null,'S',{ts '2019-02-25 10:04:12.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanzakind' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-04 12:55:18.757'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanzakind' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanzakind','istanza_tru','4',null,null,null,'S',{ts '2020-05-04 12:55:18.757'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-14 13:15:48.173'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','istanza_tru','4',null,null,'Studente','S',{ts '2019-11-14 13:15:48.173'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istituti' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto di destinazione',kind = 'S',lt = {ts '2019-02-25 10:04:32.760'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istituti' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istituti','istanza_tru','4',null,null,'Istituto di destinazione','S',{ts '2019-02-25 10:04:32.760'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:04:12.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','istanza_tru','8',null,null,null,'S',{ts '2019-02-25 10:04:12.060'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'istanza_tru')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:04:12.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'istanza_tru'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','istanza_tru','64',null,null,null,'S',{ts '2019-02-25 10:04:12.060'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3323')
UPDATE [relation] SET childtable = 'istanza_tru',description = 'dati di base della istanza',lt = {ts '2018-07-20 13:18:15.383'},lu = 'assistenza',parenttable = 'istanza',title = null WHERE idrelation = '3323'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3323','istanza_tru','dati di base della istanza',{ts '2018-07-20 13:18:15.383'},'assistenza','istanza',null)
GO

-- FINE GENERAZIONE SCRIPT --
