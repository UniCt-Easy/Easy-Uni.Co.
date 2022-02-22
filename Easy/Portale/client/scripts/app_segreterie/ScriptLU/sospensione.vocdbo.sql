
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sospensione')
UPDATE [tabledescr] SET description = 'sospenione di attività, che sia di una carriera, didattica del docente o di utilizzabilità di un''aula',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-26 11:58:18.297'},lu = 'assistenza',title = 'Sospenione delle attività' WHERE tablename = 'sospensione'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sospensione','sospenione di attività, che sia di una carriera, didattica del docente o di utilizzabilità di un''aula','3','S',{ts '2021-02-26 11:58:18.297'},'assistenza','Sospenione delle attività')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','sospensione','8',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','sospensione','64',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaula' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Aula',kind = 'S',lt = {ts '2019-09-24 16:29:12.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaula' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaula','sospensione','4',null,null,'Aula','S',{ts '2019-09-24 16:29:12.827'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idedificio' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Edificio',kind = 'S',lt = {ts '2019-09-24 16:29:12.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idedificio' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idedificio','sospensione','4',null,null,'Edificio','S',{ts '2019-09-24 16:29:12.827'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente, Studente o Istituto',kind = 'S',lt = {ts '2018-12-05 16:13:14.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','sospensione','4',null,null,'Docente, Studente o Istituto','S',{ts '2018-12-05 16:13:14.753'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-09-24 16:29:12.827'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','sospensione','4',null,null,'Sede','S',{ts '2019-09-24 16:29:12.827'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsospensione' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-05 16:13:14.753'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsospensione' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsospensione','sospensione','4',null,null,'Codice','S',{ts '2018-12-05 16:13:14.753'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','sospensione','8',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:04:25.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','sospensione','64',null,null,null,'S',{ts '2018-07-18 16:04:25.073'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'motivo' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-21 18:47:07.023'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'motivo' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('motivo','sospensione','1024',null,null,null,'S',{ts '2018-11-21 18:47:07.023'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Inizio',kind = 'S',lt = {ts '2018-11-21 16:08:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','sospensione','8',null,null,'Inizio','S',{ts '2018-11-21 16:08:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'sospensione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Fine',kind = 'S',lt = {ts '2019-01-23 11:25:48.820'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'sospensione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','sospensione','8',null,null,'Fine','S',{ts '2019-01-23 11:25:48.820'},'assistenza','N','datetime','datetime','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3441')
UPDATE [relation] SET childtable = 'sospensione',description = 'Sospensioni',lt = {ts '2018-12-07 18:37:51.957'},lu = 'assistenza',parenttable = 'docenti',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3441'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3441','sospensione','Sospensioni',{ts '2018-12-07 18:37:51.957'},'assistenza','docenti','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3449')
UPDATE [relation] SET childtable = 'sospensione',description = 'Interruzioni delle attivit?',lt = {ts '2018-12-07 19:03:50.690'},lu = 'assistenza',parenttable = 'registry_istituti',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3449'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3449','sospensione','Interruzioni delle attivit?',{ts '2018-12-07 19:03:50.690'},'assistenza','registry_istituti','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3450')
UPDATE [relation] SET childtable = 'sospensione',description = 'Interruzioni delle attivit?',lt = {ts '2018-12-07 19:04:40.737'},lu = 'assistenza',parenttable = 'location_edifici',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3450'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3450','sospensione','Interruzioni delle attivit?',{ts '2018-12-07 19:04:40.737'},'assistenza','location_edifici','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3451')
UPDATE [relation] SET childtable = 'sospensione',description = 'Interruzioni delle attivit?',lt = {ts '2018-12-07 19:05:39.647'},lu = 'assistenza',parenttable = 'location_aula',title = 'sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula' WHERE idrelation = '3451'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3451','sospensione','Interruzioni delle attivit?',{ts '2018-12-07 19:05:39.647'},'assistenza','location_aula','sospenione di attivit?, che sia di una carriera, didattica del docente o di utilizzabilit? di un?aula')
GO

-- FINE GENERAZIONE SCRIPT --

