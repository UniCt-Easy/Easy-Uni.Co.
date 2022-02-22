
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'numerodip')
UPDATE [tabledescr] SET description = 'VOCABOLARIO dei range di numero di dipendenti di 2.4.34 2.5.19  Enti e Aziende',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-20 16:26:38.583'},lu = 'assistenza',title = 'Range di numero di dipendenti di Enti e Aziende' WHERE tablename = 'numerodip'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('numerodip','VOCABOLARIO dei range di numero di dipendenti di 2.4.34 2.5.19  Enti e Aziende','2','S',{ts '2018-07-20 16:26:38.583'},'assistenza','Range di numero di dipendenti di Enti e Aziende')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','numerodip','1',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','N','varchar(1)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnumerodip' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnumerodip' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnumerodip','numerodip','4',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','numerodip','4',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'numerodip')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:47:11.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'numerodip'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','numerodip','50',null,null,null,'S',{ts '2018-07-17 17:47:11.083'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

