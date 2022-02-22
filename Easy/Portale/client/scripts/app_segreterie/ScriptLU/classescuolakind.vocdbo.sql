
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'classescuolakind')
UPDATE [tabledescr] SET description = 'Tipologia di scuola / classe di laurea',idapplication = null,isdbo = 'N',lt = {ts '2020-05-18 11:57:53.957'},lu = 'assistenza',title = 'Tipologia di scuola / classe di laurea' WHERE tablename = 'classescuolakind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('classescuolakind','Tipologia di scuola / classe di laurea',null,'N',{ts '2020-05-18 11:57:53.957'},'assistenza','Tipologia di scuola / classe di laurea')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuolakind' AND tablename = 'classescuolakind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-18 11:57:55.890'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idclassescuolakind' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuolakind','classescuolakind','50',null,null,null,'S',{ts '2020-05-18 11:57:55.890'},'assistenza','S','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'classescuolakind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di corso',kind = 'S',lt = {ts '2020-05-18 11:58:53.933'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','classescuolakind','4',null,null,'Tipologia di corso','S',{ts '2020-05-18 11:58:53.933'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiolivello' AND tablename = 'classescuolakind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Livello del corso',kind = 'S',lt = {ts '2020-05-18 11:58:53.933'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiolivello' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiolivello','classescuolakind','4',null,null,'Livello del corso','S',{ts '2020-05-18 11:58:53.933'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'classescuolakind')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2020-05-18 11:58:53.933'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(1024)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','classescuolakind','1024',null,null,'Tipologia','S',{ts '2020-05-18 11:58:53.933'},'assistenza','N','nvarchar(1024)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

