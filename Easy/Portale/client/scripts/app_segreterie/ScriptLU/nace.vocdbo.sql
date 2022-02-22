
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'nace')
UPDATE [tabledescr] SET description = 'VOCABOLARIO della classificazione NACE',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-17 10:46:20.177'},lu = 'assistenza',title = 'Classificazione NACE delle attività' WHERE tablename = 'nace'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('nace','VOCABOLARIO della classificazione NACE','2','S',{ts '2018-07-17 10:46:20.177'},'assistenza','Classificazione NACE delle attività')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'activity' AND tablename = 'nace')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:45:43.710'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'activity' AND tablename = 'nace'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('activity','nace','0',null,null,null,'S',{ts '2018-07-17 10:45:43.710'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnace' AND tablename = 'nace')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:45:43.713'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idnace' AND tablename = 'nace'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnace','nace','50',null,null,null,'S',{ts '2018-07-17 10:45:43.713'},'assistenza','S','nvarchar(50)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

