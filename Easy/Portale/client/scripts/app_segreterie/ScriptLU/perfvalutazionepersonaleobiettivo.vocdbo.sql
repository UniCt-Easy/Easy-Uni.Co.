
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [tabledescr] SET description = 'Obiettivi Individuali',idapplication = '2',isdbo = 'S',lt = {ts '2021-09-15 16:47:17.467'},lu = 'Generator',title = 'Obiettivi Individuali' WHERE tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazionepersonaleobiettivo','Obiettivi Individuali','2','S',{ts '2021-09-15 16:47:17.467'},'Generator','Obiettivi Individuali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'completamento' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento',kind = 'S',lt = {ts '2021-08-02 09:30:17.867'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'completamento' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('completamento','perfvalutazionepersonaleobiettivo','9','19','2','Percentuale di completamento','S',{ts '2021-08-02 09:30:17.867'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-02 09:14:31.943'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazionepersonaleobiettivo','8',null,null,null,'S',{ts '2021-08-02 09:14:31.943'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-02 09:14:31.943'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazionepersonaleobiettivo','64',null,null,null,'S',{ts '2021-08-02 09:14:31.943'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-08-02 09:30:17.867'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfvalutazionepersonaleobiettivo','-1',null,null,'Descrizione','S',{ts '2021-08-02 09:30:17.867'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-02 09:14:31.943'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazionepersonale','perfvalutazionepersonaleobiettivo','4',null,null,null,'S',{ts '2021-08-02 09:14:31.943'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazionepersonaleobiettivo' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-02 09:14:31.943'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazionepersonaleobiettivo' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazionepersonaleobiettivo','perfvalutazionepersonaleobiettivo','4',null,null,null,'S',{ts '2021-08-02 09:14:31.943'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'inverso' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-02 10:16:39.293'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'inverso' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('inverso','perfvalutazionepersonaleobiettivo','1',null,null,null,'S',{ts '2021-08-02 10:16:39.293'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-02 09:14:31.943'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazionepersonaleobiettivo','8',null,null,null,'S',{ts '2021-08-02 09:14:31.943'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-08-02 09:14:31.943'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazionepersonaleobiettivo','64',null,null,null,'S',{ts '2021-08-02 09:14:31.943'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'peso' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso',kind = 'S',lt = {ts '2021-08-02 09:30:17.867'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'peso' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('peso','perfvalutazionepersonaleobiettivo','9','19','2','Peso','S',{ts '2021-08-02 09:30:17.867'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2021-08-02 09:30:17.867'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfvalutazionepersonaleobiettivo','2048',null,null,'Titolo','S',{ts '2021-08-02 09:30:17.867'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valorenumerico' AND tablename = 'perfvalutazionepersonaleobiettivo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Valore numerico raggiunto',kind = 'S',lt = {ts '2021-08-02 09:55:39.900'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'valorenumerico' AND tablename = 'perfvalutazionepersonaleobiettivo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valorenumerico','perfvalutazionepersonaleobiettivo','9','19','2','Valore numerico raggiunto','S',{ts '2021-08-02 09:55:39.900'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

