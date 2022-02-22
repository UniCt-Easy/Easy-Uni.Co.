
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'classconsorsuale')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR delle classi di concorso',idapplication = '2',isdbo = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',title = 'Classi di concorso MIUR' WHERE tablename = 'classconsorsuale'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('classconsorsuale','VOCABOLARIO MIUR delle classi di concorso','2','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','Classi di concorso MIUR')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attiva',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','classconsorsuale','1',null,null,'Attiva','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ambitodisci' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Ambito Disciplinare',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ambitodisci' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ambitodisci','classconsorsuale','50',null,null,'Ambito Disciplinare','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'corr2592017' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Corrispondenza',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'corr2592017' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('corr2592017','classconsorsuale','50',null,null,'Corrispondenza','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','classconsorsuale','512',null,null,'Descrizione','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassconsorsuale' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassconsorsuale' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassconsorsuale','classconsorsuale','4',null,null,'Codice','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:51:31.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','classconsorsuale','8',null,null,null,'S',{ts '2018-12-05 17:51:31.707'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:51:31.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','classconsorsuale','64',null,null,null,'S',{ts '2018-12-05 17:51:31.707'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'normativa' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:51:31.707'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'normativa' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('normativa','classconsorsuale','50',null,null,null,'S',{ts '2018-12-05 17:51:31.707'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'classconsorsuale')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2018-12-07 13:09:51.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','classconsorsuale','50',null,null,'Denominazione','S',{ts '2018-12-07 13:09:51.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3215')
UPDATE [relation] SET childtable = 'classconsorsuale',description = 'didattia prgrammata che abilita alla classe',lt = {ts '2018-07-17 17:31:28.650'},lu = 'assistenza',parenttable = 'didprog',title = null WHERE idrelation = '3215'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3215','classconsorsuale','didattia prgrammata che abilita alla classe',{ts '2018-07-17 17:31:28.650'},'assistenza','didprog',null)
GO

-- FINE GENERAZIONE SCRIPT --

