
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'esonero_titolostudio')
UPDATE [tabledescr] SET description = 'Parte di 2.3.6 Esoneri
',idapplication = null,isdbo = 'N',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',title = 'Esonero per titolo di studio' WHERE tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('esonero_titolostudio','Parte di 2.3.6 Esoneri
',null,'N',{ts '2019-02-27 15:35:13.330'},'assistenza','Esonero per titolo di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'conseguitoincorso' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Conseguito in corso',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'conseguitoincorso' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('conseguitoincorso','esonero_titolostudio','1',null,null,'Conseguito in corso','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','esonero_titolostudio','8',null,null,null,'S',{ts '2018-07-27 17:59:17.057'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','esonero_titolostudio','64',null,null,null,'S',{ts '2018-07-27 17:59:17.057'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataconstutticf' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data limite per aver conseguito tutti i crediti formativi',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'dataconstutticf' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataconstutticf','esonero_titolostudio','3',null,null,'Data limite per aver conseguito tutti i crediti formativi','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datalaurea' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data limite di conseguimento del titolo',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datalaurea' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datalaurea','esonero_titolostudio','3',null,null,'Data limite di conseguimento del titolo','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idesonero' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idesonero' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idesonero','esonero_titolostudio','4',null,null,null,'S',{ts '2018-07-27 17:59:17.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica',kind = 'S',lt = {ts '2019-09-09 19:00:51.017'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','esonero_titolostudio','4',null,null,'Struttura didattica','S',{ts '2019-09-09 19:00:51.017'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','esonero_titolostudio','8',null,null,null,'S',{ts '2018-07-27 17:59:17.060'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','esonero_titolostudio','64',null,null,null,'S',{ts '2018-07-27 17:59:17.060'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nellistituto' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Solo per corsi dell''istituto',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'nellistituto' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nellistituto','esonero_titolostudio','1',null,null,'Solo per corsi dell''istituto','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'noabbr' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Senza abbreviazioni di carriera',kind = 'S',lt = {ts '2019-02-27 15:35:13.333'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'noabbr' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('noabbr','esonero_titolostudio','1',null,null,'Senza abbreviazioni di carriera','S',{ts '2019-02-27 15:35:13.333'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'noparttime' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Senza aver effettuato iscrizioni part-time',kind = 'S',lt = {ts '2019-02-27 15:35:13.333'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'noparttime' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('noparttime','esonero_titolostudio','1',null,null,'Senza aver effettuato iscrizioni part-time','S',{ts '2019-02-27 15:35:13.333'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'votomin' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voto minimo',kind = 'S',lt = {ts '2019-02-27 15:35:13.333'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'votomin' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('votomin','esonero_titolostudio','4',null,null,'Voto minimo','S',{ts '2019-02-27 15:35:13.333'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3415')
UPDATE [relation] SET childtable = 'esonero_titolostudio',description = 'dati di base dell''esonero',lt = {ts '2018-07-27 17:59:16.770'},lu = 'assistenza',parenttable = 'esonero_titolostudio',title = null WHERE idrelation = '3415'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3415','esonero_titolostudio','dati di base dell''esonero',{ts '2018-07-27 17:59:16.770'},'assistenza','esonero_titolostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --

