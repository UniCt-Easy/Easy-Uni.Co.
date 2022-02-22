
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotipocostotax')
UPDATE [tabledescr] SET description = 'Tipi di ritenuta associati alla voce di costo della attivit� o progetto',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 16:54:30.267'},lu = 'assistenza',title = 'Tipi di ritenuta associati' WHERE tablename = 'progettotipocostotax'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotipocostotax','Tipi di ritenuta associati alla voce di costo della attivit� o progetto','3','N',{ts '2021-02-19 16:54:30.267'},'assistenza','Tipi di ritenuta associati')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotipocostotax','8',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotipocostotax','64',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettotipocostotax','4',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettotipocostotax','4',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotipocostotax','8',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:32:11.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotipocostotax','64',null,null,null,'S',{ts '2020-06-18 18:32:11.607'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxcode' AND tablename = 'progettotipocostotax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipi di ritenuta',kind = 'S',lt = {ts '2020-06-18 18:32:23.803'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'taxcode' AND tablename = 'progettotipocostotax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxcode','progettotipocostotax','4',null,null,'Tipi di ritenuta','S',{ts '2020-06-18 18:32:23.803'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

