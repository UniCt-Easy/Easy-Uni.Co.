
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'partnerkind')
UPDATE [tabledescr] SET description = 'Tipi di partnership',idapplication = '3',isdbo = 'S',lt = {ts '2021-06-18 13:08:50.613'},lu = 'assistenza',title = 'Tipi di partnership' WHERE tablename = 'partnerkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('partnerkind','Tipi di partnership','3','S',{ts '2021-06-18 13:08:50.613'},'assistenza','Tipi di partnership')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.913'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','partnerkind','1',null,null,null,'S',{ts '2021-06-18 13:08:53.913'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','partnerkind','-1',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpartnerkind' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpartnerkind' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpartnerkind','partnerkind','4',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','partnerkind','4',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'partnerkind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-18 13:08:53.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'partnerkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','partnerkind','2048',null,null,null,'S',{ts '2021-06-18 13:08:53.917'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

