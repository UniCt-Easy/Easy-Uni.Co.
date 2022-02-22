
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'aula')
UPDATE [tabledescr] SET description = '2.4.24 Aule',idapplication = '2',isdbo = 'S',lt = {ts '2021-02-19 15:06:06.983'},lu = 'assistenza',title = 'Aule' WHERE tablename = 'aula'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('aula','2.4.24 Aule','2','S',{ts '2021-02-19 15:06:06.983'},'assistenza','Aule')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'address' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'Indirizzo',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'address' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('address','aula','100',null,null,'Indirizzo','S',{ts '2019-09-24 15:54:30.630'},'assistenza','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cap' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'CAP',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cap' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cap','aula','20',null,null,'CAP','S',{ts '2019-09-24 15:54:30.630'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'capienza' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:52:41.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'capienza' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('capienza','aula','4',null,null,null,'S',{ts '2019-09-24 15:52:41.580'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'capienzadis' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Capienza disabili',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'capienzadis' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('capienzadis','aula','4',null,null,'Capienza disabili','S',{ts '2019-09-24 15:54:30.630'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'code' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '128',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2019-09-24 16:15:23.280'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(128)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'code' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('code','aula','128',null,null,'Codice','S',{ts '2019-09-24 16:15:23.280'},'assistenza','N','varchar(128)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:52:41.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','aula','8',null,null,null,'S',{ts '2019-09-24 15:52:41.580'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:52:41.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','aula','64',null,null,null,'S',{ts '2019-09-24 15:52:41.580'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dotazioni' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:52:41.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'dotazioni' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dotazioni','aula','0',null,null,null,'S',{ts '2019-09-24 15:52:41.580'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaula' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:52:41.580'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaula' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaula','aula','4',null,null,null,'S',{ts '2019-09-24 15:52:41.580'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaulakind' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaulakind' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaulakind','aula','4',null,null,'Tipologia','S',{ts '2019-09-24 15:54:30.630'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Città',kind = 'S',lt = {ts '2020-10-08 15:18:48.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','aula','4',null,null,'Città','S',{ts '2020-10-08 15:18:48.633'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idedificio' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Edificio',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idedificio' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idedificio','aula','4',null,null,'Edificio','S',{ts '2019-09-24 15:54:30.630'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazione',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','aula','4',null,null,'Nazione','S',{ts '2019-09-24 15:54:30.630'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','aula','4',null,null,'Sede','S',{ts '2019-09-24 15:54:30.630'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica di afferenza',kind = 'S',lt = {ts '2021-07-05 16:25:19.190'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','aula','4',null,null,'Struttura didattica di afferenza','S',{ts '2021-07-05 16:25:19.190'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'latitude' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'latitudine',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'latitude' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('latitude','aula','8',null,null,'latitudine','S',{ts '2019-09-24 15:54:30.630'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Località',kind = 'S',lt = {ts '2020-10-08 15:18:48.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','aula','20',null,null,'Località','S',{ts '2020-10-08 15:18:48.633'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'longitude' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Longitudine',kind = 'S',lt = {ts '2019-09-24 15:54:30.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'longitude' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('longitude','aula','8',null,null,'Longitudine','S',{ts '2019-09-24 15:54:30.630'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:52:41.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','aula','8',null,null,null,'S',{ts '2019-09-24 15:52:41.580'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:52:41.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','aula','64',null,null,null,'S',{ts '2019-09-24 15:52:41.580'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'aula')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-24 16:15:23.280'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'aula'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','aula','1024',null,null,'Denominazione','S',{ts '2019-09-24 16:15:23.280'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

