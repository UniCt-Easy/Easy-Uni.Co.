
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_istitutiesteri')
UPDATE [tabledescr] SET description = '2.4.30 Istituti esteri',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 16:00:59.170'},lu = 'assistenza',title = 'Istituti esteri' WHERE tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_istitutiesteri','2.4.30 Istituti esteri','3','S',{ts '2021-02-19 16:00:59.170'},'assistenza','Istituti esteri')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'city' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'city' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('city','registry_istitutiesteri','255',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(255)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'code' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'code' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('code','registry_istitutiesteri','50',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_istitutiesteri','8',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_istitutiesteri','64',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnace' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'NACE code',kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idnace' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnace','registry_istitutiesteri','50',null,null,'NACE code','S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_istitutiesteri','4',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'institutionalcode' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Institutional code',kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'institutionalcode' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('institutionalcode','registry_istitutiesteri','50',null,null,'Institutional code','S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_istitutiesteri','8',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:44:37.123'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_istitutiesteri','64',null,null,null,'S',{ts '2018-07-17 10:44:37.123'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'name' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'name' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('name','registry_istitutiesteri','1024',null,null,null,'S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'referencenumber' AND tablename = 'registry_istitutiesteri')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Reference number',kind = 'S',lt = {ts '2018-11-26 12:57:22.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'referencenumber' AND tablename = 'registry_istitutiesteri'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('referencenumber','registry_istitutiesteri','50',null,null,'Reference number','S',{ts '2018-11-26 12:57:22.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3189')
UPDATE [relation] SET childtable = 'registry_istitutiesteri',description = 'Anagrafica di base degli istituti esteri',lt = {ts '2018-07-17 11:06:13.873'},lu = 'assistenza',parenttable = 'registry',title = null WHERE idrelation = '3189'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3189','registry_istitutiesteri','Anagrafica di base degli istituti esteri',{ts '2018-07-17 11:06:13.873'},'assistenza','registry',null)
GO

-- FINE GENERAZIONE SCRIPT --

