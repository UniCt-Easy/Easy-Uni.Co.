
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'bandomistrutturefrom')
UPDATE [tabledescr] SET description = 'Strutture degli outgoing indicate nei 2.5.15 Bandi per la mobilità internazionale
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 11:20:13.397'},lu = 'assistenza',title = 'Strutture degli outgoing indicate nei bandi per la mobilità internazionale' WHERE tablename = 'bandomistrutturefrom'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('bandomistrutturefrom','Strutture degli outgoing indicate nei 2.5.15 Bandi per la mobilità internazionale
',null,'N',{ts '2018-07-27 11:20:13.397'},'assistenza','Strutture degli outgoing indicate nei bandi per la mobilità internazionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'bandomistrutturefrom')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:20:45.093'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'bandomistrutturefrom'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','bandomistrutturefrom','8',null,null,null,'S',{ts '2018-07-27 11:20:45.093'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'bandomistrutturefrom')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:20:45.093'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'bandomistrutturefrom'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','bandomistrutturefrom','64',null,null,null,'S',{ts '2018-07-27 11:20:45.093'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomi' AND tablename = 'bandomistrutturefrom')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bando per la mobilità internazionale',kind = 'S',lt = {ts '2019-02-27 13:23:37.703'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomi' AND tablename = 'bandomistrutturefrom'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomi','bandomistrutturefrom','4',null,null,'Bando per la mobilità internazionale','S',{ts '2019-02-27 13:23:37.703'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'bandomistrutturefrom')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica di partenza',kind = 'S',lt = {ts '2019-09-09 18:52:01.723'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'bandomistrutturefrom'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','bandomistrutturefrom','4',null,null,'Struttura didattica di partenza','S',{ts '2019-09-09 18:52:01.723'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'bandomistrutturefrom')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-27 13:23:53.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'bandomistrutturefrom'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','bandomistrutturefrom','8',null,null,null,'S',{ts '2019-02-27 13:23:53.480'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'bandomistrutturefrom')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:20:45.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'bandomistrutturefrom'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','bandomistrutturefrom','64',null,null,null,'S',{ts '2018-07-27 11:20:45.100'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3366')
UPDATE [relation] SET childtable = 'bandomistrutturefrom',description = 'bando di mobilità internazionale di cui fanno parte ',lt = {ts '2018-07-27 11:20:44.873'},lu = 'assistenza',parenttable = 'bandomi',title = null WHERE idrelation = '3366'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3366','bandomistrutturefrom','bando di mobilità internazionale di cui fanno parte ',{ts '2018-07-27 11:20:44.873'},'assistenza','bandomi',null)
GO

-- FINE GENERAZIONE SCRIPT --

