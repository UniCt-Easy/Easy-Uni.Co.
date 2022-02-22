
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'settoreerc')
UPDATE [tabledescr] SET description = '2.7.6 Settori ERC',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:35:09.647'},lu = 'assistenza',title = 'Settori ERC' WHERE tablename = 'settoreerc'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('settoreerc','2.7.6 Settori ERC','3','S',{ts '2021-02-19 17:35:09.647'},'assistenza','Settori ERC')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','settoreerc','1',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','settoreerc','8',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','settoreerc','64',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','settoreerc','2048',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsettoreerc' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsettoreerc' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsettoreerc','settoreerc','4',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','settoreerc','8',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','settoreerc','64',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','settoreerc','4',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','settoreerc','2048',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

