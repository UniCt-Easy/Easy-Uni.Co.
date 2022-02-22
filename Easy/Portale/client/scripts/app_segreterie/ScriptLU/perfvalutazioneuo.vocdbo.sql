
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazioneuo')
UPDATE [tabledescr] SET description = 'Schede di valutazione delle Unità organizzative',idapplication = '2',isdbo = 'S',lt = {ts '2022-02-07 16:19:26.943'},lu = 'Generator',title = 'Schede di valutazione delle Unità organizzative' WHERE tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazioneuo','Schede di valutazione delle Unità organizzative','2','S',{ts '2022-02-07 16:19:26.943'},'Generator','Schede di valutazione delle Unità organizzative')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'completamentopsauo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento dei progetti Strategici di altre UO',kind = 'S',lt = {ts '2021-07-30 13:07:41.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'completamentopsauo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('completamentopsauo','perfvalutazioneuo','9','19','2','Percentuale di completamento dei progetti Strategici di altre UO','S',{ts '2021-07-30 13:07:41.427'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'completamentopsuo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento per i progetti Strategici della UO',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'completamentopsuo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('completamentopsuo','perfvalutazioneuo','9','19','2','Percentuale di completamento per i progetti Strategici della UO','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazioneuo','8',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazioneuo','64',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedastatus' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2021-05-31 17:06:34.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedastatus' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedastatus','perfvalutazioneuo','4',null,null,'Stato','S',{ts '2021-05-31 17:06:34.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneuo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-01 17:07:15.013'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneuo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneuo','perfvalutazioneuo','4',null,null,null,'S',{ts '2021-06-01 17:07:15.013'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_appr' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-06 15:28:12.583'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_appr' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_appr','perfvalutazioneuo','4',null,null,'','S',{ts '2021-10-06 15:28:12.583'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_val' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Valutatore',kind = 'S',lt = {ts '2021-05-31 17:06:34.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_val' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_val','perfvalutazioneuo','4',null,null,'Valutatore','S',{ts '2021-05-31 17:06:34.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura',kind = 'S',lt = {ts '2021-06-10 16:17:39.787'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','perfvalutazioneuo','4',null,null,'Struttura','S',{ts '2021-06-10 16:17:39.787'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicatori' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento degli indicatori',kind = 'S',lt = {ts '2021-07-30 13:11:42.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'indicatori' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicatori','perfvalutazioneuo','9','19','2','Percentuale di completamento degli indicatori','S',{ts '2021-07-30 13:11:42.140'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazioneuo','8',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazioneuo','64',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obiettiviindividuali' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento degli obiettivi una tantum',kind = 'S',lt = {ts '2021-09-29 13:15:20.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'obiettiviindividuali' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obiettiviindividuali','perfvalutazioneuo','9','19','2','Percentuale di completamento degli obiettivi una tantum','S',{ts '2021-09-29 13:15:20.600'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoindicatori' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance degli indicatori ',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoindicatori' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoindicatori','perfvalutazioneuo','9','19','2','Peso della valutazione della performance degli indicatori ','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoobiettivi' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance degli obiettivi una tantum',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoobiettivi' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoobiettivi','perfvalutazioneuo','9','19','2','Peso della valutazione della performance degli obiettivi una tantum','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoprogaltreuo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance dei Progetti Strategici di altre UO ',kind = 'S',lt = {ts '2021-07-30 13:07:41.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoprogaltreuo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoprogaltreuo','perfvalutazioneuo','9','19','2','Peso della valutazione della performance dei Progetti Strategici di altre UO ','S',{ts '2021-07-30 13:07:41.427'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoproguo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance dei Progetti Strategici della UO',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoproguo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoproguo','perfvalutazioneuo','9','19','2','Peso della valutazione della performance dei Progetti Strategici della UO','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'risultato' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Risultato %',kind = 'S',lt = {ts '2021-07-30 13:12:39.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'risultato' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('risultato','perfvalutazioneuo','9','19','2','Risultato %','S',{ts '2021-07-30 13:12:39.723'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno solare',kind = 'S',lt = {ts '2021-05-31 17:06:34.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','perfvalutazioneuo','4',null,null,'Anno solare','S',{ts '2021-05-31 17:06:34.270'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

