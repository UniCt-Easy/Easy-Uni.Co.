
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'bandodsservizio')
UPDATE [tabledescr] SET description = 'Servizi offerti nel 2.5.12 Bando per il diritto allo studio
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 16:20:54.503'},lu = 'assistenza',title = 'Servizi offerti nel bando per il diritto allo studio' WHERE tablename = 'bandodsservizio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('bandodsservizio','Servizi offerti nel 2.5.12 Bando per il diritto allo studio
',null,'N',{ts '2018-07-27 16:20:54.503'},'assistenza','Servizi offerti nel bando per il diritto allo studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'alloggio' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Servizio alloggio',kind = 'S',lt = {ts '2020-09-08 18:17:21.897'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'alloggio' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('alloggio','bandodsservizio','1',null,null,'Servizio alloggio','S',{ts '2020-09-08 18:17:21.897'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'borsafuorisede' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Importo annuo borsa contributi (fuori sede)',kind = 'S',lt = {ts '2020-09-08 18:22:41.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'borsafuorisede' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('borsafuorisede','bandodsservizio','5','9','2','Importo annuo borsa contributi (fuori sede)','S',{ts '2020-09-08 18:22:41.090'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'borsainsede' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Importo annuo borsa contributi (in sede)',kind = 'S',lt = {ts '2020-09-08 18:22:41.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'borsainsede' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('borsainsede','bandodsservizio','5','9','2','Importo annuo borsa contributi (in sede)','S',{ts '2020-09-08 18:22:41.090'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'borsapendolari' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Importo annuo borsa contributi (pendolari)',kind = 'S',lt = {ts '2020-09-08 18:22:41.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'borsapendolari' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('borsapendolari','bandodsservizio','5','9','2','Importo annuo borsa contributi (pendolari)','S',{ts '2020-09-08 18:22:41.090'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributo' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2018-07-27 16:20:55.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributo' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributo','bandodsservizio','5','9','2',null,'S',{ts '2018-07-27 16:20:55.813'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributomiimporto' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Importo contributi per mobilità internazionale',kind = 'S',lt = {ts '2020-09-08 18:22:41.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributomiimporto' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributomiimporto','bandodsservizio','5','9','2','Importo contributi per mobilità internazionale','S',{ts '2020-09-08 18:22:41.090'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributomimesi' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero mesi contributi mobilità internazionale',kind = 'S',lt = {ts '2020-09-08 18:22:41.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'contributomimesi' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributomimesi','bandodsservizio','4',null,null,'Numero mesi contributi mobilità internazionale','S',{ts '2020-09-08 18:22:41.090'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:20:55.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','bandodsservizio','8',null,null,null,'S',{ts '2018-07-27 16:20:55.813'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:20:55.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','bandodsservizio','64',null,null,null,'S',{ts '2018-07-27 16:20:55.813'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fuoricorso' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Fuori corso',kind = 'S',lt = {ts '2020-09-08 18:22:41.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'fuoricorso' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fuoricorso','bandodsservizio','1',null,null,'Fuori corso','S',{ts '2020-09-08 18:22:41.090'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandods' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 18:32:38.650'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandods' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandods','bandodsservizio','4',null,null,null,'S',{ts '2019-11-28 18:32:38.650'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandodsservizio' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:20:55.817'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandodsservizio' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandodsservizio','bandodsservizio','4',null,null,null,'S',{ts '2018-07-27 16:20:55.817'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandodsserviziokind' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo servizio offerto',kind = 'S',lt = {ts '2020-09-09 10:41:14.650'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandodsserviziokind' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandodsserviziokind','bandodsservizio','4',null,null,'Tipo servizio offerto','S',{ts '2020-09-09 10:41:14.650'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idesonero' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Esonero',kind = 'S',lt = {ts '2020-09-09 10:35:17.727'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idesonero' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idesonero','bandodsservizio','4',null,null,'Esonero','S',{ts '2020-09-09 10:35:17.727'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistattitolistudio_min' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Titolo minimo di studio',kind = 'S',lt = {ts '2020-09-10 13:11:35.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistattitolistudio_min' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistattitolistudio_min','bandodsservizio','4',null,null,'Titolo minimo di studio','S',{ts '2020-09-10 13:11:35.187'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iseemax' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'ISEE massimo',kind = 'S',lt = {ts '2020-09-09 10:33:18.293'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'iseemax' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iseemax','bandodsservizio','5','9','2','ISEE massimo','S',{ts '2020-09-09 10:33:18.293'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ispemax' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'ISPE massimo',kind = 'S',lt = {ts '2020-09-09 10:33:18.297'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'ispemax' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ispemax','bandodsservizio','5','9','2','ISPE massimo','S',{ts '2020-09-09 10:33:18.297'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:20:55.817'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','bandodsservizio','8',null,null,null,'S',{ts '2018-07-27 16:20:55.817'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:20:55.817'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','bandodsservizio','64',null,null,null,'S',{ts '2018-07-27 16:20:55.817'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'maggiorenne' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 16:20:55.817'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'maggiorenne' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('maggiorenne','bandodsservizio','1',null,null,null,'S',{ts '2018-07-27 16:20:55.817'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'mensa' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Servizio mensa',kind = 'S',lt = {ts '2020-09-08 18:17:21.897'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'mensa' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('mensa','bandodsservizio','1',null,null,'Servizio mensa','S',{ts '2020-09-08 18:17:21.897'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parttime' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Part Time',kind = 'S',lt = {ts '2020-09-08 18:22:41.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'parttime' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parttime','bandodsservizio','1',null,null,'Part Time','S',{ts '2020-09-08 18:22:41.090'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'primaimmatlivello' AND tablename = 'bandodsservizio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Immatricolato per la prima volta a questo livello',kind = 'S',lt = {ts '2020-09-09 10:33:18.297'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'primaimmatlivello' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('primaimmatlivello','bandodsservizio','1',null,null,'Immatricolato per la prima volta a questo livello','S',{ts '2020-09-09 10:33:18.297'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3390')
UPDATE [relation] SET childtable = 'bandodsservizio',description = 'bando di cui fanno parte',lt = {ts '2018-07-27 16:21:10.227'},lu = 'assistenza',parenttable = 'bandods',title = null WHERE idrelation = '3390'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3390','bandodsservizio','bando di cui fanno parte',{ts '2018-07-27 16:21:10.227'},'assistenza','bandods',null)
GO

-- FINE GENERAZIONE SCRIPT --

