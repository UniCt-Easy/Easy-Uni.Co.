
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'publicazkindpublicaz')
UPDATE [tabledescr] SET description = 'collegamento tra le tipologie di pubblicazioni e la 2.4.27 pubblicazione (molti a molti)',idapplication = '2',isdbo = 'S',lt = {ts '2021-03-01 11:21:25.497'},lu = 'assistenza',title = 'collegamento tra le tipologie di pubblicazioni e la pubblicazione (molti a molti)' WHERE tablename = 'publicazkindpublicaz'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('publicazkindpublicaz','collegamento tra le tipologie di pubblicazioni e la 2.4.27 pubblicazione (molti a molti)','2','S',{ts '2021-03-01 11:21:25.497'},'assistenza','collegamento tra le tipologie di pubblicazioni e la pubblicazione (molti a molti)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'publicazkindpublicaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:11:02.490'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'publicazkindpublicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','publicazkindpublicaz','8',null,null,null,'S',{ts '2018-07-17 17:11:02.490'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'publicazkindpublicaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:11:02.490'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'publicazkindpublicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','publicazkindpublicaz','64',null,null,null,'S',{ts '2018-07-17 17:11:02.490'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpublicaz' AND tablename = 'publicazkindpublicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:11:02.493'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpublicaz' AND tablename = 'publicazkindpublicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpublicaz','publicazkindpublicaz','4',null,null,null,'S',{ts '2018-07-17 17:11:02.493'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpublicazkind' AND tablename = 'publicazkindpublicaz')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:11:02.493'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpublicazkind' AND tablename = 'publicazkindpublicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpublicazkind','publicazkindpublicaz','4',null,null,null,'S',{ts '2018-07-17 17:11:02.493'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'publicazkindpublicaz')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:11:02.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'publicazkindpublicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','publicazkindpublicaz','8',null,null,null,'S',{ts '2018-07-17 17:11:02.493'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'publicazkindpublicaz')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:11:02.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'publicazkindpublicaz'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','publicazkindpublicaz','64',null,null,null,'S',{ts '2018-07-17 17:11:02.493'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3210')
UPDATE [relation] SET childtable = 'publicazkindpublicaz',description = 'Tipologie',lt = {ts '2018-12-07 18:46:01.757'},lu = 'assistenza',parenttable = 'publicaz',title = 'publicazkindpublicaz' WHERE idrelation = '3210'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3210','publicazkindpublicaz','Tipologie',{ts '2018-12-07 18:46:01.757'},'assistenza','publicaz','publicazkindpublicaz')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3211')
UPDATE [relation] SET childtable = 'publicazkindpublicaz',description = 'tipologie collegate alla pubblicazione',lt = {ts '2018-07-17 17:11:51.877'},lu = 'assistenza',parenttable = 'publicazkind',title = null WHERE idrelation = '3211'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3211','publicazkindpublicaz','tipologie collegate alla pubblicazione',{ts '2018-07-17 17:11:51.877'},'assistenza','publicazkind',null)
GO

-- FINE GENERAZIONE SCRIPT --

