
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'virtualuser')
UPDATE [tabledescr] SET description = 'Utente web',idapplication = null,isdbo = null,lt = {ts '2017-05-20 15:26:28.413'},lu = 'nino',title = 'Utente web' WHERE tablename = 'virtualuser'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('virtualuser','Utente web',null,null,{ts '2017-05-20 15:26:28.413'},'nino','Utente web')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'birthdate' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.083'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'birthdate' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('birthdate','virtualuser','4',null,null,null,'S',{ts '1900-01-01 02:59:18.083'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'Codice fiscale',kind = 'S',lt = {ts '1900-01-01 03:00:10.617'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(16)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cf' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','virtualuser','16',null,null,'Codice fiscale','S',{ts '1900-01-01 03:00:10.617'},'nino','N','varchar(16)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicedipartimento' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.090'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicedipartimento' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicedipartimento','virtualuser','50',null,null,null,'S',{ts '1900-01-01 02:59:18.090'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Email',kind = 'S',lt = {ts '1900-01-01 03:00:13.403'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email','virtualuser','200',null,null,'Email','S',{ts '1900-01-01 03:00:13.403'},'nino','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'forename' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.097'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'forename' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('forename','virtualuser','50',null,null,null,'S',{ts '1900-01-01 02:59:18.097'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idvirtualuser' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '#',kind = 'S',lt = {ts '1900-01-01 03:00:30.387'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idvirtualuser' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idvirtualuser','virtualuser','4',null,null,'#','S',{ts '1900-01-01 03:00:30.387'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:43.527'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','virtualuser','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:43.527'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:40.557'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','virtualuser','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:40.557'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surname' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome',kind = 'S',lt = {ts '1900-01-01 03:00:15.407'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surname' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surname','virtualuser','50',null,null,'Cognome','S',{ts '1900-01-01 03:00:15.407'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sys_user' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '30',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.113'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(30)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'sys_user' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sys_user','virtualuser','30',null,null,null,'S',{ts '1900-01-01 02:59:18.113'},'nino','N','varchar(30)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'userkind' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.117'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'userkind' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('userkind','virtualuser','2',null,null,null,'S',{ts '1900-01-01 02:59:18.117'},'nino','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'username' AND tablename = 'virtualuser')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '1900-01-01 02:59:18.120'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'username' AND tablename = 'virtualuser'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('username','virtualuser','50',null,null,null,'S',{ts '1900-01-01 02:59:18.120'},'nino','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

