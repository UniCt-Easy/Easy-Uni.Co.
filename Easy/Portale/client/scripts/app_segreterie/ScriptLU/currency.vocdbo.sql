
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'currency')
UPDATE [tabledescr] SET description = 'Valuta',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:48:16.280'},lu = 'assistenza',title = 'Valuta' WHERE tablename = 'currency'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('currency','Valuta','3','S',{ts '2021-02-19 17:48:16.280'},'assistenza','Valuta')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codecurrency' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice valuta (tabella currency)',kind = 'S',lt = {ts '1900-01-01 03:00:15.183'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codecurrency' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codecurrency','currency','20',null,null,'Codice valuta (tabella currency)','S',{ts '1900-01-01 03:00:15.183'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:46.793'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','currency','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:46.793'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.227'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','currency','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.227'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:50.693'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','currency','50',null,null,'Descrizione','S',{ts '1900-01-01 02:59:50.693'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrency' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Chiave valuta (tab. currency)',kind = 'S',lt = {ts '1900-01-01 03:00:12.207'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrency' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrency','currency','4',null,null,'Chiave valuta (tab. currency)','S',{ts '1900-01-01 03:00:12.207'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.350'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','currency','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.350'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'currency')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.380'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'currency'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','currency','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.380'},'nino','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

