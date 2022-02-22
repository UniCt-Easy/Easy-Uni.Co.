
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazionepersonaleuo')
UPDATE [tabledescr] SET description = 'Performance dell’unità organizzativa',idapplication = null,isdbo = 'N',lt = {ts '2021-06-15 14:31:47.557'},lu = 'assistenza',title = 'Performance dell’unità organizzativa' WHERE tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazionepersonaleuo','Performance dell’unità organizzativa',null,'N',{ts '2021-06-15 14:31:47.557'},'assistenza','Performance dell’unità organizzativa')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'afferenza' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Tempo di afferenza',kind = 'S',lt = {ts '2021-06-15 14:32:46.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'afferenza' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('afferenza','perfvalutazionepersonaleuo','9','19','2','Tempo di afferenza','S',{ts '2021-06-15 14:32:46.723'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-15 14:45:21.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazionepersonaleuo','8',null,null,null,'S',{ts '2021-06-15 14:45:21.647'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-15 14:45:21.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazionepersonaleuo','64',null,null,null,'S',{ts '2021-06-15 14:45:21.647'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-15 14:31:49.910'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazionepersonale' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazionepersonale','perfvalutazionepersonaleuo','4',null,null,null,'S',{ts '2021-06-15 14:31:49.910'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazionepersonaleuo' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-15 14:31:49.910'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazionepersonaleuo' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazionepersonaleuo','perfvalutazionepersonaleuo','4',null,null,null,'S',{ts '2021-06-15 14:31:49.910'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura',kind = 'S',lt = {ts '2021-06-15 14:32:46.723'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','perfvalutazionepersonaleuo','4',null,null,'Struttura','S',{ts '2021-06-15 14:32:46.723'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-15 14:45:21.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazionepersonaleuo','8',null,null,null,'S',{ts '2021-06-15 14:45:21.647'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-15 14:45:21.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazionepersonaleuo','64',null,null,null,'S',{ts '2021-06-15 14:45:21.647'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'peso' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso',kind = 'S',lt = {ts '2021-06-15 14:32:46.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'peso' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('peso','perfvalutazionepersonaleuo','9','19','2','Peso','S',{ts '2021-06-15 14:32:46.723'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'punteggio' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Punteggio',kind = 'S',lt = {ts '2021-06-15 14:32:46.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'punteggio' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('punteggio','perfvalutazionepersonaleuo','9','19','2','Punteggio','S',{ts '2021-06-15 14:32:46.723'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'punteggiopesato' AND tablename = 'perfvalutazionepersonaleuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Punteggio pesato',kind = 'S',lt = {ts '2021-06-15 14:32:46.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'punteggiopesato' AND tablename = 'perfvalutazionepersonaleuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('punteggiopesato','perfvalutazionepersonaleuo','9','19','2','Punteggio pesato','S',{ts '2021-06-15 14:32:46.723'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

