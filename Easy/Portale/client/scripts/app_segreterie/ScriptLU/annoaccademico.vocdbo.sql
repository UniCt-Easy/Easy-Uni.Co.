
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'annoaccademico')
UPDATE [tabledescr] SET description = 'Anno accademico',idapplication = '2',isdbo = 'S',lt = {ts '2021-02-25 15:37:02.127'},lu = 'assistenza',title = 'Anno accademico' WHERE tablename = 'annoaccademico'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('annoaccademico','Anno accademico','2','S',{ts '2021-02-25 15:37:02.127'},'assistenza','Anno accademico')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'annoaccademico')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2020-02-03 19:57:59.590'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nvarchar(9)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'annoaccademico'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','annoaccademico','9',null,null,'Anno accademico','S',{ts '2020-02-03 19:57:59.590'},'assistenza','S','nvarchar(9)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

