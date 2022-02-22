
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tirociniocandidatura')
UPDATE [tabledescr] SET description = '2.5.21 Candidatura al tirocinio 
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:31:10.233'},lu = 'assistenza',title = 'Candidatura al tirocinio ' WHERE tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tirociniocandidatura','2.5.21 Candidatura al tirocinio 
',null,'N',{ts '2018-07-27 13:31:10.233'},'assistenza','Candidatura al tirocinio ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tirociniocandidatura','8',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tirociniocandidatura','64',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','tirociniocandidatura','8',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tutor',kind = 'S',lt = {ts '2019-11-28 18:04:20.023'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','tirociniocandidatura','4',null,null,'Tutor','S',{ts '2019-11-28 18:04:20.023'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_referente' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Referente dell''azienda',kind = 'S',lt = {ts '2019-11-28 18:04:05.853'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_referente' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_referente','tirociniocandidatura','4',null,null,'Referente dell''azienda','S',{ts '2019-11-28 18:04:05.853'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_studenti' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-28 18:04:05.853'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_studenti' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_studenti','tirociniocandidatura','4',null,null,'Studente','S',{ts '2019-11-28 18:04:05.853'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniocandidatura','tirociniocandidatura','4',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniocandidaturakind' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2021-06-22 10:57:38.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniocandidaturakind' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniocandidaturakind','tirociniocandidatura','4',null,null,'Tipologia','S',{ts '2021-06-22 10:57:38.687'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniopoposto' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Proposta di tirocinio',kind = 'S',lt = {ts '2019-11-28 18:04:40.503'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniopoposto' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniopoposto','tirociniocandidatura','4',null,null,'Proposta di tirocinio','S',{ts '2019-11-28 18:04:40.503'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirocinioproposto' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Proposta di tirocinio',kind = 'S',lt = {ts '2020-09-03 17:27:42.770'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirocinioproposto' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirocinioproposto','tirociniocandidatura','4',null,null,'Proposta di tirocinio','S',{ts '2020-09-03 17:27:42.770'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tirociniocandidatura','8',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tirociniocandidatura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:31:12.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tirociniocandidatura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tirociniocandidatura','64',null,null,null,'S',{ts '2018-07-27 13:31:12.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3381')
UPDATE [relation] SET childtable = 'tirociniocandidatura',description = 'torocinio a cui ci si candida',lt = {ts '2018-07-27 13:31:47.967'},lu = 'assistenza',parenttable = 'tirocinioproposto',title = null WHERE idrelation = '3381'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3381','tirociniocandidatura','torocinio a cui ci si candida',{ts '2018-07-27 13:31:47.967'},'assistenza','tirocinioproposto',null)
GO

-- FINE GENERAZIONE SCRIPT --

