
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfobiettivokind')
UPDATE [tabledescr] SET description = 'Tipologia obiettivo',idapplication = '2',isdbo = 'S',lt = {ts '2022-02-16 10:44:52.730'},lu = 'Generator',title = 'Tipologia obiettivo' WHERE tablename = 'perfobiettivokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfobiettivokind','Tipologia obiettivo','2','S',{ts '2022-02-16 10:44:52.730'},'Generator','Tipologia obiettivo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:11:19.240'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','perfobiettivokind','1',null,null,'','S',{ts '2022-02-16 09:11:19.240'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:07:07.067'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfobiettivokind','8',null,null,'','S',{ts '2022-02-16 09:07:07.067'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:07:07.067'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfobiettivokind','64',null,null,'','S',{ts '2022-02-16 09:07:07.067'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:11:19.240'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(MAX)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfobiettivokind','-1',null,null,'','S',{ts '2022-02-16 09:11:19.240'},'Generator','N','varchar(MAX)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfobiettivokind' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:07:07.067'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfobiettivokind' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfobiettivokind','perfobiettivokind','4',null,null,'','S',{ts '2022-02-16 09:07:07.067'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:07:07.067'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfobiettivokind','8',null,null,'','S',{ts '2022-02-16 09:07:07.067'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:07:07.067'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfobiettivokind','64',null,null,'','S',{ts '2022-02-16 09:07:07.067'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfobiettivokind')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-02-16 09:07:07.067'},lu = 'Generator',primarykey = 'N',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfobiettivokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfobiettivokind','20',null,null,'','S',{ts '2022-02-16 09:07:07.067'},'Generator','N','nchar(10)','nchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

