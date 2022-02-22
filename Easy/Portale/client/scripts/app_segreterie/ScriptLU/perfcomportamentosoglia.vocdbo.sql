
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfcomportamentosoglia')
UPDATE [tabledescr] SET description = 'Descrizione delle soglie per anno solare',idapplication = '2',isdbo = 'S',lt = {ts '2021-09-16 16:17:13.267'},lu = 'Generator',title = 'Soglia di comportamento' WHERE tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfcomportamentosoglia','Descrizione delle soglie per anno solare','2','S',{ts '2021-09-16 16:17:13.267'},'Generator','Soglia di comportamento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 08:58:11.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfcomportamentosoglia','8',null,null,null,'S',{ts '2021-05-21 08:58:11.687'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 08:58:11.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfcomportamentosoglia','64',null,null,null,'S',{ts '2021-05-21 08:58:11.687'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-05-21 08:59:02.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfcomportamentosoglia','-1',null,null,'Descrizione','S',{ts '2021-05-21 08:59:02.113'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfcomportamento' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 08:58:11.687'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfcomportamento' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfcomportamento','perfcomportamentosoglia','4',null,null,null,'S',{ts '2021-05-21 08:58:11.687'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfcomportamentosoglia' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 08:58:11.687'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfcomportamentosoglia' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfcomportamentosoglia','perfcomportamentosoglia','4',null,null,null,'S',{ts '2021-05-21 08:58:11.687'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfsogliakind' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2021-05-21 08:59:02.117'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfsogliakind' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfsogliakind','perfcomportamentosoglia','50',null,null,'Tipo','S',{ts '2021-05-21 08:59:02.117'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 08:58:11.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfcomportamentosoglia','8',null,null,null,'S',{ts '2021-05-21 08:58:11.687'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-21 08:58:11.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfcomportamentosoglia','64',null,null,null,'S',{ts '2021-05-21 08:58:11.687'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valore' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore % soglia',kind = 'S',lt = {ts '2021-05-21 08:59:02.117'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valore' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valore','perfcomportamentosoglia','9','19','2','Valore % soglia','S',{ts '2021-05-21 08:59:02.117'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valorenumerico' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore numerico soglia',kind = 'S',lt = {ts '2021-09-16 16:17:50.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valorenumerico' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valorenumerico','perfcomportamentosoglia','9','19','2','Valore numerico soglia','S',{ts '2021-09-16 16:17:50.663'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'perfcomportamentosoglia')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Anno Solare',kind = 'S',lt = {ts '2021-05-21 08:59:02.117'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'year' AND tablename = 'perfcomportamentosoglia'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','perfcomportamentosoglia','10',null,null,'Anno Solare','S',{ts '2021-05-21 08:59:02.117'},'assistenza','N','nchar(10)','nchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

