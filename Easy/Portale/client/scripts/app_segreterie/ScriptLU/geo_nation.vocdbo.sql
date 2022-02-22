
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'geo_nation')
UPDATE [tabledescr] SET description = 'Nazioni',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:28.863'},lu = 'nino',title = 'Nazioni' WHERE tablename = 'geo_nation'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('geo_nation','Nazioni',null,'S',{ts '1900-01-01 03:00:28.863'},'nino','Nazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontinent' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id continente',kind = 'S',lt = {ts '2016-10-07 17:19:49.497'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontinent' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontinent','geo_nation','4',null,null,'id continente','S',{ts '2016-10-07 17:19:49.497'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id nazione (tabella geo_nation)',kind = 'S',lt = {ts '1900-01-01 03:00:14.957'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','geo_nation','4',null,null,'Id nazione (tabella geo_nation)','S',{ts '1900-01-01 03:00:14.957'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.907'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','geo_nation','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.907'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','geo_nation','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.937'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newnation' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazione in cui questa è confluita',kind = 'S',lt = {ts '2020-10-16 10:31:37.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'newnation' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newnation','geo_nation','4',null,null,'Nazione in cui questa è confluita','S',{ts '2020-10-16 10:31:37.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oldnation' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazione da cui questa è confluita',kind = 'S',lt = {ts '2020-10-16 10:31:37.043'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oldnation' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oldnation','geo_nation','4',null,null,'Nazione da cui questa è confluita','S',{ts '2020-10-16 10:31:37.043'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '1900-01-01 02:59:54.110'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','geo_nation','4',null,null,'data inizio','S',{ts '1900-01-01 02:59:54.110'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '1900-01-01 02:59:54.617'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','geo_nation','4',null,null,'data fine','S',{ts '1900-01-01 02:59:54.617'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'geo_nation')
UPDATE [coldescr] SET col_len = '65',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '1900-01-01 03:00:00.090'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(65)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'geo_nation'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','geo_nation','65',null,null,'Denominazione','S',{ts '1900-01-01 03:00:00.090'},'nino','N','varchar(65)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '1352')
UPDATE [relation] SET childtable = 'geo_nation',description = 'id continente',lt = {ts '2017-05-20 09:20:01.013'},lu = 'lu',parenttable = 'parasubcontract',title = 'Nazioni' WHERE idrelation = '1352'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1352','geo_nation','id continente',{ts '2017-05-20 09:20:01.013'},'lu','parasubcontract','Nazioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '1352' AND parentcol = 'idcon')
UPDATE [relationcol] SET childcol = 'idcontinent',lt = {ts '2017-05-20 09:20:01.157'},lu = 'lu' WHERE idrelation = '1352' AND parentcol = 'idcon'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('1352','idcon','idcontinent',{ts '2017-05-20 09:20:01.157'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

