
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [tabledescr] SET description = 'Validatore ',idapplication = '2',isdbo = 'S',lt = {ts '2022-01-05 13:19:22.323'},lu = 'Generator',title = 'Validatore ' WHERE tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazioneateneoresvalidatori','Validatore ','2','S',{ts '2022-01-05 13:19:22.323'},'Generator','Validatore ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazioneateneoresvalidatori','8',null,null,null,'S',{ts '2021-09-17 16:45:24.760'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazioneateneoresvalidatori','64',null,null,null,'S',{ts '2021-09-17 16:45:24.760'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfmission' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfmission' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfmission','perfvalutazioneateneoresvalidatori','4',null,null,'','S',{ts '2021-09-17 16:45:24.760'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneateneo' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneateneo' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneateneo','perfvalutazioneateneoresvalidatori','4',null,null,null,'S',{ts '2021-09-17 16:45:24.760'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneateneores' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneateneores' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneateneores','perfvalutazioneateneoresvalidatori','4',null,null,null,'S',{ts '2021-09-17 16:45:24.760'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idvalidatori' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idvalidatori' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idvalidatori','perfvalutazioneateneoresvalidatori','4',null,null,null,'S',{ts '2021-09-17 16:45:24.760'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazioneateneoresvalidatori','8',null,null,null,'S',{ts '2021-09-17 16:45:24.760'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazioneateneoresvalidatori')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-09-17 16:45:24.760'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazioneateneoresvalidatori'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazioneateneoresvalidatori','64',null,null,null,'S',{ts '2021-09-17 16:45:24.760'},'Generator','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

