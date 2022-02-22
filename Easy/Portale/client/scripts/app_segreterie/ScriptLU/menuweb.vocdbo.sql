
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'menuweb')
UPDATE [tabledescr] SET description = null,idapplication = '2',isdbo = 'S',lt = {ts '2018-11-29 10:09:04.080'},lu = 'assistenza',title = 'menuweb' WHERE tablename = 'menuweb'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('menuweb',null,'2','S',{ts '2018-11-29 10:09:04.080'},'assistenza','menuweb')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'editType' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(60)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'editType' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('editType','menuweb','60',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','N','nvarchar(60)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmenuweb' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmenuweb' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmenuweb','menuweb','4',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmenuwebparent' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmenuwebparent' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmenuwebparent','menuweb','4',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'label' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '250',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-28 14:21:42.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(250)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'label' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('label','menuweb','250',null,null,null,'S',{ts '2018-12-28 14:21:42.053'},'assistenza','N','nvarchar(250)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'link' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '250',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-28 14:21:42.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(250)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'link' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('link','menuweb','250',null,null,null,'S',{ts '2018-12-28 14:21:42.053'},'assistenza','N','nvarchar(250)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sort' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-28 14:21:42.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sort' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sort','menuweb','4',null,null,null,'S',{ts '2018-12-28 14:21:42.053'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tableName' AND tablename = 'menuweb')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-29 10:09:09.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(60)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'tableName' AND tablename = 'menuweb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tableName','menuweb','60',null,null,null,'S',{ts '2018-11-29 10:09:09.357'},'assistenza','N','nvarchar(60)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

