
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tipologiastudentestruttura')
UPDATE [tabledescr] SET description = 'Strutture a cui è riferita una tipologia di studente per un 2.5.12 Bando per il diritto allo studio',idapplication = null,isdbo = 'N',lt = {ts '2020-09-10 16:42:34.787'},lu = 'assistenza',title = 'Strutture a cui è riferita una tipologia di studente per un bando per il diritto allo studio' WHERE tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tipologiastudentestruttura','Strutture a cui è riferita una tipologia di studente per un 2.5.12 Bando per il diritto allo studio',null,'N',{ts '2020-09-10 16:42:34.787'},'assistenza','Strutture a cui è riferita una tipologia di studente per un bando per il diritto allo studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tipologiastudentestruttura','8',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tipologiastudentestruttura','64',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandods' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandods' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandods','tipologiastudentestruttura','4',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandodsservizio' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandodsservizio' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandodsservizio','tipologiastudentestruttura','4',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica',kind = 'S',lt = {ts '2020-09-10 16:44:54.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','tipologiastudentestruttura','4',null,null,'Struttura didattica','S',{ts '2020-09-10 16:44:54.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtipologiastudente' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Categoria di studenti',kind = 'S',lt = {ts '2020-09-10 16:44:54.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtipologiastudente' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtipologiastudente','tipologiastudentestruttura','4',null,null,'Categoria di studenti','S',{ts '2020-09-10 16:44:54.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tipologiastudentestruttura','8',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tipologiastudentestruttura')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-10 16:42:41.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tipologiastudentestruttura'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tipologiastudentestruttura','64',null,null,null,'S',{ts '2020-09-10 16:42:41.457'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

