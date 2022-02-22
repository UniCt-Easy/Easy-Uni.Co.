
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'erogazkind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle modalità di erogazione della didattica',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-20 16:24:33.910'},lu = 'assistenza',title = 'modalità di erogazione della didattica' WHERE tablename = 'erogazkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('erogazkind','VOCABOLARIO delle modalità di erogazione della didattica','2','S',{ts '2018-07-20 16:24:33.910'},'assistenza','modalità di erogazione della didattica')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','erogazkind','1',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','erogazkind','255',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','N','varchar(255)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iderogazkind' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iderogazkind' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iderogazkind','erogazkind','4',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','erogazkind','8',null,null,null,'S',{ts '2018-07-19 15:47:30.773'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.777'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','erogazkind','64',null,null,null,'S',{ts '2018-07-19 15:47:30.777'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.777'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','erogazkind','4',null,null,null,'S',{ts '2018-07-19 15:47:30.777'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'erogazkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:47:30.777'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'erogazkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','erogazkind','50',null,null,null,'S',{ts '2018-07-19 15:47:30.777'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3273')
UPDATE [relation] SET childtable = 'erogazkind',description = 'didattica di cui si descrive la modalit? di erogazione',lt = {ts '2018-07-19 15:49:09.747'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3273'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3273','erogazkind','didattica di cui si descrive la modalit? di erogazione',{ts '2018-07-19 15:49:09.747'},'assistenza','didprog',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3274')
UPDATE [relation] SET childtable = 'erogazkind',description = 'affidamento dell''insegnamento al docente di cui si descrive la modalit? di erogazione',lt = {ts '2018-07-19 15:51:24.777'},lu = 'assistenza',parenttable = 'affidamento',title = null WHERE idrelation = '3274'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3274','erogazkind','affidamento dell''insegnamento al docente di cui si descrive la modalit? di erogazione',{ts '2018-07-19 15:51:24.777'},'assistenza','affidamento',null)
GO

-- FINE GENERAZIONE SCRIPT --

