
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'protocollo')
UPDATE [tabledescr] SET description = '2.6.12 Registrazione di protocollo e Segnatura',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-22 10:31:23.380'},lu = 'assistenza',title = 'Registrazione di protocollo e Segnatura' WHERE tablename = 'protocollo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('protocollo','2.6.12 Registrazione di protocollo e Segnatura','3','S',{ts '2021-02-22 10:31:23.380'},'assistenza','Registrazione di protocollo e Segnatura')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'annullato' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 10:44:30.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'annullato' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annullato','protocollo','1',null,null,null,'S',{ts '2020-03-27 10:44:30.100'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceammipa' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice IPA dell''Istituto',kind = 'S',lt = {ts '2020-03-27 10:42:43.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceammipa' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceammipa','protocollo','50',null,null,'Codice IPA dell''Istituto','S',{ts '2020-03-27 10:42:43.043'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceregistro' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Codice Registro (univoco nell''Istituto)',kind = 'S',lt = {ts '2020-09-16 10:31:03.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceregistro' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceregistro','protocollo','1024',null,null,'Codice Registro (univoco nell''Istituto)','S',{ts '2020-09-16 10:31:03.503'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','protocollo','8',null,null,null,'S',{ts '2018-07-18 16:05:35.833'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','protocollo','64',null,null,null,'S',{ts '2018-07-18 16:05:35.833'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataannullamento' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di annullamento',kind = 'S',lt = {ts '2020-09-16 10:31:15.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'dataannullamento' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataannullamento','protocollo','8',null,null,'Data di annullamento','S',{ts '2020-09-16 10:31:15.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaoo' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area organizzativa omogenea',kind = 'S',lt = {ts '2020-03-27 10:42:43.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaoo' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaoo','protocollo','4',null,null,'Area organizzativa omogenea','S',{ts '2020-03-27 10:42:43.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_origine' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Mittente',kind = 'S',lt = {ts '2020-03-27 10:42:43.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_origine' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_origine','protocollo','4',null,null,'Mittente','S',{ts '2020-03-27 10:42:43.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.837'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','protocollo','8',null,null,null,'S',{ts '2018-07-18 16:05:35.837'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:05:35.837'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','protocollo','64',null,null,null,'S',{ts '2018-07-18 16:05:35.837'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oggetto' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Oggetto del documento',kind = 'S',lt = {ts '2020-03-27 10:54:48.823'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'oggetto' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oggetto','protocollo','1024',null,null,'Oggetto del documento','S',{ts '2020-03-27 10:54:48.823'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'originecodiceaoo' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea',kind = 'S',lt = {ts '2020-03-27 11:02:51.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'originecodiceaoo' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('originecodiceaoo','protocollo','50',null,null,'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea','S',{ts '2020-03-27 11:02:51.807'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'origineidamm' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Amministrazione pubblica mittente - Codice IPA',kind = 'S',lt = {ts '2020-03-27 11:02:51.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'origineidamm' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('origineidamm','protocollo','50',null,null,'Amministrazione pubblica mittente - Codice IPA','S',{ts '2020-03-27 11:02:51.807'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'originemail' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'E-mail mittente',kind = 'S',lt = {ts '2020-03-27 10:54:48.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'originemail' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('originemail','protocollo','512',null,null,'E-mail mittente','S',{ts '2020-03-27 10:54:48.827'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protanno' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di protocollo',kind = 'S',lt = {ts '2020-03-27 10:54:48.827'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protanno' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protanno','protocollo','4',null,null,'Anno di protocollo','S',{ts '2020-03-27 10:54:48.827'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protdata' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di protocollo',kind = 'S',lt = {ts '2020-03-27 10:54:48.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'protdata' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protdata','protocollo','3',null,null,'Data di protocollo','S',{ts '2020-03-27 10:54:48.827'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protnumero' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di protocollo',kind = 'S',lt = {ts '2020-03-27 10:44:28.387'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protnumero' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protnumero','protocollo','4',null,null,'Numero di protocollo','S',{ts '2020-03-27 10:44:28.387'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'testo' AND tablename = 'protocollo')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Testo del documento (alternativamente al descrittore del documento)',kind = 'S',lt = {ts '2020-09-16 10:31:03.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'testo' AND tablename = 'protocollo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('testo','protocollo','-1',null,null,'Testo del documento (alternativamente al descrittore del documento)','S',{ts '2020-09-16 10:31:03.503'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

