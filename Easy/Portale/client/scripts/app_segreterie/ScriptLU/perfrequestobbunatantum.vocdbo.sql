
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfrequestobbunatantum')
UPDATE [tabledescr] SET description = 'Richiesta di inserimento di un obiettivo una tantum',idapplication = '2',isdbo = 'S',lt = {ts '2021-10-28 17:52:56.630'},lu = 'Generator',title = 'Richiesta di inserimento di un obiettivo una tantum' WHERE tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfrequestobbunatantum','Richiesta di inserimento di un obiettivo una tantum','2','S',{ts '2021-10-28 17:52:56.630'},'Generator','Richiesta di inserimento di un obiettivo una tantum')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-28 17:52:56.633'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfrequestobbunatantum','8',null,null,'','S',{ts '2021-10-28 17:52:56.633'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-28 17:52:56.633'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfrequestobbunatantum','64',null,null,'','S',{ts '2021-10-28 17:52:56.633'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 12:56:42.810'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(MAX)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfrequestobbunatantum','-1',null,null,'','S',{ts '2021-10-05 12:56:42.810'},'Generator','N','varchar(MAX)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfrequestobbunatantum' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 12:56:42.810'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfrequestobbunatantum' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfrequestobbunatantum','perfrequestobbunatantum','4',null,null,'','S',{ts '2021-10-05 12:56:42.810'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 12:56:42.810'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','perfrequestobbunatantum','4',null,null,'','S',{ts '2021-10-05 12:56:42.810'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'inserito' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 12:56:42.810'},lu = 'Generator',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'inserito' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('inserito','perfrequestobbunatantum','1',null,null,'','S',{ts '2021-10-05 12:56:42.810'},'Generator','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-28 17:52:56.633'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfrequestobbunatantum','8',null,null,'','S',{ts '2021-10-28 17:52:56.633'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-28 17:52:56.633'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfrequestobbunatantum','64',null,null,'','S',{ts '2021-10-28 17:52:56.633'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'peso' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-05 12:56:42.810'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'peso' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('peso','perfrequestobbunatantum','9','19','2','','S',{ts '2021-10-05 12:56:42.810'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 12:56:42.810'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfrequestobbunatantum','1024',null,null,'','S',{ts '2021-10-05 12:56:42.810'},'Generator','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'perfrequestobbunatantum')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-05 12:56:42.810'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'perfrequestobbunatantum'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','perfrequestobbunatantum','4',null,null,'','S',{ts '2021-10-05 12:56:42.810'},'Generator','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

