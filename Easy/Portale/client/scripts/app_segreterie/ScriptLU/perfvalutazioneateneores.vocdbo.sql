
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazioneateneores')
UPDATE [tabledescr] SET description = 'Risultati della performance istituzionale',idapplication = '2',isdbo = 'S',lt = {ts '2022-01-05 12:29:51.010'},lu = 'Generator',title = 'Risultati della performance istituzionale' WHERE tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazioneateneores','Risultati della performance istituzionale','2','S',{ts '2022-01-05 12:29:51.010'},'Generator','Risultati della performance istituzionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:32:28.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazioneateneores','8',null,null,null,'S',{ts '2021-05-31 12:32:28.147'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:32:28.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazioneateneores','64',null,null,null,'S',{ts '2021-05-31 12:32:28.147'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fonte' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Fonte',kind = 'S',lt = {ts '2021-05-31 12:35:56.443'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'fonte' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fonte','perfvalutazioneateneores','1024',null,null,'Fonte','S',{ts '2021-05-31 12:35:56.443'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfmission' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Missione Istituzionale',kind = 'S',lt = {ts '2021-05-31 12:35:56.443'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfmission' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfmission','perfvalutazioneateneores','4',null,null,'Missione Istituzionale','S',{ts '2021-05-31 12:35:56.443'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneateneo' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:32:28.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneateneo' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneateneo','perfvalutazioneateneores','4',null,null,null,'S',{ts '2021-05-31 12:32:28.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneateneores' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 13:12:39.853'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneateneores' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneateneores','perfvalutazioneateneores','4',null,null,null,'S',{ts '2021-05-31 13:12:39.853'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Compilatore',kind = 'S',lt = {ts '2022-01-03 16:24:29.620'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','perfvalutazioneateneores','4',null,null,'Compilatore','S',{ts '2022-01-03 16:24:29.620'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicatore' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Indicatore',kind = 'S',lt = {ts '2021-07-22 18:20:22.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'indicatore' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicatore','perfvalutazioneateneores','1024',null,null,'Indicatore','S',{ts '2021-07-22 18:20:22.680'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:32:28.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazioneateneores','8',null,null,null,'S',{ts '2021-05-31 12:32:28.147'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:32:28.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazioneateneores','64',null,null,null,'S',{ts '2021-05-31 12:32:28.147'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'percentualeraggiunta' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale raggiunta',kind = 'S',lt = {ts '2021-05-31 12:35:56.443'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'percentualeraggiunta' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('percentualeraggiunta','perfvalutazioneateneores','9','19','2','Percentuale raggiunta','S',{ts '2021-05-31 12:35:56.443'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'peso' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso',kind = 'S',lt = {ts '2021-07-30 16:50:26.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'peso' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('peso','perfvalutazioneateneores','9','19','2','Peso','S',{ts '2021-07-30 16:50:26.597'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'target' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Target',kind = 'S',lt = {ts '2021-05-31 12:35:56.443'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'target' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('target','perfvalutazioneateneores','1024',null,null,'Target','S',{ts '2021-05-31 12:35:56.443'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'valoreraggiunto' AND tablename = 'perfvalutazioneateneores')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Valore raggiunto',kind = 'S',lt = {ts '2021-05-31 12:35:56.443'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'valoreraggiunto' AND tablename = 'perfvalutazioneateneores'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('valoreraggiunto','perfvalutazioneateneores','1024',null,null,'Valore raggiunto','S',{ts '2021-05-31 12:35:56.443'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

