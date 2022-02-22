
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tipologiastudente')
UPDATE [tabledescr] SET description = 'Caratteristiche dello studente per cui si indicano date di presentazione specifiche, si richiedono allegati specifici, o si richiedono requisiti specifici per partecipare ad un 2.5.12 Bando per il diritto allo studio
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 17:17:21.767'},lu = 'assistenza',title = 'Caratteristiche dello studente per cui si offre il servizio di un bando per il diritto allo s' WHERE tablename = 'tipologiastudente'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tipologiastudente','Caratteristiche dello studente per cui si indicano date di presentazione specifiche, si richiedono allegati specifici, o si richiedono requisiti specifici per partecipare ad un 2.5.12 Bando per il diritto allo studio
',null,'N',{ts '2018-07-27 17:17:21.767'},'assistenza','Caratteristiche dello studente per cui si offre il servizio di un bando per il diritto allo s')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'abbreviazione' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Iscritto con una abbreviazione di corso',kind = 'S',lt = {ts '2019-11-29 10:15:09.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'abbreviazione' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('abbreviazione','tipologiastudente','1',null,null,'Iscritto con una abbreviazione di corso','S',{ts '2019-11-29 10:15:09.287'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annoiscr' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di iscrizione',kind = 'S',lt = {ts '2019-11-29 10:15:09.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annoiscr' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annoiscr','tipologiastudente','4',null,null,'Anno di iscrizione','S',{ts '2019-11-29 10:15:09.287'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:15:29.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tipologiastudente','8',null,null,null,'S',{ts '2018-07-27 17:15:29.243'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:15:29.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tipologiastudente','64',null,null,null,'S',{ts '2018-07-27 17:15:29.243'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandods' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:09:41.707'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandods' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandods','tipologiastudente','4',null,null,null,'S',{ts '2019-11-29 10:09:41.707'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandodsservizio' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:09:41.707'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandodsservizio' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandodsservizio','tipologiastudente','4',null,null,null,'S',{ts '2019-11-29 10:09:41.707'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia del corso a cui è iscritto',kind = 'S',lt = {ts '2019-11-29 10:15:09.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','tipologiastudente','4',null,null,'Tipologia del corso a cui è iscritto','S',{ts '2019-11-29 10:15:09.287'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipologiastudente' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:15:29.243'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipologiastudente' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipologiastudente','tipologiastudente','4',null,null,null,'S',{ts '2018-07-27 17:15:29.243'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'immatricolato' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:15:29.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'immatricolato' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('immatricolato','tipologiastudente','1',null,null,null,'S',{ts '2018-07-27 17:15:29.243'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iscrittobmi' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Iscritto ad un bando di mobilità internazionale',kind = 'S',lt = {ts '2019-11-29 10:15:09.290'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'iscrittobmi' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iscrittobmi','tipologiastudente','1',null,null,'Iscritto ad un bando di mobilità internazionale','S',{ts '2019-11-29 10:15:09.290'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:15:29.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tipologiastudente','8',null,null,null,'S',{ts '2018-07-27 17:15:29.243'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:15:29.243'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tipologiastudente','64',null,null,null,'S',{ts '2018-07-27 17:15:29.243'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'passaggio' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Iscritto con un passaggio di corso',kind = 'S',lt = {ts '2019-11-29 10:15:09.290'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'passaggio' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('passaggio','tipologiastudente','1',null,null,'Iscritto con un passaggio di corso','S',{ts '2019-11-29 10:15:09.290'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tri' AND tablename = 'tipologiastudente')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Trasferimento in ingresso',kind = 'S',lt = {ts '2020-09-09 12:05:42.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tri' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tri','tipologiastudente','1',null,null,'Trasferimento in ingresso','S',{ts '2020-09-09 12:05:42.103'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3400')
UPDATE [relation] SET childtable = 'tipologiastudente',description = 'date di presentazione per questa tipologia di studente',lt = {ts '2018-07-27 17:19:23.697'},lu = 'assistenza',parenttable = 'bandodsserviziodatepres',title = null WHERE idrelation = '3400'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3400','tipologiastudente','date di presentazione per questa tipologia di studente',{ts '2018-07-27 17:19:23.697'},'assistenza','bandodsserviziodatepres',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3401')
UPDATE [relation] SET childtable = 'tipologiastudente',description = 'allegati richiesti per questa tipologia di studente',lt = {ts '2018-07-27 17:19:23.720'},lu = 'assistenza',parenttable = 'bandodsservizioattach',title = null WHERE idrelation = '3401'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3401','tipologiastudente','allegati richiesti per questa tipologia di studente',{ts '2018-07-27 17:19:23.720'},'assistenza','bandodsservizioattach',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3402')
UPDATE [relation] SET childtable = 'tipologiastudente',description = 'graduatoria per questa tipologia di studente',lt = {ts '2018-07-27 17:19:23.720'},lu = 'assistenza',parenttable = 'bandodsserviziograduatoria',title = null WHERE idrelation = '3402'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3402','tipologiastudente','graduatoria per questa tipologia di studente',{ts '2018-07-27 17:19:23.720'},'assistenza','bandodsserviziograduatoria',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3403')
UPDATE [relation] SET childtable = 'tipologiastudente',description = 'requisiti richiesti per questa tipologia di studente',lt = {ts '2018-07-27 17:19:23.720'},lu = 'assistenza',parenttable = 'bandodsserviziorequisito',title = null WHERE idrelation = '3403'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3403','tipologiastudente','requisiti richiesti per questa tipologia di studente',{ts '2018-07-27 17:19:23.720'},'assistenza','bandodsserviziorequisito',null)
GO

-- FINE GENERAZIONE SCRIPT --

