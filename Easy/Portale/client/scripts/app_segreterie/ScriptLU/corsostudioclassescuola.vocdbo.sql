
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudioclassescuola')
UPDATE [tabledescr] SET description = 'relazione tra  2.4.2 Corso di studio e 2.4.12 Scuola / Classe di laurea',idapplication = null,isdbo = 'N',lt = {ts '2018-07-18 16:18:10.100'},lu = 'assistenza',title = 'relazione tra Corso di studio e Scuola / Classe di laurea' WHERE tablename = 'corsostudioclassescuola'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudioclassescuola','relazione tra  2.4.2 Corso di studio e 2.4.12 Scuola / Classe di laurea',null,'N',{ts '2018-07-18 16:18:10.100'},'assistenza','relazione tra Corso di studio e Scuola / Classe di laurea')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'corsostudioclassescuola')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:18:11.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'corsostudioclassescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','corsostudioclassescuola','8',null,null,null,'S',{ts '2018-07-18 16:18:11.287'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'corsostudioclassescuola')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:18:11.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'corsostudioclassescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','corsostudioclassescuola','64',null,null,null,'S',{ts '2018-07-18 16:18:11.287'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassescuola' AND tablename = 'corsostudioclassescuola')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:18:11.287'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassescuola' AND tablename = 'corsostudioclassescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassescuola','corsostudioclassescuola','4',null,null,null,'S',{ts '2018-07-18 16:18:11.287'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'corsostudioclassescuola')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:18:11.287'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'corsostudioclassescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','corsostudioclassescuola','4',null,null,null,'S',{ts '2018-07-18 16:18:11.287'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudioclassescuola')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:18:11.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudioclassescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudioclassescuola','8',null,null,null,'S',{ts '2018-07-18 16:18:11.287'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudioclassescuola')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:18:11.287'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudioclassescuola'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudioclassescuola','64',null,null,null,'S',{ts '2018-07-18 16:18:11.287'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3234')
UPDATE [relation] SET childtable = 'corsostudioclassescuola',description = 'corso di studio di cui elenca le classi o scuole',lt = {ts '2018-07-18 16:19:08.090'},lu = 'assistenza',parenttable = 'corsostudio',title = null WHERE idrelation = '3234'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3234','corsostudioclassescuola','corso di studio di cui elenca le classi o scuole',{ts '2018-07-18 16:19:08.090'},'assistenza','corsostudio',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3235')
UPDATE [relation] SET childtable = 'corsostudioclassescuola',description = 'classe o scuola del corso collegato',lt = {ts '2018-07-18 16:19:08.117'},lu = 'assistenza',parenttable = 'classescuola',title = null WHERE idrelation = '3235'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3235','corsostudioclassescuola','classe o scuola del corso collegato',{ts '2018-07-18 16:19:08.117'},'assistenza','classescuola',null)
GO

-- FINE GENERAZIONE SCRIPT --

