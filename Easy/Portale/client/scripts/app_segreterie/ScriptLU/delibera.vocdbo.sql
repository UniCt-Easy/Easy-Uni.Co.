
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'delibera')
UPDATE [tabledescr] SET description = '2.5.29 Delibera, indica che le istanze citate in essa vengono accolte',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 10:38:49.790'},lu = 'assistenza',title = '2.5.29 Delibera, indica che le istanze citate in essa vengono accolte' WHERE tablename = 'delibera'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('delibera','2.5.29 Delibera, indica che le istanze citate in essa vengono accolte',null,'N',{ts '2018-07-20 10:38:49.790'},'assistenza','2.5.29 Delibera, indica che le istanze citate in essa vengono accolte')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:37:48.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','delibera','8',null,null,null,'S',{ts '2018-07-20 10:37:48.150'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:37:48.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','delibera','64',null,null,null,'S',{ts '2018-07-20 10:37:48.150'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:37:48.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','delibera','8',null,null,null,'S',{ts '2018-07-20 10:37:48.150'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddelibera' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-02-25 09:56:07.110'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddelibera' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddelibera','delibera','4',null,null,'Identificativo','S',{ts '2019-02-25 09:56:07.110'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstatuskind' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Status',kind = 'S',lt = {ts '2019-02-25 09:56:07.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstatuskind' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstatuskind','delibera','4',null,null,'Status','S',{ts '2019-02-25 09:56:07.110'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura',kind = 'S',lt = {ts '2021-04-09 09:34:50.233'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','delibera','4',null,null,'Struttura','S',{ts '2021-04-09 09:34:50.233'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:37:48.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','delibera','8',null,null,null,'S',{ts '2018-07-20 10:37:48.150'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:37:48.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','delibera','64',null,null,null,'S',{ts '2018-07-20 10:37:48.150'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oggetto' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:37:48.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'oggetto' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oggetto','delibera','512',null,null,null,'S',{ts '2018-07-20 10:37:48.150'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protanno' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di protocollo',kind = 'S',lt = {ts '2019-02-25 09:56:07.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protanno' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protanno','delibera','4',null,null,'Anno di protocollo','S',{ts '2019-02-25 09:56:07.110'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protnumero' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di protocollo',kind = 'S',lt = {ts '2019-02-25 09:56:07.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protnumero' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protnumero','delibera','4',null,null,'Numero di protocollo','S',{ts '2019-02-25 09:56:07.110'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'testo' AND tablename = 'delibera')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 10:37:48.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'testo' AND tablename = 'delibera'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('testo','delibera','-1',null,null,null,'S',{ts '2018-07-20 10:37:48.150'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

