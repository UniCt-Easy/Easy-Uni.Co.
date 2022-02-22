
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tirocinioprogetto')
UPDATE [tabledescr] SET description = '2.5.23 Progetto formativo
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:28:06.157'},lu = 'assistenza',title = 'Progetto formativo' WHERE tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tirocinioprogetto','2.5.23 Progetto formativo
',null,'N',{ts '2018-07-27 13:28:06.157'},'assistenza','Progetto formativo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'competenze' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'competenze' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('competenze','tirocinioprogetto','-1',null,null,null,'S',{ts '2018-07-27 13:27:53.770'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tirocinioprogetto','8',null,null,null,'S',{ts '2018-07-27 13:27:53.770'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tirocinioprogetto','64',null,null,null,'S',{ts '2018-07-27 13:27:53.770'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineeffettiva' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine effettiva',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datafineeffettiva' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineeffettiva','tirocinioprogetto','3',null,null,'Data fine effettiva','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineprevista' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine prevista',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datafineprevista' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineprevista','tirocinioprogetto','3',null,null,'Data fine prevista','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioeffettiva' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio effettiva',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioeffettiva' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioeffettiva','tirocinioprogetto','3',null,null,'Data inizio effettiva','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','tirocinioprogetto','3',null,null,'Data inizio prevista','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataverbale' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data verbale',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'dataverbale' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataverbale','tirocinioprogetto','3',null,null,'Data verbale','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','tirocinioprogetto','-1',null,null,'Descrizione','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description_en' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione in inglese',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description_en' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description_en','tirocinioprogetto','-1',null,null,'Descrizione in inglese','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaoo' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area organizzativa omogenea',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaoo' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaoo','tirocinioprogetto','4',null,null,'Area organizzativa omogenea','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tutor',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','tirocinioprogetto','4',null,null,'Tutor','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_referente' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Referente dell''azienda',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_referente' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_referente','tirocinioprogetto','4',null,null,'Referente dell''azienda','S',{ts '2021-06-22 11:03:58.907'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_studenti' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'idreg_studenti' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_studenti','tirocinioprogetto','10',null,null,'Studente','S',{ts '2021-06-22 11:03:58.907'},'assistenza','S','nchar(10)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-08-30 16:52:39.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','tirocinioprogetto','4',null,null,'Sede','S',{ts '2019-08-30 16:52:39.457'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica',kind = 'S',lt = {ts '2019-09-09 18:56:05.107'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','tirocinioprogetto','4',null,null,'Struttura didattica','S',{ts '2019-09-09 18:56:05.107'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 18:21:13.250'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniocandidatura','tirocinioprogetto','4',null,null,null,'S',{ts '2019-11-28 18:21:13.250'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniopoposto' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 18:21:13.250'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'idtirociniopoposto' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniopoposto','tirocinioprogetto','10',null,null,null,'S',{ts '2019-11-28 18:21:13.250'},'assistenza','S','nchar(10)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirocinioprogetto' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.773'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirocinioprogetto' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirocinioprogetto','tirocinioprogetto','4',null,null,null,'S',{ts '2018-07-27 13:27:53.773'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirocinioproposto' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-03 17:32:39.030'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirocinioproposto' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirocinioproposto','tirocinioprogetto','4',null,null,null,'S',{ts '2020-09-03 17:32:39.030'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniostato' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato del tirocinio',kind = 'S',lt = {ts '2021-06-22 11:15:06.500'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniostato' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniostato','tirocinioprogetto','4',null,null,'Stato del tirocinio','S',{ts '2021-06-22 11:15:06.500'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tirocinioprogetto','8',null,null,null,'S',{ts '2018-07-27 13:27:53.773'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tirocinioprogetto','64',null,null,null,'S',{ts '2018-07-27 13:27:53.773'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ore' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ore' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ore','tirocinioprogetto','4',null,null,'Ore','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protanno' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno protocollo',kind = 'S',lt = {ts '2020-07-06 16:19:38.337'},lu = 'mluisas',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protanno' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protanno','tirocinioprogetto','4',null,null,'Anno protocollo','S',{ts '2020-07-06 16:19:38.337'},'mluisas','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protnumero' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero Protocollo',kind = 'S',lt = {ts '2020-07-06 16:19:55.930'},lu = 'mluisas',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protnumero' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protnumero','tirocinioprogetto','4',null,null,'Numero Protocollo','S',{ts '2020-07-06 16:19:55.930'},'mluisas','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempiaccesso' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Tempi di accesso',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tempiaccesso' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempiaccesso','tirocinioprogetto','-1',null,null,'Tempi di accesso','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','tirocinioprogetto','-1',null,null,'Titolo','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo in inglese',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','tirocinioprogetto','-1',null,null,'Titolo in inglese','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

