
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudiolivello')
UPDATE [tabledescr] SET description = 'VOCABOLARIO dei livelli dei  2.4.2 Corso di studio ',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:25:03.270'},lu = 'assistenza',title = 'Livelli dei corsi di studio' WHERE tablename = 'corsostudiolivello'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudiolivello','VOCABOLARIO dei livelli dei  2.4.2 Corso di studio ',null,'N',{ts '2018-07-20 11:25:03.270'},'assistenza','Livelli dei corsi di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia del corso di studi',kind = 'S',lt = {ts '2019-09-05 11:33:32.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','corsostudiolivello','4',null,null,'Tipologia del corso di studi','S',{ts '2019-09-05 11:33:32.520'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-09-05 11:33:55.317'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiolivello','corsostudiolivello','4',null,null,'Identificativo','S',{ts '2019-09-05 11:33:55.317'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:22:10.800'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudiolivello','8',null,null,null,'S',{ts '2018-07-18 16:22:10.800'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:22:10.800'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudiolivello','64',null,null,null,'S',{ts '2018-07-18 16:22:10.800'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Livello',kind = 'S',lt = {ts '2019-09-05 11:33:55.317'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','corsostudiolivello','50',null,null,'Livello','S',{ts '2019-09-05 11:33:55.317'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3237')
UPDATE [relation] SET childtable = 'corsostudiolivello',description = 'corso di studio di cui descrive il livello',lt = {ts '2018-07-18 16:22:39.727'},lu = 'assistenza',parenttable = 'corsostudio',title = null WHERE idrelation = '3237'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3237','corsostudiolivello','corso di studio di cui descrive il livello',{ts '2018-07-18 16:22:39.727'},'assistenza','corsostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --

