
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'inquadramento')
UPDATE [tabledescr] SET description = 'Inquadramento',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-10 11:08:46.813'},lu = 'Generator',title = 'Inquadramento' WHERE tablename = 'inquadramento'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('inquadramento','Inquadramento','2','S',{ts '2021-11-10 11:08:46.813'},'Generator','Inquadramento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuo' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-05 10:03:11.320'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuo' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuo','inquadramento','5','9','2','','S',{ts '2021-11-05 10:03:11.320'},'Generator','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuooneri' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-05 10:03:11.320'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuooneri' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuooneri','inquadramento','5','9','2','','S',{ts '2021-11-05 10:03:11.320'},'Generator','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','inquadramento','8',null,null,null,'S',{ts '2020-07-14 16:13:13.993'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','inquadramento','64',null,null,null,'S',{ts '2020-07-14 16:13:13.993'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','inquadramento','4',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinquadramento' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinquadramento' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinquadramento','inquadramento','4',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','inquadramento','8',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','inquadramento','64',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'siglaimportazione' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-10 11:05:41.603'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'siglaimportazione' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('siglaimportazione','inquadramento','1024',null,null,'','S',{ts '2021-11-10 11:05:41.603'},'Generator','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:19:20.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','inquadramento','8',null,null,null,'S',{ts '2021-07-01 12:19:20.460'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:19:20.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','inquadramento','8',null,null,null,'S',{ts '2021-07-01 12:19:20.460'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempdef' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-07-01 12:19:20.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempdef' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempdef','inquadramento','1',null,null,null,'S',{ts '2021-07-01 12:19:20.463'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'inquadramento')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 16:13:13.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'inquadramento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','inquadramento','2048',null,null,null,'S',{ts '2020-07-14 16:13:13.997'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --
