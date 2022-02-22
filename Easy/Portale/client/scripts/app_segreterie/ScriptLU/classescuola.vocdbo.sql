
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'classescuola')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR delle scuole di diploma e delle classi di laurea',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:23:36.507'},lu = 'assistenza',title = 'Scuole di diploma e Classi di laurea' WHERE tablename = 'classescuola'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('classescuola','VOCABOLARIO MIUR delle scuole di diploma e delle classi di laurea',null,'N',{ts '2018-07-20 11:23:36.507'},'assistenza','Scuole di diploma e Classi di laurea')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuola' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-03-11 12:22:21.297'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassescuola' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuola','classescuola','4',null,null,'Identificativo','S',{ts '2019-03-11 12:22:21.297'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuolaarea' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area',kind = 'S',lt = {ts '2020-05-18 12:18:42.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassescuolaarea' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuolaarea','classescuola','4',null,null,'Area','S',{ts '2020-05-18 12:18:42.663'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuolakind' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2020-05-18 11:05:07.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idclassescuolakind' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuolakind','classescuola','50',null,null,'Tipologia','S',{ts '2020-05-18 11:05:07.073'},'assistenza','N','nvarchar(50)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudionorma' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Normativa',kind = 'S',lt = {ts '2019-03-11 12:28:25.097'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudionorma' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudionorma','classescuola','4',null,null,'Normativa','S',{ts '2019-03-11 12:28:25.097'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicecineca' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo CINECA',kind = 'S',lt = {ts '2020-05-18 11:05:07.073'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicecineca' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicecineca','classescuola','4',null,null,'Identificativo CINECA','S',{ts '2020-05-18 11:05:07.073'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:16:07.403'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','classescuola','8',null,null,null,'S',{ts '2018-07-18 16:16:07.403'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:16:07.403'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','classescuola','64',null,null,null,'S',{ts '2018-07-18 16:16:07.403'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obbform' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Obiettivi formativi',kind = 'S',lt = {ts '2019-03-11 12:28:25.097'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'obbform' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obbform','classescuola','0',null,null,'Obiettivi formativi','S',{ts '2019-03-11 12:28:25.097'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'prospocc' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Prospettive occupazionali',kind = 'S',lt = {ts '2019-03-18 12:21:35.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'prospocc' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('prospocc','classescuola','0',null,null,'Prospettive occupazionali','S',{ts '2019-03-18 12:21:35.287'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sigla' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-03-11 12:22:22.407'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'sigla' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sigla','classescuola','50',null,null,null,'S',{ts '2019-03-11 12:22:22.407'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'classescuola')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-03-11 12:22:22.407'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'classescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','classescuola','256',null,null,'Denominazione','S',{ts '2019-03-11 12:22:22.407'},'assistenza','N','varchar(256)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

