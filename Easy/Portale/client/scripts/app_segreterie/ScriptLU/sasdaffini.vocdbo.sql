
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sasdaffini')
UPDATE [tabledescr] SET description = 'SASD affini',idapplication = '2',isdbo = 'N',lt = {ts '2021-05-21 10:22:39.843'},lu = 'assistenza',title = 'SASD affini' WHERE tablename = 'sasdaffini'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sasdaffini','SASD affini','2','N',{ts '2021-05-21 10:22:39.843'},'assistenza','SASD affini')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'affinita' AND tablename = 'sasdaffini')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Affinità',kind = 'S',lt = {ts '2021-05-21 10:24:23.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'affinita' AND tablename = 'sasdaffini'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('affinita','sasdaffini','4',null,null,'Affinità','S',{ts '2021-05-21 10:24:23.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'sasdaffini')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2021-05-21 10:24:23.043'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'sasdaffini'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','sasdaffini','4',null,null,'SASD','S',{ts '2021-05-21 10:24:23.043'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd_affine' AND tablename = 'sasdaffini')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD affine',kind = 'S',lt = {ts '2021-05-21 10:24:23.043'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd_affine' AND tablename = 'sasdaffini'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd_affine','sasdaffini','4',null,null,'SASD affine','S',{ts '2021-05-21 10:24:23.043'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

