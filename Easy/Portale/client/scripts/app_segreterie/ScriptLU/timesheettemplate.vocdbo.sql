
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'timesheettemplate')
UPDATE [tabledescr] SET description = 'Template intestazione timesheet',idapplication = '3',isdbo = 'N',lt = {ts '2021-07-20 16:34:56.097'},lu = 'assistenza',title = 'Template intestazione timesheet' WHERE tablename = 'timesheettemplate'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('timesheettemplate','Template intestazione timesheet','3','N',{ts '2021-07-20 16:34:56.097'},'assistenza','Template intestazione timesheet')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtimesheettemplate' AND tablename = 'timesheettemplate')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = 'Template',kind = 'S',lt = {ts '2021-07-20 16:35:16.807'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idtimesheettemplate' AND tablename = 'timesheettemplate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtimesheettemplate','timesheettemplate','60',null,null,'Template','S',{ts '2021-07-20 16:35:16.807'},'assistenza','S','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

