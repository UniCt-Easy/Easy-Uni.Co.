
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotipocostokindinventorytree')
UPDATE [tabledescr] SET description = 'Classificazione inventariale associata alla voce di costo del progetto o attivit� (modello)',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-26 11:57:03.047'},lu = 'assistenza',title = 'Classificazione inventariale associata' WHERE tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotipocostokindinventorytree','Classificazione inventariale associata alla voce di costo del progetto o attivit� (modello)','3','S',{ts '2021-02-26 11:57:03.047'},'assistenza','Classificazione inventariale associata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotipocostokindinventorytree')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:26:26.037'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotipocostokindinventorytree','8',null,null,null,'S',{ts '2020-06-18 18:26:26.037'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotipocostokindinventorytree')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:26:26.037'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotipocostokindinventorytree','64',null,null,null,'S',{ts '2020-06-18 18:26:26.037'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinv' AND tablename = 'progettotipocostokindinventorytree')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classificazione inventariale',kind = 'S',lt = {ts '2020-06-18 18:28:23.393'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinv' AND tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinv','progettotipocostokindinventorytree','4',null,null,'Classificazione inventariale','S',{ts '2020-06-18 18:28:23.393'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progettotipocostokindinventorytree')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:26:26.037'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progettotipocostokindinventorytree','4',null,null,null,'S',{ts '2020-06-18 18:26:26.037'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotipocostokindinventorytree')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:26:26.037'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocostokind','progettotipocostokindinventorytree','4',null,null,null,'S',{ts '2020-06-18 18:26:26.037'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotipocostokindinventorytree')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:26:26.040'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotipocostokindinventorytree','8',null,null,null,'S',{ts '2020-06-18 18:26:26.040'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotipocostokindinventorytree')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 18:26:26.040'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotipocostokindinventorytree'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotipocostokindinventorytree','64',null,null,null,'S',{ts '2020-06-18 18:26:26.040'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --
