
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfsogliakind')
UPDATE [tabledescr] SET description = 'Tipi di soglia',idapplication = null,isdbo = 'N',lt = {ts '2021-05-20 12:22:19.223'},lu = 'assistenza',title = 'Tipi di soglia' WHERE tablename = 'perfsogliakind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfsogliakind','Tipi di soglia',null,'N',{ts '2021-05-20 12:22:19.223'},'assistenza','Tipi di soglia')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfsogliakind' AND tablename = 'perfsogliakind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Denominazione del tipo di soglia',kind = 'S',lt = {ts '2021-10-28 10:55:09.443'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfsogliakind' AND tablename = 'perfsogliakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfsogliakind','perfsogliakind','50',null,null,'Denominazione del tipo di soglia','S',{ts '2021-10-28 10:55:09.443'},'assistenza','S','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

