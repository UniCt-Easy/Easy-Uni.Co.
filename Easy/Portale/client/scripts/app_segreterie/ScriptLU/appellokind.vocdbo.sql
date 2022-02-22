
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'appellokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle tipologie degli 2.2.5 Appello d''esame',idapplication = '2',isdbo = 'S',lt = {ts '2021-05-27 12:31:08.633'},lu = 'assistenza',title = 'Tipologie degli appelli d''esame' WHERE tablename = 'appellokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('appellokind','VOCABOLARIO delle tipologie degli 2.2.5 Appello d''esame','2','S',{ts '2021-05-27 12:31:08.633'},'assistenza','Tipologie degli appelli d''esame')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'appellokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attivo',kind = 'S',lt = {ts '2018-07-18 17:32:38.643'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'appellokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','appellokind','1',null,null,'Attivo','S',{ts '2018-07-18 17:32:38.643'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'appellokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2018-07-18 17:32:38.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'appellokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','appellokind','256',null,null,'Descrizione','S',{ts '2018-07-18 17:32:38.647'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idappellokind' AND tablename = 'appellokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-07-18 17:32:38.647'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idappellokind' AND tablename = 'appellokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idappellokind','appellokind','4',null,null,'Codice','S',{ts '2018-07-18 17:32:38.647'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'appellokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:32:38.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'appellokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','appellokind','8',null,null,null,'S',{ts '2018-07-18 17:32:38.647'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'appellokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 17:32:38.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'appellokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','appellokind','64',null,null,null,'S',{ts '2018-07-18 17:32:38.647'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'appellokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordinamento',kind = 'S',lt = {ts '2018-07-18 17:32:38.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'appellokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','appellokind','4',null,null,'Ordinamento','S',{ts '2018-07-18 17:32:38.647'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'appellokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2018-07-18 17:32:38.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'appellokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','appellokind','50',null,null,'Titolo','S',{ts '2018-07-18 17:32:38.647'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3250')
UPDATE [relation] SET childtable = 'appellokind',description = 'appello di cui descrive il tipo',lt = {ts '2018-07-18 17:33:00.913'},lu = 'assistenza',parenttable = 'appello',title = null WHERE idrelation = '3250'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3250','appellokind','appello di cui descrive il tipo',{ts '2018-07-18 17:33:00.913'},'assistenza','appello',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3251')
UPDATE [relation] SET childtable = 'appellokind',description = 'sessione di cui descrive il tipo di appelli contenuti',lt = {ts '2018-07-18 17:33:50.133'},lu = 'assistenza',parenttable = 'sessione',title = null WHERE idrelation = '3251'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3251','appellokind','sessione di cui descrive il tipo di appelli contenuti',{ts '2018-07-18 17:33:50.133'},'assistenza','sessione',null)
GO

-- FINE GENERAZIONE SCRIPT --

