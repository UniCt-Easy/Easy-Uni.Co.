
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'ambitoareadisc')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR 2.4.5 Area o ambito Disciplinare',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 15:40:08.027'},lu = 'assistenza',title = 'Area o ambito Disciplinare' WHERE tablename = 'ambitoareadisc'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('ambitoareadisc','VOCABOLARIO MIUR 2.4.5 Area o ambito Disciplinare','3','S',{ts '2021-02-19 15:40:08.027'},'assistenza','Area o ambito Disciplinare')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idambitoareadisc' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:28:01.377'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idambitoareadisc' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idambitoareadisc','ambitoareadisc','4',null,null,null,'S',{ts '2018-07-19 17:28:01.377'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuola' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Scuola / Classe di laurea',kind = 'S',lt = {ts '2020-05-18 21:44:24.070'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassescuola' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuola','ambitoareadisc','4',null,null,'Scuola / Classe di laurea','S',{ts '2020-05-18 21:44:24.070'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipoattform' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo attività formativa',kind = 'S',lt = {ts '2020-05-18 21:44:24.070'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipoattform' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipoattform','ambitoareadisc','4',null,null,'Tipo attività formativa','S',{ts '2020-05-18 21:44:24.070'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicecineca' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id cineca',kind = 'S',lt = {ts '2020-05-18 21:44:24.070'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicecineca' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicecineca','ambitoareadisc','4',null,null,'Id cineca','S',{ts '2020-05-18 21:44:24.070'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:28:01.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','ambitoareadisc','8',null,null,null,'S',{ts '2018-07-19 17:28:01.377'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:28:01.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','ambitoareadisc','64',null,null,null,'S',{ts '2018-07-19 17:28:01.377'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine nel tipo di attività formativa',kind = 'S',lt = {ts '2020-05-18 21:44:24.070'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','ambitoareadisc','4',null,null,'Ordine nel tipo di attività formativa','S',{ts '2020-05-18 21:44:24.070'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'ambitoareadisc')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Ambito',kind = 'S',lt = {ts '2020-05-18 21:44:24.070'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','ambitoareadisc','256',null,null,'Ambito','S',{ts '2020-05-18 21:44:24.070'},'assistenza','N','varchar(256)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

