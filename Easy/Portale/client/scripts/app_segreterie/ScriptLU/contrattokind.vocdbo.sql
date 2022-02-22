
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'contrattokind')
UPDATE [tabledescr] SET description = 'Tipologie di contratto',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-10 11:08:57.020'},lu = 'Generator',title = 'Tipologie di contratto' WHERE tablename = 'contrattokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('contrattokind','Tipologie di contratto','2','S',{ts '2021-11-10 11:08:57.020'},'Generator','Tipologie di contratto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','contrattokind','1',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegnoaggiuntivo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita assegno aggiuntivo',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assegnoaggiuntivo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegnoaggiuntivo','contrattokind','1',null,null,'Abilita assegno aggiuntivo','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo lordo annuo',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuo','contrattokind','5','9','2','Costo lordo annuo','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuooneri' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo lordo annuo e oneri',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuooneri' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuooneri','contrattokind','5','9','2','Costo lordo annuo e oneri','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','contrattokind','8',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','contrattokind','64',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','contrattokind','256',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'elementoperequativo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita elemento perequativo',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'elementoperequativo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('elementoperequativo','contrattokind','1',null,null,'Abilita elemento perequativo','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-04 13:18:56.727'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','contrattokind','4',null,null,null,'S',{ts '2018-12-04 13:18:56.727'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiateneo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita indennità di ateneo',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indennitadiateneo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiateneo','contrattokind','1',null,null,'Abilita indennità di ateneo','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiposizione' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita indennità di posizione',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indennitadiposizione' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiposizione','contrattokind','1',null,null,'Abilita indennità di posizione','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indvacancacontrattuale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita ind. vacanca contrattuale',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indvacancacontrattuale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indvacancacontrattuale','contrattokind','1',null,null,'Abilita ind. vacanca contrattuale','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','contrattokind','8',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','contrattokind','64',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxcompitididatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per i compiti didattici a tempo parziale',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxcompitididatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxcompitididatempoparziale','contrattokind','4',null,null,'Ore massime per i compiti didattici a tempo parziale','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxcompitididatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per i compiti didattici a tempo pieno',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxcompitididatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxcompitididatempopieno','contrattokind','4',null,null,'Ore massime per i compiti didattici a tempo pieno','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxdidatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per didattica frontale a tempo parziale',kind = 'S',lt = {ts '2020-05-20 11:54:19.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxdidatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxdidatempoparziale','contrattokind','4',null,null,'Ore massime per didattica frontale a tempo parziale','S',{ts '2020-05-20 11:54:19.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxdidatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per didattica frontale a tempo pieno',kind = 'S',lt = {ts '2020-05-20 11:54:19.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxdidatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxdidatempopieno','contrattokind','4',null,null,'Ore massime per didattica frontale a tempo pieno','S',{ts '2020-05-20 11:54:19.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxgg' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di lavoro al giorno massime',kind = 'S',lt = {ts '2020-06-12 15:47:15.233'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxgg' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxgg','contrattokind','4',null,null,'Ore di lavoro al giorno massime','S',{ts '2020-06-12 15:47:15.233'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxtempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime a tempo parziale',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxtempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxtempoparziale','contrattokind','4',null,null,'Ore massime a tempo parziale','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxtempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime a tempo pieno',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxtempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxtempopieno','contrattokind','4',null,null,'Ore massime a tempo pieno','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremincompitididatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime per i compiti didattici a tempo parziale',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremincompitididatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremincompitididatempoparziale','contrattokind','4',null,null,'Ore minime per i compiti didattici a tempo parziale','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremincompitididatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime per i compiti didattici a tempo pieno',kind = 'S',lt = {ts '2020-05-20 12:57:57.883'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremincompitididatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremincompitididatempopieno','contrattokind','4',null,null,'Ore minime per i compiti didattici a tempo pieno','S',{ts '2020-05-20 12:57:57.883'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremindidatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime di didattica frontale a tempo parziale',kind = 'S',lt = {ts '2020-05-20 11:48:33.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremindidatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremindidatempoparziale','contrattokind','4',null,null,'Ore minime di didattica frontale a tempo parziale','S',{ts '2020-05-20 11:48:33.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremindidatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime di didattica frontale a tempo pieno',kind = 'S',lt = {ts '2020-05-20 11:48:33.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremindidatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremindidatempopieno','contrattokind','4',null,null,'Ore minime di didattica frontale a tempo pieno','S',{ts '2020-05-20 11:48:33.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremintempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime a tempo parziale',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremintempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremintempoparziale','contrattokind','4',null,null,'Ore minime a tempo parziale','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremintempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime a tempo pieno',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremintempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremintempopieno','contrattokind','4',null,null,'Ore minime a tempo pieno','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orestraordinariemax' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime di straordinario rendicontabili',kind = 'S',lt = {ts '2020-05-21 10:06:18.870'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orestraordinariemax' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orestraordinariemax','contrattokind','4',null,null,'Ore massime di straordinario rendicontabili','S',{ts '2020-05-21 10:06:18.870'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parttime' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita part-time',kind = 'S',lt = {ts '2020-05-21 10:50:04.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'parttime' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parttime','contrattokind','1',null,null,'Abilita part-time','S',{ts '2020-05-21 10:50:04.330'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'puntiorganico' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-21 12:22:02.873'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'puntiorganico' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('puntiorganico','contrattokind','5','9','2','','S',{ts '2021-10-21 12:22:02.873'},'Generator','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita scatti stipendio',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'scatto' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','contrattokind','1',null,null,'Abilita scatti stipendio','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'siglaesportazione' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-21 12:22:02.873'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'siglaesportazione' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('siglaesportazione','contrattokind','10',null,null,'','S',{ts '2021-10-21 12:22:02.873'},'Generator','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'siglaimportazione' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-21 12:22:02.873'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'siglaimportazione' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('siglaimportazione','contrattokind','10',null,null,'','S',{ts '2021-10-21 12:22:02.873'},'Generator','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','contrattokind','4',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempdef' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita tempo definito o parziale',kind = 'S',lt = {ts '2020-05-21 12:31:15.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempdef' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempdef','contrattokind','1',null,null,'Abilita tempo definito o parziale','S',{ts '2020-05-21 12:31:15.367'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','contrattokind','50',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totaletredicesima' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita totale tredicesima',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'totaletredicesima' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totaletredicesima','contrattokind','1',null,null,'Abilita totale tredicesima','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita tredicesima indennità integrativa speciale',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tredicesimaindennitaintegrativaspeciale','contrattokind','1',null,null,'Abilita tredicesima indennità integrativa speciale','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

