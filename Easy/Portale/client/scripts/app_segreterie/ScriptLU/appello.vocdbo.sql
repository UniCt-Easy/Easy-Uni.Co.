
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'appello')
UPDATE [tabledescr] SET description = '2.2.5 Appello d''esame',idapplication = '2',isdbo = 'S',lt = {ts '2021-05-27 12:30:31.257'},lu = 'assistenza',title = 'Appello d''esame' WHERE tablename = 'appello'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('appello','2.2.5 Appello d''esame','2','S',{ts '2021-05-27 12:30:31.257'},'assistenza','Appello d''esame')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','appello','9',null,null,'Anno accademico','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'basevoto' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Votazione di base',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'basevoto' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('basevoto','appello','4',null,null,'Votazione di base','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cftoend' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Numero di crediti mancanti alla conclusione della carriera',kind = 'S',lt = {ts '2019-09-24 18:04:47.763'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cftoend' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cftoend','appello','5','9','2','Numero di crediti mancanti alla conclusione della carriera','S',{ts '2019-09-24 18:04:47.763'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 17:49:43.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','appello','8',null,null,null,'S',{ts '2019-09-24 17:49:43.557'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 17:49:43.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','appello','64',null,null,null,'S',{ts '2019-09-24 17:49:43.557'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','appello','1024',null,null,'Descrizione','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'esteroend' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine di permanenza dello studente all''estero ',kind = 'S',lt = {ts '2019-09-24 18:04:47.763'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'esteroend' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('esteroend','appello','3',null,null,'Data fine di permanenza dello studente all''estero ','S',{ts '2019-09-24 18:04:47.763'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'esterostart' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio di permanenza dello studente all''estero ',kind = 'S',lt = {ts '2019-09-24 18:04:47.763'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'esterostart' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('esterostart','appello','3',null,null,'Data inizio di permanenza dello studente all''estero ','S',{ts '2019-09-24 18:04:47.763'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idappello' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:31:17.383'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idappello' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idappello','appello','4',null,null,null,'S',{ts '2018-07-18 17:31:17.383'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idappelloazionekind' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordinario/Correttivo/Integrativo',kind = 'S',lt = {ts '2019-09-24 18:06:57.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idappelloazionekind' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idappelloazionekind','appello','4',null,null,'Ordinario/Correttivo/Integrativo','S',{ts '2019-09-24 18:06:57.100'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idappellokind' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idappellokind' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idappellokind','appello','4',null,null,'Tipologia','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsessione' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sessione',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsessione' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsessione','appello','4',null,null,'Sessione','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstudprenotkind' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di studenti per la prenotazione',kind = 'S',lt = {ts '2019-09-24 18:04:47.763'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstudprenotkind' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstudprenotkind','appello','4',null,null,'Tipologia di studenti per la prenotazione','S',{ts '2019-09-24 18:04:47.763'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lavoratori' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Studenti lavoratori',kind = 'S',lt = {ts '2019-09-24 18:04:47.763'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'lavoratori' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lavoratori','appello','1',null,null,'Studenti lavoratori','S',{ts '2019-09-24 18:04:47.763'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 17:49:43.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','appello','8',null,null,null,'S',{ts '2019-09-24 17:49:43.557'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 17:49:43.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','appello','64',null,null,null,'S',{ts '2019-09-24 17:49:43.557'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'minanniiscr' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero minimo di anni di iscrizione',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'minanniiscr' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('minanniiscr','appello','4',null,null,'Numero minimo di anni di iscrizione','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'minvoto' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voto minimo',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'minvoto' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('minvoto','appello','4',null,null,'Voto minimo','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'passaggio' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Studenti che hanno eseguito un passaggio di corso',kind = 'S',lt = {ts '2019-09-24 18:06:57.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'passaggio' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('passaggio','appello','1',null,null,'Studenti che hanno eseguito un passaggio di corso','S',{ts '2019-09-24 18:06:57.100'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'penotend' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data fine delle prenotazioni',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'penotend' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('penotend','appello','8',null,null,'Data fine delle prenotazioni','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'posti' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero massimo di posti',kind = 'S',lt = {ts '2019-09-24 18:06:57.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'posti' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('posti','appello','4',null,null,'Numero massimo di posti','S',{ts '2019-09-24 18:06:57.100'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'prenotstart' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio prenotazioni',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'prenotstart' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('prenotstart','appello','8',null,null,'Data di inizio prenotazioni','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'prointermedia' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Prova intermedia',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'prointermedia' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('prointermedia','appello','1',null,null,'Prova intermedia','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'publicato' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 17:49:43.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'publicato' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('publicato','appello','1',null,null,null,'S',{ts '2019-09-24 17:49:43.557'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surmanestop' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Iniziali cognome fine',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surmanestop' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surmanestop','appello','50',null,null,'Iniziali cognome fine','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surnamestart' AND tablename = 'appello')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Iniziali cognome inizio',kind = 'S',lt = {ts '2019-09-24 18:01:03.853'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surnamestart' AND tablename = 'appello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surnamestart','appello','50',null,null,'Iniziali cognome inizio','S',{ts '2019-09-24 18:01:03.853'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

