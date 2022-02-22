
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'stipendio')
UPDATE [tabledescr] SET description = 'Tabelle stipendiali',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-15 14:13:37.113'},lu = 'Generator',title = 'Tabelle stipendiali' WHERE tablename = 'stipendio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('stipendio','Tabelle stipendiali','2','S',{ts '2021-11-15 14:13:37.113'},'Generator','Tabelle stipendiali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegno' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Assegno aggiuntivo',kind = 'S',lt = {ts '2021-07-01 12:22:08.840'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'assegno' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegno','stipendio','9','18','2','Assegno aggiuntivo','S',{ts '2021-07-01 12:22:08.840'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'classe' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:20:14.673'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'classe' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('classe','stipendio','4',null,null,null,'S',{ts '2021-07-01 12:20:14.673'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-15 14:13:37.120'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','stipendio','8',null,null,'','S',{ts '2021-11-15 14:13:37.120'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-15 14:13:37.120'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','stipendio','64',null,null,'','S',{ts '2021-11-15 14:13:37.120'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:20:14.673'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','stipendio','4',null,null,null,'S',{ts '2021-07-01 12:20:14.673'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinquadramento' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:20:14.673'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinquadramento' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinquadramento','stipendio','4',null,null,null,'S',{ts '2021-07-01 12:20:14.673'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstipendio' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:20:14.673'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstipendio' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstipendio','stipendio','4',null,null,null,'S',{ts '2021-07-01 12:20:14.673'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iis' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Indennità integrativa speciale',kind = 'S',lt = {ts '2021-07-01 12:22:08.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'iis' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iis','stipendio','9','18','2','Indennità integrativa speciale','S',{ts '2021-07-01 12:22:08.847'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'irap' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'IRAP',kind = 'S',lt = {ts '2021-07-01 12:22:08.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'irap' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('irap','stipendio','9','18','2','IRAP','S',{ts '2021-07-01 12:22:08.847'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lordo' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Retribuzione totale lorda',kind = 'S',lt = {ts '2021-07-01 12:22:08.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'lordo' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lordo','stipendio','9','18','2','Retribuzione totale lorda','S',{ts '2021-07-01 12:22:08.847'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-15 14:13:37.120'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','stipendio','8',null,null,'','S',{ts '2021-11-15 14:13:37.120'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-15 14:13:37.120'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','stipendio','64',null,null,'','S',{ts '2021-11-15 14:13:37.120'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:20:14.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'scatto' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','stipendio','4',null,null,null,'S',{ts '2021-07-01 12:20:14.677'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'siglaimportazione' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-10 11:07:45.413'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'siglaimportazione' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('siglaimportazione','stipendio','1024',null,null,'','S',{ts '2021-11-10 11:07:45.413'},'Generator','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipendio' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = null,kind = 'S',lt = {ts '2021-07-01 12:20:14.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'stipendio' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipendio','stipendio','9','18','2',null,'S',{ts '2021-07-01 12:20:14.677'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale' AND tablename = 'stipendio')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Totale costo annuo',kind = 'S',lt = {ts '2021-07-01 12:22:08.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale' AND tablename = 'stipendio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale','stipendio','9','18','2','Totale costo annuo','S',{ts '2021-07-01 12:22:08.847'},'assistenza','N','decimal(18,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

