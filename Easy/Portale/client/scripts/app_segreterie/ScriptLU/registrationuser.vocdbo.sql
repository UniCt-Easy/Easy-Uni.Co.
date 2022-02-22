
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registrationuser')
UPDATE [tabledescr] SET description = 'Richiesta di accesso',idapplication = '2',isdbo = 'S',lt = {ts '2022-02-11 15:57:29.243'},lu = 'Generator',title = 'Richiesta di accesso' WHERE tablename = 'registrationuser'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registrationuser','Richiesta di accesso','2','S',{ts '2022-02-11 15:57:29.243'},'Generator','Richiesta di accesso')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'Codice fiscale',kind = 'S',lt = {ts '2021-03-22 12:40:23.503'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(16)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cf' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','registrationuser','16',null,null,'Codice fiscale','S',{ts '2021-03-22 12:40:23.503'},'assistenza','N','varchar(16)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'E-Mail',kind = 'S',lt = {ts '2021-03-22 12:40:23.507'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email','registrationuser','1024',null,null,'E-Mail','S',{ts '2021-03-22 12:40:23.507'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'esercizio' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'esercizio' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('esercizio','registrationuser','4',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'forename' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '49',col_precision = null,col_scale = null,description = 'Nome',kind = 'S',lt = {ts '2021-03-22 12:40:23.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(49)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'forename' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('forename','registrationuser','49',null,null,'Nome','S',{ts '2021-03-22 12:40:23.510'},'assistenza','N','varchar(49)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrationuser' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrationuser' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrationuser','registrationuser','4',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrationuserstatus' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato della richiesta',kind = 'S',lt = {ts '2021-03-22 13:50:21.817'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrationuserstatus' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrationuserstatus','registrationuser','4',null,null,'Stato della richiesta','S',{ts '2021-03-22 13:50:21.817'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'login' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'login' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('login','registrationuser','60',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'matricola' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-22 12:38:38.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'matricola' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('matricola','registrationuser','50',null,null,null,'S',{ts '2021-03-22 12:38:38.237'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surname' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome',kind = 'S',lt = {ts '2021-03-22 12:40:23.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surname' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surname','registrationuser','50',null,null,'Cognome','S',{ts '2021-03-22 12:40:23.510'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'userkind' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di accesso',kind = 'S',lt = {ts '2021-03-22 12:40:23.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'userkind' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('userkind','registrationuser','4',null,null,'Tipologia di accesso','S',{ts '2021-03-22 12:40:23.510'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'usertype' AND tablename = 'registrationuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Categoria di utente',kind = 'S',lt = {ts '2021-03-22 12:40:23.513'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'usertype' AND tablename = 'registrationuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('usertype','registrationuser','50',null,null,'Categoria di utente','S',{ts '2021-03-22 12:40:23.513'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

