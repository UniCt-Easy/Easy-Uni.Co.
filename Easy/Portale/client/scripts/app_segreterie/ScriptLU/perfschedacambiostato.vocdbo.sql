
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfschedacambiostato')
UPDATE [tabledescr] SET description = 'Cambi di stato delle schede',idapplication = null,isdbo = 'N',lt = {ts '2021-05-24 14:43:07.117'},lu = 'assistenza',title = 'Cambi di stato' WHERE tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfschedacambiostato','Cambi di stato delle schede',null,'N',{ts '2021-05-24 14:43:07.117'},'assistenza','Cambi di stato')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Chi lo può cambiare',kind = 'S',lt = {ts '2021-06-07 13:01:42.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo','perfschedacambiostato','50',null,null,'Chi lo può cambiare','S',{ts '2021-06-07 13:01:42.357'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo_mail' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Chi viene avvisato via e-mail',kind = 'S',lt = {ts '2021-06-07 13:01:42.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo_mail' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo_mail','perfschedacambiostato','50',null,null,'Chi viene avvisato via e-mail','S',{ts '2021-06-07 13:01:42.357'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedacambiostato' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:43:09.787'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedacambiostato' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedacambiostato','perfschedacambiostato','4',null,null,null,'S',{ts '2021-05-24 14:43:09.787'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedastatus' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Da',kind = 'S',lt = {ts '2021-05-24 14:44:28.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedastatus' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedastatus','perfschedacambiostato','4',null,null,'Da','S',{ts '2021-05-24 14:44:28.830'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedastatus_to' AND tablename = 'perfschedacambiostato')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'A',kind = 'S',lt = {ts '2021-05-24 14:44:28.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedastatus_to' AND tablename = 'perfschedacambiostato'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedastatus_to','perfschedacambiostato','4',null,null,'A','S',{ts '2021-05-24 14:44:28.830'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

