
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfschedacambiostatoperfruolo')
UPDATE [tabledescr] SET description = 'Chi viene avvisato via mail',idapplication = '2',isdbo = 'S',lt = {ts '2021-09-30 11:12:32.007'},lu = 'Generator',title = 'Chi viene avvisato via mail' WHERE tablename = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfschedacambiostatoperfruolo','Chi viene avvisato via mail','2','S',{ts '2021-09-30 11:12:32.007'},'Generator','Chi viene avvisato via mail')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfschedacambiostatoperfruolo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-30 11:12:32.010'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfschedacambiostatoperfruolo','8',null,null,'','S',{ts '2021-09-30 11:12:32.010'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfschedacambiostatoperfruolo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-30 11:12:32.010'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfschedacambiostatoperfruolo','64',null,null,'','S',{ts '2021-09-30 11:12:32.010'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfruolo' AND tablename = 'perfschedacambiostatoperfruolo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Ruolo',kind = 'S',lt = {ts '2021-09-30 11:12:32.010'},lu = 'Generator',primarykey = 'S',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfruolo' AND tablename = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfruolo','perfschedacambiostatoperfruolo','50',null,null,'Ruolo','S',{ts '2021-09-30 11:12:32.010'},'Generator','S','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedacambiostato' AND tablename = 'perfschedacambiostatoperfruolo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-30 11:12:32.010'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedacambiostato' AND tablename = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedacambiostato','perfschedacambiostatoperfruolo','4',null,null,'','S',{ts '2021-09-30 11:12:32.010'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfschedacambiostatoperfruolo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-30 11:12:32.010'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfschedacambiostatoperfruolo','8',null,null,'','S',{ts '2021-09-30 11:12:32.010'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfschedacambiostatoperfruolo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-30 11:12:32.010'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfschedacambiostatoperfruolo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfschedacambiostatoperfruolo','64',null,null,'','S',{ts '2021-09-30 11:12:32.010'},'Generator','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --
