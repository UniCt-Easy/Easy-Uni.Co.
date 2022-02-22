
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'appelloazionekind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO dei motivi per aprire un 2.2.5 Appello d''esame',idapplication = '2',isdbo = 'S',lt = {ts '2021-05-27 12:30:56.157'},lu = 'assistenza',title = 'Motivi per aprire un appello d''esame' WHERE tablename = 'appelloazionekind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('appelloazionekind','VOCABOLARIO dei motivi per aprire un 2.2.5 Appello d''esame','2','S',{ts '2021-05-27 12:30:56.157'},'assistenza','Motivi per aprire un appello d''esame')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','appelloazionekind','10',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','nchar(10)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','appelloazionekind','8',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','appelloazionekind','64',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '250',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(250)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','appelloazionekind','250',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','varchar(250)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idappelloazionekind' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idappelloazionekind' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idappelloazionekind','appelloazionekind','4',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','appelloazionekind','8',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','appelloazionekind','64',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','appelloazionekind','4',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'appelloazionekind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 15:51:05.577'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','appelloazionekind','50',null,null,null,'S',{ts '2018-07-20 15:51:05.577'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3341')
UPDATE [relation] SET childtable = 'appelloazionekind',description = 'appelo di cui si descrive il motivo per aprirlo',lt = {ts '2018-07-20 15:51:05.217'},lu = 'assistenza',parenttable = 'appello',title = null WHERE idrelation = '3341'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3341','appelloazionekind','appelo di cui si descrive il motivo per aprirlo',{ts '2018-07-20 15:51:05.217'},'assistenza','appello',null)
GO

-- FINE GENERAZIONE SCRIPT --

