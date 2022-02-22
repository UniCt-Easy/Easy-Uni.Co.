
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'istitutokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR delle tipologie degli istituti di istruzione',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-17 10:42:28.297'},lu = 'assistenza',title = 'Tipologie degli istituti di istruzione' WHERE tablename = 'istitutokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('istitutokind','VOCABOLARIO MIUR delle tipologie degli istituti di istruzione','2','S',{ts '2018-07-17 10:42:28.297'},'assistenza','Tipologie degli istituti di istruzione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistitutokind' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 18:07:11.547'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistitutokind' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistitutokind','istitutokind','4',null,null,null,'S',{ts '2018-12-05 18:07:11.547'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 18:07:11.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','istitutokind','8',null,null,null,'S',{ts '2018-12-05 18:07:11.547'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 18:07:11.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','istitutokind','64',null,null,null,'S',{ts '2018-12-05 18:07:11.547'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tipoistituto' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-02-28 19:12:43.990'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tipoistituto' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tipoistituto','istitutokind','256',null,null,'Tipologia','S',{ts '2019-02-28 19:12:43.990'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tipoistitutoen' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Tipologia (EN)',kind = 'S',lt = {ts '2019-02-28 19:12:43.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tipoistitutoen' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tipoistitutoen','istitutokind','256',null,null,'Tipologia (EN)','S',{ts '2019-02-28 19:12:43.993'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tipoistitutosigla' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Sigla',kind = 'S',lt = {ts '2019-02-28 19:12:43.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tipoistitutosigla' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tipoistitutosigla','istitutokind','50',null,null,'Sigla','S',{ts '2019-02-28 19:12:43.993'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

