
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_docenti')
UPDATE [tabledescr] SET description = '2.4.20 docenti',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 10:33:23.860'},lu = 'assistenza',title = 'Docenti' WHERE tablename = 'registry_docenti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_docenti','2.4.20 docenti','3','S',{ts '2021-02-19 10:33:23.860'},'assistenza','Docenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum Vitae',kind = 'S',lt = {ts '2018-11-27 13:37:14.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_docenti','0',null,null,'Curriculum Vitae','S',{ts '2018-11-27 13:37:14.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classe consorsuale',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassconsorsuale','registry_docenti','4',null,null,'Classe consorsuale','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-26 17:44:20.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_docenti','4',null,null,'Tipo','S',{ts '2020-05-26 17:44:20.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fonte',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idfonteindicebibliometrico','registry_docenti','4',null,null,'Fonte','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_docenti','4',null,null,'Codice Istituto','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto, Ente o Azienda',kind = 'S',lt = {ts '2019-02-15 17:21:00.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istituti','registry_docenti','4',null,null,'Istituto, Ente o Azienda','S',{ts '2019-02-15 17:21:00.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','registry_docenti','4',null,null,'SASD','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di afferenza',kind = 'S',lt = {ts '2019-09-09 18:32:55.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','registry_docenti','4',null,null,'Struttura di afferenza','S',{ts '2019-09-09 18:32:55.953'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Indice bibliometrico (H-Index)',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicebibliometrico','registry_docenti','4',null,null,'Indice bibliometrico (H-Index)','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'matricola' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Matricola',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'matricola' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('matricola','registry_docenti','50',null,null,'Matricola','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ricevimento' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Orari di ricevimento',kind = 'S',lt = {ts '2018-11-27 13:28:30.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'ricevimento' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ricevimento','registry_docenti','0',null,null,'Orari di ricevimento','S',{ts '2018-11-27 13:28:30.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'soggiorno' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = 'Permesso di soggiorno',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'soggiorno' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('soggiorno','registry_docenti','255',null,null,'Permesso di soggiorno','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

