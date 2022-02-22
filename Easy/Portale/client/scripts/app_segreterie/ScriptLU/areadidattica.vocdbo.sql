
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'areadidattica')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR delle aree didattiche',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-20 11:24:09.313'},lu = 'assistenza',title = 'Aree didattiche MIUR' WHERE tablename = 'areadidattica'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('areadidattica','VOCABOLARIO MIUR delle aree didattiche','2','S',{ts '2018-07-20 11:24:09.313'},'assistenza','Aree didattiche MIUR')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attivo',kind = 'S',lt = {ts '2018-12-18 18:35:37.280'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','areadidattica','1',null,null,'Attivo','S',{ts '2018-12-18 18:35:37.280'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:33:48.990'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','areadidattica','8',null,null,null,'S',{ts '2018-12-18 18:33:48.990'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:33:48.990'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(64)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','areadidattica','64',null,null,null,'S',{ts '2018-12-18 18:33:48.990'},'assistenza','N','nvarchar(64)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idareadidattica' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-18 18:35:37.283'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idareadidattica' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idareadidattica','areadidattica','4',null,null,'Codice','S',{ts '2018-12-18 18:35:37.283'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di corso',kind = 'S',lt = {ts '2019-03-11 12:18:00.097'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','areadidattica','4',null,null,'Tipo di corso','S',{ts '2019-03-11 12:18:00.097'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:33:48.990'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','areadidattica','8',null,null,null,'S',{ts '2018-12-18 18:33:48.990'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:33:48.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(64)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','areadidattica','64',null,null,null,'S',{ts '2018-12-18 18:33:48.993'},'assistenza','N','nvarchar(64)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine',kind = 'S',lt = {ts '2018-12-18 18:35:37.283'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','areadidattica','4',null,null,'Ordine','S',{ts '2018-12-18 18:35:37.283'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'subtitle' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'Sotto-titolo',kind = 'S',lt = {ts '2018-12-18 18:35:37.283'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'subtitle' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('subtitle','areadidattica','100',null,null,'Sotto-titolo','S',{ts '2018-12-18 18:35:37.283'},'assistenza','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'areadidattica')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2018-12-18 18:35:37.283'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'areadidattica'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','areadidattica','100',null,null,'Titolo','S',{ts '2018-12-18 18:35:37.283'},'assistenza','N','varchar(100)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3281')
UPDATE [relation] SET childtable = 'areadidattica',description = 'didattica programmata di cui si sta indicando l''area',lt = {ts '2018-07-19 17:33:40.670'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3281'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3281','areadidattica','didattica programmata di cui si sta indicando l''area',{ts '2018-07-19 17:33:40.670'},'assistenza','didprog',null)
GO

-- FINE GENERAZIONE SCRIPT --

