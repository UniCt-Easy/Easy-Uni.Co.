
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'geo_city')
UPDATE [tabledescr] SET description = 'Comuni',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:28.860'},lu = 'nino',title = 'Comuni' WHERE tablename = 'geo_city'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('geo_city','Comuni',null,'S',{ts '1900-01-01 03:00:28.860'},'nino','Comuni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id città (tabella geo_city)',kind = 'S',lt = {ts '2020-10-19 11:56:18.737'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','geo_city','4',null,null,'id città (tabella geo_city)','S',{ts '2020-10-19 11:56:18.737'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcountry' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id paese (tabella geo_country)',kind = 'S',lt = {ts '1900-01-01 03:00:25.933'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcountry' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcountry','geo_city','4',null,null,'id paese (tabella geo_country)','S',{ts '1900-01-01 03:00:25.933'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.880'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','geo_city','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.880'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.910'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','geo_city','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.910'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newcity' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id nuovo comune in cui questo è eventualmente confluito, se valorizzato questo comune non è più valido',kind = 'S',lt = {ts '2020-10-16 11:13:15.037'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'newcity' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newcity','geo_city','4',null,null,'id nuovo comune in cui questo è eventualmente confluito, se valorizzato questo comune non è più valido','S',{ts '2020-10-16 11:13:15.037'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oldcity' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id comune da cui questo è confluito',kind = 'S',lt = {ts '2020-10-16 11:13:15.037'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oldcity' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oldcity','geo_city','4',null,null,'id comune da cui questo è confluito','S',{ts '2020-10-16 11:13:15.037'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '1900-01-01 02:59:54.077'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','geo_city','4',null,null,'data inizio','S',{ts '1900-01-01 02:59:54.077'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '1900-01-01 02:59:54.583'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','geo_city','4',null,null,'data fine','S',{ts '1900-01-01 02:59:54.583'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'geo_city')
UPDATE [coldescr] SET col_len = '65',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '1900-01-01 03:00:00.070'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(65)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'geo_city'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','geo_city','65',null,null,'Denominazione','S',{ts '1900-01-01 03:00:00.070'},'nino','N','varchar(65)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '884')
UPDATE [relation] SET childtable = 'geo_city',description = 'id paese (tabella geo_country)',lt = {ts '2017-05-20 09:19:52.603'},lu = 'lu',parenttable = 'geo_country',title = 'Comuni' WHERE idrelation = '884'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('884','geo_city','id paese (tabella geo_country)',{ts '2017-05-20 09:19:52.603'},'lu','geo_country','Comuni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '884' AND parentcol = 'idcountry')
UPDATE [relationcol] SET childcol = 'idcountry',lt = {ts '2017-05-20 09:19:52.737'},lu = 'lu' WHERE idrelation = '884' AND parentcol = 'idcountry'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('884','idcountry','idcountry',{ts '2017-05-20 09:19:52.737'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

