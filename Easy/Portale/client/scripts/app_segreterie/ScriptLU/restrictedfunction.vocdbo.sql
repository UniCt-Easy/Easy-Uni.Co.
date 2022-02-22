
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'restrictedfunction')
UPDATE [tabledescr] SET description = 'Operatività',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:29.880'},lu = 'nino',title = 'Operatività' WHERE tablename = 'restrictedfunction'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('restrictedfunction','Operatività',null,'S',{ts '1900-01-01 03:00:29.880'},'nino','Operatività')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'restrictedfunction')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.240'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','restrictedfunction','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.240'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'restrictedfunction')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.673'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','restrictedfunction','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.673'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'restrictedfunction')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:51.637'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','restrictedfunction','100',null,null,'Descrizione','S',{ts '1900-01-01 02:59:51.637'},'nino','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrestrictedfunction' AND tablename = 'restrictedfunction')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '#',kind = 'S',lt = {ts '1900-01-01 03:00:30.313'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrestrictedfunction' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrestrictedfunction','restrictedfunction','4',null,null,'#','S',{ts '1900-01-01 03:00:30.313'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'restrictedfunction')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:43.007'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','restrictedfunction','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:43.007'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'restrictedfunction')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:40.037'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','restrictedfunction','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:40.037'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'variablename' AND tablename = 'restrictedfunction')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Nome Variabile',kind = 'S',lt = {ts '1900-01-01 03:00:23.120'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'variablename' AND tablename = 'restrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('variablename','restrictedfunction','50',null,null,'Nome Variabile','S',{ts '1900-01-01 03:00:23.120'},'nino','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

