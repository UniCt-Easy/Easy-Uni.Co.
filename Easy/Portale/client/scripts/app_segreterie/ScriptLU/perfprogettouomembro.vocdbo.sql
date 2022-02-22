
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfprogettouomembro')
UPDATE [tabledescr] SET description = 'Membri',idapplication = null,isdbo = 'N',lt = {ts '2021-05-24 14:48:22.753'},lu = 'assistenza',title = 'Membri' WHERE tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfprogettouomembro','Membri',null,'N',{ts '2021-05-24 14:48:22.753'},'assistenza','Membri')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfprogettouomembro','8',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfprogettouomembro','36',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogetto' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogetto','perfprogettouomembro','4',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettouo' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettouo' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettouo','perfprogettouomembro','4',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Membro',kind = 'S',lt = {ts '2021-06-10 12:30:46.857'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','perfprogettouomembro','4',null,null,'Membro','S',{ts '2021-06-10 12:30:46.857'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfprogettouomembro','8',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfprogettouomembro')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:48:25.697'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfprogettouomembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfprogettouomembro','36',null,null,null,'S',{ts '2021-05-24 14:48:25.697'},'assistenza','N','varchar(36)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

