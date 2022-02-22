
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sasd')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR dei settori artistico-scientifico disciplinari',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 13:33:53.620'},lu = 'assistenza',title = 'Settori artistico-scientifico disciplinari' WHERE tablename = 'sasd'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sasd','VOCABOLARIO MIUR dei settori artistico-scientifico disciplinari','3','S',{ts '2021-02-19 13:33:53.620'},'assistenza','Settori artistico-scientifico disciplinari')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:32:31.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','sasd','50',null,null,null,'S',{ts '2018-07-17 17:32:31.480'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice_old' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice legge precedente',kind = 'S',lt = {ts '2019-01-25 17:43:28.590'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(4)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice_old' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice_old','sasd','4',null,null,'Codice legge precedente','S',{ts '2019-01-25 17:43:28.590'},'assistenza','N','varchar(4)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idareadidattica' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area o ambito disciplinare',kind = 'S',lt = {ts '2018-12-10 16:56:54.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idareadidattica' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idareadidattica','sasd','4',null,null,'Area o ambito disciplinare','S',{ts '2018-12-10 16:56:54.257'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-21 18:44:47.123'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','sasd','4',null,null,'Codice Istituto','S',{ts '2018-11-21 18:44:47.123'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-10 16:38:35.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','sasd','8',null,null,null,'S',{ts '2018-12-10 16:38:35.547'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-10 16:38:35.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','sasd','64',null,null,null,'S',{ts '2018-12-10 16:38:35.547'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'sasd')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = 'Settore Artistico Scientifico Disciplinare',kind = 'S',lt = {ts '2018-12-10 16:56:54.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'sasd'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','sasd','255',null,null,'Settore Artistico Scientifico Disciplinare','S',{ts '2018-12-10 16:56:54.257'},'assistenza','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

