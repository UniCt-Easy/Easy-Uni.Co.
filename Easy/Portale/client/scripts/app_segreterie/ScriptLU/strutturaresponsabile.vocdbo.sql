
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'strutturaresponsabile')
UPDATE [tabledescr] SET description = 'Responsabili, valutatori e approvatori',idapplication = '2',isdbo = 'S',lt = {ts '2021-12-01 11:32:52.010'},lu = 'Generator',title = 'Responsabili, valutatori e approvatori' WHERE tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('strutturaresponsabile','Responsabili, valutatori e approvatori','2','S',{ts '2021-12-01 11:32:52.010'},'Generator','Responsabili, valutatori e approvatori')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Ruolo ',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo','strutturaresponsabile','50',null,null,'Ruolo ','S',{ts '2021-11-19 10:17:24.327'},'Generator','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Membro del personale',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','strutturaresponsabile','4',null,null,'Membro del personale','S',{ts '2021-11-19 10:17:24.327'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','strutturaresponsabile','4',null,null,'','S',{ts '2021-11-19 10:17:24.327'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstrutturaresponsabile' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-19 10:17:24.327'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstrutturaresponsabile' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstrutturaresponsabile','strutturaresponsabile','4',null,null,'','S',{ts '2021-11-19 10:17:24.327'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio validità',kind = 'S',lt = {ts '2021-11-30 16:15:12.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','strutturaresponsabile','3',null,null,'Data inizio validità','S',{ts '2021-11-30 16:15:12.060'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'strutturaresponsabile')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine validità',kind = 'S',lt = {ts '2021-11-30 16:15:12.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'strutturaresponsabile'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','strutturaresponsabile','3',null,null,'Data fine validità','S',{ts '2021-11-30 16:15:12.060'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --

