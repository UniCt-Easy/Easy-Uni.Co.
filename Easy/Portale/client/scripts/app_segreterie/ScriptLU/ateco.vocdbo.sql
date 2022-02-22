
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'ateco')
UPDATE [tabledescr] SET description = 'VOCABOLARIO classificazione ATECO delle attività delle aziende',idapplication = '2',isdbo = 'S',lt = {ts '2021-02-26 11:40:42.193'},lu = 'assistenza',title = 'Classificazione ATECO delle attività delle aziende' WHERE tablename = 'ateco'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('ateco','VOCABOLARIO classificazione ATECO delle attività delle aziende','2','S',{ts '2021-02-26 11:40:42.193'},'assistenza','Classificazione ATECO delle attività delle aziende')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'ateco')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:43:31.070'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'ateco'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','ateco','50',null,null,null,'S',{ts '2018-07-17 17:43:31.070'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idateco' AND tablename = 'ateco')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:43:31.070'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idateco' AND tablename = 'ateco'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idateco','ateco','4',null,null,null,'S',{ts '2018-07-17 17:43:31.070'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'ateco')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:43:31.070'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'ateco'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','ateco','255',null,null,null,'S',{ts '2018-07-17 17:43:31.070'},'assistenza','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

