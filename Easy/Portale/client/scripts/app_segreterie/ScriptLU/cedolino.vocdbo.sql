
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'cedolino')
UPDATE [tabledescr] SET description = 'Cedolino',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-04 16:24:14.377'},lu = 'Generator',title = 'Cedolino' WHERE tablename = 'cedolino'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('cedolino','Cedolino','2','S',{ts '2021-11-04 16:24:14.377'},'Generator','Cedolino')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegno' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Assegno aggiuntivo',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'assegno' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegno','cedolino','9','18','2','Assegno aggiuntivo','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'classe' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'classe' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('classe','cedolino','4',null,null,null,'S',{ts '2021-11-04 16:19:41.657'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:24:14.383'},lu = 'Generator',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','cedolino','3',null,null,'','S',{ts '2021-11-04 16:24:14.383'},'Generator','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcedolino' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcedolino' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcedolino','cedolino','4',null,null,'','S',{ts '2021-11-04 16:19:41.657'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontratto' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontratto' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontratto','cedolino','4',null,null,'','S',{ts '2021-11-04 16:19:41.657'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmese' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:24:14.383'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmese' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmese','cedolino','4',null,null,'','S',{ts '2021-11-04 16:24:14.383'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','cedolino','4',null,null,'','S',{ts '2021-11-04 16:19:41.657'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iis' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Indennità integrativa speciale',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'iis' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iis','cedolino','9','18','2','Indennità integrativa speciale','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'irap' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'IRAP',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'irap' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('irap','cedolino','9','18','2','IRAP','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lordo' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Retribuzione totale lorda',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'lordo' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lordo','cedolino','9','18','2','Retribuzione totale lorda','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'scatto' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','cedolino','4',null,null,null,'S',{ts '2021-11-04 16:19:41.657'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipendio' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = null,kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'stipendio' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipendio','cedolino','9','18','2',null,'S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Totale costo annuo',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale','cedolino','9','18','2','Totale costo annuo','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:24:14.383'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','cedolino','4',null,null,'','S',{ts '2021-11-04 16:24:14.383'},'Generator','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

