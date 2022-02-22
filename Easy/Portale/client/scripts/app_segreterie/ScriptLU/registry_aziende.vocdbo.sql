
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_aziende')
UPDATE [tabledescr] SET description = '2.4.34 2.5.19  Enti e Aziende',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 16:03:20.957'},lu = 'assistenza',title = 'Enti e Aziende' WHERE tablename = 'registry_aziende'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_aziende','2.4.34 2.5.19  Enti e Aziende','3','S',{ts '2021-02-19 16:03:20.957'},'assistenza','Enti e Aziende')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_aziende','8',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_aziende','64',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idateco' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classificazione Ateco',kind = 'S',lt = {ts '2018-12-05 17:05:15.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idateco' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idateco','registry_aziende','4',null,null,'Classificazione Ateco','S',{ts '2018-12-05 17:05:15.717'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnace' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'NACE',kind = 'S',lt = {ts '2020-11-04 17:59:36.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idnace' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnace','registry_aziende','50',null,null,'NACE','S',{ts '2020-11-04 17:59:36.110'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnaturagiur' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Natura Giuridica',kind = 'S',lt = {ts '2018-12-05 17:05:15.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnaturagiur' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnaturagiur','registry_aziende','4',null,null,'Natura Giuridica','S',{ts '2018-12-05 17:05:15.717'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnumerodip' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di dipendenti',kind = 'S',lt = {ts '2018-12-05 17:05:15.717'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnumerodip' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnumerodip','registry_aziende','4',null,null,'Numero di dipendenti','S',{ts '2018-12-05 17:05:15.717'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-11-26 17:21:21.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_aziende','4',null,null,'Codice','S',{ts '2018-11-26 17:21:21.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_aziende','8',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:22:01.493'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_aziende','64',null,null,null,'S',{ts '2018-07-17 17:22:01.493'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pic' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Participant Identification Code (PIC)',kind = 'S',lt = {ts '2020-11-03 16:05:51.590'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'pic' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pic','registry_aziende','10',null,null,'Participant Identification Code (PIC)','S',{ts '2020-11-03 16:05:51.590'},'assistenza','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Denominazione (ENG)',kind = 'S',lt = {ts '2018-11-26 12:48:13.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','registry_aziende','150',null,null,'Denominazione (ENG)','S',{ts '2018-11-26 12:48:13.000'},'Ferdinando','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt_en' AND tablename = 'registry_aziende')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 17:03:50.877'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'txt_en' AND tablename = 'registry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt_en','registry_aziende','0',null,null,null,'S',{ts '2018-12-05 17:03:50.877'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3213')
UPDATE [relation] SET childtable = 'registry_aziende',description = 'Campi comni alle aagrafiche di persone fisiche e giuridiche ',lt = {ts '2018-07-17 17:22:01.170'},lu = 'assistenza',parenttable = 'registry',title = null WHERE idrelation = '3213'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3213','registry_aziende','Campi comni alle aagrafiche di persone fisiche e giuridiche ',{ts '2018-07-17 17:22:01.170'},'assistenza','registry',null)
GO

-- FINE GENERAZIONE SCRIPT --

