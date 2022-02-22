
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfpositionattach')
UPDATE [tabledescr] SET description = 'Moduli di rendicontazione',idapplication = '2',isdbo = 'S',lt = {ts '2021-10-04 10:56:57.033'},lu = 'Generator',title = 'Moduli di rendicontazione' WHERE tablename = 'perfpositionattach'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfpositionattach','Moduli di rendicontazione','2','S',{ts '2021-10-04 10:56:57.033'},'Generator','Moduli di rendicontazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 10:45:08.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfpositionattach','8',null,null,null,'S',{ts '2021-05-21 10:45:08.687'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 10:45:08.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfpositionattach','64',null,null,null,'S',{ts '2021-05-21 10:45:08.687'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattach' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Modulo',kind = 'S',lt = {ts '2021-05-21 10:45:56.530'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattach' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattach','perfpositionattach','4',null,null,'Modulo','S',{ts '2021-05-21 10:45:56.530'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmansionekind' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-04 10:56:57.040'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmansionekind' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmansionekind','perfpositionattach','4',null,null,'','S',{ts '2021-10-04 10:56:57.040'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfpositionattach' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 10:45:08.687'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfpositionattach' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfpositionattach','perfpositionattach','4',null,null,null,'S',{ts '2021-05-21 10:45:08.687'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 10:45:08.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfpositionattach','8',null,null,null,'S',{ts '2021-05-21 10:45:08.687'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 10:45:08.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfpositionattach','64',null,null,null,'S',{ts '2021-05-21 10:45:08.687'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'perfpositionattach')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno solare',kind = 'S',lt = {ts '2021-05-21 10:45:56.530'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'perfpositionattach'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','perfpositionattach','4',null,null,'Anno solare','S',{ts '2021-05-21 10:45:56.530'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

