
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogettoitineration')
UPDATE [tabledescr] SET description = 'Missioni dell''attività',idapplication = '3',isdbo = 'N',lt = {ts '2021-03-11 15:47:37.687'},lu = 'assistenza',title = 'Missioni dell''attività' WHERE tablename = 'rendicontattivitaprogettoitineration'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogettoitineration','Missioni dell''attività','3','N',{ts '2021-03-11 15:47:37.687'},'assistenza','Missioni dell''attività')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogettoitineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Missione',kind = 'S',lt = {ts '2021-03-11 15:49:33.073'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogettoitineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditineration','rendicontattivitaprogettoitineration','4',null,null,'Missione','S',{ts '2021-03-11 15:49:33.073'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogettoitineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-11 15:49:08.703'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogettoitineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','rendicontattivitaprogettoitineration','4',null,null,null,'S',{ts '2021-03-11 15:49:08.703'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoitineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-11 15:49:08.703'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoitineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogettoitineration','4',null,null,null,'S',{ts '2021-03-11 15:49:08.703'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogettoitineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-11 16:11:40.493'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogettoitineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','rendicontattivitaprogettoitineration','4',null,null,null,'S',{ts '2021-03-11 16:11:40.493'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

