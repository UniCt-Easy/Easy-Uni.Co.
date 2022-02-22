
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'attach')
UPDATE [tabledescr] SET description = null,idapplication = '2',isdbo = 'S',lt = {ts '2019-02-26 13:02:55.900'},lu = 'assistenza',title = 'Allegati' WHERE tablename = 'attach'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('attach',null,'2','S',{ts '2019-02-26 13:02:55.900'},'assistenza','Allegati')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'attachment' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Allegato su SQL',kind = 'S',lt = {ts '2019-02-26 13:03:43.403'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varbinary(max)',sql_type = 'varbinary',system_type = 'System.Byte[]' WHERE colname = 'attachment' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('attachment','attach','-1',null,null,'Allegato su SQL','S',{ts '2019-02-26 13:03:43.403'},'assistenza','N','varbinary(max)','varbinary','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 13:02:59.780'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','attach','8',null,null,null,'S',{ts '2019-02-26 13:02:59.780'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 13:02:59.780'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','attach','64',null,null,null,'S',{ts '2019-02-26 13:02:59.780'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'filename' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Nome del file',kind = 'S',lt = {ts '2019-02-26 13:03:43.403'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'filename' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('filename','attach','512',null,null,'Nome del file','S',{ts '2019-02-26 13:03:43.403'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'Hash' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '160',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 13:02:59.783'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varbinary(160)',sql_type = 'varbinary',system_type = 'System.Byte[]' WHERE colname = 'Hash' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('Hash','attach','160',null,null,null,'S',{ts '2019-02-26 13:02:59.783'},'assistenza','N','varbinary(160)','varbinary','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattach' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 13:02:59.783'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattach' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattach','attach','4',null,null,null,'S',{ts '2019-02-26 13:02:59.783'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 13:02:59.783'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','attach','8',null,null,null,'S',{ts '2019-02-26 13:02:59.783'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 13:02:59.783'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','attach','64',null,null,null,'S',{ts '2019-02-26 13:02:59.783'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'Size' AND tablename = 'attach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Dimensione',kind = 'S',lt = {ts '2019-02-26 13:03:43.403'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'bigint',sql_type = 'bigint',system_type = 'System.Int64' WHERE colname = 'Size' AND tablename = 'attach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('Size','attach','8',null,null,'Dimensione','S',{ts '2019-02-26 13:03:43.403'},'assistenza','N','bigint','bigint','System.Int64')
GO

-- FINE GENERAZIONE SCRIPT --

