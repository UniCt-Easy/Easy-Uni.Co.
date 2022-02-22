
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'lezione')
UPDATE [tabledescr] SET description = '2.4.23 Lezione',idapplication = '2',isdbo = 'S',lt = {ts '2021-02-19 15:10:01.383'},lu = 'assistenza',title = 'Lezioni' WHERE tablename = 'lezione'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('lezione','2.4.23 Lezione','2','S',{ts '2021-02-19 15:10:01.383'},'assistenza','Lezioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:42:44.093'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','lezione','9',null,null,null,'S',{ts '2019-09-24 15:42:44.093'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','lezione','8',null,null,null,'S',{ts '2018-07-19 18:37:24.480'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','lezione','64',null,null,null,'S',{ts '2018-07-19 18:37:24.483'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamento' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Affidamento',kind = 'S',lt = {ts '2019-04-11 12:55:51.217'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamento' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamento','lezione','4',null,null,'Affidamento','S',{ts '2019-04-11 12:55:51.217'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattivform' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'attività formativa',kind = 'S',lt = {ts '2019-09-20 19:56:45.107'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattivform' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattivform','lezione','4',null,null,'attività formativa','S',{ts '2019-09-20 19:56:45.107'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaula' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Aula',kind = 'S',lt = {ts '2019-09-24 15:43:09.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaula' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaula','lezione','4',null,null,'Aula','S',{ts '2019-09-24 15:43:09.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcanale' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Canale',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcanale' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcanale','lezione','4',null,null,'Canale','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:42:44.093'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','lezione','4',null,null,null,'S',{ts '2019-09-24 15:42:44.093'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica programmata',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','lezione','4',null,null,'Didattica programmata','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidproganno' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di corso',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidproganno' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidproganno','lezione','4',null,null,'Anno di corso','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Curriculum',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','lezione','4',null,null,'Curriculum','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogori' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Orientamento',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogori' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogori','lezione','4',null,null,'Orientamento','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzanno' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Porzione d''anno',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzanno' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzanno','lezione','4',null,null,'Porzione d''anno','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idedificio' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Edificio',kind = 'S',lt = {ts '2019-09-24 15:43:09.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idedificio' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idedificio','lezione','4',null,null,'Edificio','S',{ts '2019-09-24 15:43:09.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlezione' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlezione' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlezione','lezione','4',null,null,'Identificativo','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlocation_aula' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Aula',kind = 'S',lt = {ts '2019-02-26 11:15:34.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlocation_aula' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlocation_aula','lezione','4',null,null,'Aula','S',{ts '2019-02-26 11:15:34.077'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-10-16 13:08:45.253'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','lezione','4',null,null,'Docente','S',{ts '2019-10-16 13:08:45.253'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-09-24 15:43:09.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','lezione','4',null,null,'Sede','S',{ts '2019-09-24 15:43:09.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','lezione','8',null,null,null,'S',{ts '2018-07-19 18:37:24.483'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','lezione','64',null,null,null,'S',{ts '2018-07-19 18:37:24.483'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nonsvolta' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Non svolta',kind = 'S',lt = {ts '2019-10-15 15:36:06.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'nonsvolta' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nonsvolta','lezione','1',null,null,'Non svolta','S',{ts '2019-10-15 15:36:06.680'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stage' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-10-15 15:35:38.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'stage' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stage','lezione','1',null,null,null,'S',{ts '2019-10-15 15:35:38.747'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora inizio',kind = 'S',lt = {ts '2019-02-26 11:15:34.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','lezione','8',null,null,'Data e ora inizio','S',{ts '2019-02-26 11:15:34.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora fine',kind = 'S',lt = {ts '2019-02-26 11:15:34.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','lezione','8',null,null,'Data e ora fine','S',{ts '2019-02-26 11:15:34.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'visita' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-10-15 15:35:38.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'visita' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('visita','lezione','1',null,null,null,'S',{ts '2019-10-15 15:35:38.747'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3301')
UPDATE [relation] SET childtable = 'lezione',description = 'affidamento (docente e materia) della lezione',lt = {ts '2018-07-19 18:38:16.837'},lu = 'assistenza',parenttable = 'affidamento',title = null WHERE idrelation = '3301'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3301','lezione','affidamento (docente e materia) della lezione',{ts '2018-07-19 18:38:16.837'},'assistenza','affidamento',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3452')
UPDATE [relation] SET childtable = 'lezione',description = 'Lezioni',lt = {ts '2018-12-07 19:06:51.800'},lu = 'assistenza',parenttable = 'location_aula',title = '2.4.23 Lezione' WHERE idrelation = '3452'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3452','lezione','Lezioni',{ts '2018-12-07 19:06:51.800'},'assistenza','location_aula','2.4.23 Lezione')
GO

-- FINE GENERAZIONE SCRIPT --

