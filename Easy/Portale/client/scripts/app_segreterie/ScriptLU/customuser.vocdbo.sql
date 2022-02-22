
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'customuser')
UPDATE [tabledescr] SET description = 'Utenti',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:29.440'},lu = 'nino',title = 'Utenti' WHERE tablename = 'customuser'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('customuser','Utenti',null,'S',{ts '1900-01-01 03:00:29.440'},'nino','Utenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:46.803'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','customuser','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:46.803'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.237'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','customuser','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.237'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcustomuser' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice utente',kind = 'S',lt = {ts '1900-01-01 03:00:19.083'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idcustomuser' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcustomuser','customuser','50',null,null,'Codice utente','S',{ts '1900-01-01 03:00:19.083'},'nino','S','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lastmodtimestamp' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 03:00:26.590'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lastmodtimestamp' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lastmodtimestamp','customuser','8',null,null,'data ultima modifica','S',{ts '1900-01-01 03:00:26.590'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lastmoduser' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'Utente ultima modifica',kind = 'S',lt = {ts '1900-01-01 03:00:26.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lastmoduser' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lastmoduser','customuser','64',null,null,'Utente ultima modifica','S',{ts '1900-01-01 03:00:26.937'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.363'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','customuser','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.363'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.393'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','customuser','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.393'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'username' AND tablename = 'customuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Nome utente',kind = 'S',lt = {ts '1900-01-01 03:00:19.087'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'username' AND tablename = 'customuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('username','customuser','50',null,null,'Nome utente','S',{ts '1900-01-01 03:00:19.087'},'nino','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '2960')
UPDATE [relation] SET childtable = 'customuser',description = 'Nome utente',lt = {ts '2017-05-20 09:20:14.730'},lu = 'lu',parenttable = 'webuser',title = 'Utenti' WHERE idrelation = '2960'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2960','customuser','Nome utente',{ts '2017-05-20 09:20:14.730'},'lu','webuser','Utenti')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3029')
UPDATE [relation] SET childtable = 'customuser',description = 'Nome utente',lt = {ts '2017-05-22 11:17:45.877'},lu = 'nino',parenttable = 'dbaccess',title = 'Utenti' WHERE idrelation = '3029'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3029','customuser','Nome utente',{ts '2017-05-22 11:17:45.877'},'nino','dbaccess','Utenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '2960' AND parentcol = 'username')
UPDATE [relationcol] SET childcol = 'username',lt = {ts '2017-05-20 09:20:14.797'},lu = 'lu' WHERE idrelation = '2960' AND parentcol = 'username'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('2960','username','username',{ts '2017-05-20 09:20:14.797'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

