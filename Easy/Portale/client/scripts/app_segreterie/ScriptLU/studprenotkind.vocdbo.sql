
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'studprenotkind')
UPDATE [tabledescr] SET description = 'sede, fuorisede, ecc.',idapplication = '2',isdbo = 'S',lt = {ts '2018-12-18 18:48:24.000'},lu = 'Ferdinando',title = 'Tipologia di studente durante la prenotazione' WHERE tablename = 'studprenotkind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('studprenotkind','sede, fuorisede, ecc.','2','S',{ts '2018-12-18 18:48:24.000'},'Ferdinando','Tipologia di studente durante la prenotazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-16 15:36:19.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','studprenotkind','1',null,null,null,'S',{ts '2018-07-16 15:36:19.830'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2018-12-18 18:46:48.360'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','studprenotkind','512',null,null,'Descrizione','S',{ts '2018-12-18 18:46:48.360'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstudprenotkind' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-18 18:58:23.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstudprenotkind' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstudprenotkind','studprenotkind','4',null,null,'Codice','S',{ts '2018-12-18 18:58:23.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:45:49.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','studprenotkind','8',null,null,null,'S',{ts '2018-12-18 18:45:49.847'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-18 18:45:49.847'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','studprenotkind','64',null,null,null,'S',{ts '2018-12-18 18:45:49.847'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortorder' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine',kind = 'S',lt = {ts '2018-12-18 18:46:48.363'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortorder' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortorder','studprenotkind','4',null,null,'Ordine','S',{ts '2018-12-18 18:46:48.363'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'studprenotkind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2018-12-18 18:46:48.363'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','studprenotkind','50',null,null,'Titolo','S',{ts '2018-12-18 18:46:48.363'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

