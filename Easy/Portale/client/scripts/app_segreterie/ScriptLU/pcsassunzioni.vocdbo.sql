
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'pcsassunzioni')
UPDATE [tabledescr] SET description = 'Assunzioni e progressioni economiche verticali',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-29 13:00:33.193'},lu = 'Generator',title = 'Assunzioni e progressioni economiche verticali' WHERE tablename = 'pcsassunzioni'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('pcsassunzioni','Assunzioni e progressioni economiche verticali','2','S',{ts '2021-11-29 13:00:33.193'},'Generator','Assunzioni e progressioni economiche verticali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicessd' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-15 10:11:05.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'codicessd' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicessd','pcsassunzioni','50',null,null,'','S',{ts '2021-10-15 10:11:05.413'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','pcsassunzioni','8',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','pcsassunzioni','64',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-15 10:13:13.047'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','pcsassunzioni','8',null,null,'','S',{ts '2021-10-15 10:13:13.047'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanziamento' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'finanziamento' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanziamento','pcsassunzioni','150',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','pcsassunzioni','4',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind_start' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-11 12:01:22.517'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind_start' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind_start','pcsassunzioni','4',null,null,'','S',{ts '2021-11-11 12:01:22.517'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpcsassunzioni' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpcsassunzioni' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpcsassunzioni','pcsassunzioni','4',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-19 12:58:13.210'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','pcsassunzioni','4',null,null,'','S',{ts '2021-11-19 12:58:13.210'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','pcsassunzioni','4',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'legge' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '250',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(250)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'legge' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('legge','pcsassunzioni','250',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','varchar(250)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','pcsassunzioni','8',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','pcsassunzioni','64',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nominativo' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'nominativo' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nominativo','pcsassunzioni','150',null,null,'','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numeropersoneassunzione' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-29 13:00:33.200'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'numeropersoneassunzione' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numeropersoneassunzione','pcsassunzioni','9','19','2','','S',{ts '2021-11-29 13:00:33.200'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'percentuale' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '6',description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,6)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'percentuale' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('percentuale','pcsassunzioni','9','19','6','','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','decimal(19,6)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipendio' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-11-11 12:01:22.517'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'stipendio' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipendio','pcsassunzioni','9','19','2','','S',{ts '2021-11-11 12:01:22.517'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale','pcsassunzioni','9','19','2','','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale1' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale1' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale1','pcsassunzioni','9','19','2','','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale2' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale2' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale2','pcsassunzioni','9','19','2','','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale3' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-14 17:06:56.353'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale3' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale3','pcsassunzioni','9','19','2','','S',{ts '2021-10-14 17:06:56.353'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'pcsassunzioni')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-15 10:30:00.343'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'pcsassunzioni'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','pcsassunzioni','4',null,null,'','S',{ts '2021-10-15 10:30:00.343'},'Generator','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

