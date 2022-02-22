
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'protocollodestinatario')
UPDATE [tabledescr] SET description = 'Destinatari della 2.6.12 registrazione di protocollo',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-22 10:32:36.353'},lu = 'assistenza',title = 'Destinatari' WHERE tablename = 'protocollodestinatario'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('protocollodestinatario','Destinatari della 2.6.12 registrazione di protocollo','3','S',{ts '2021-02-22 10:32:36.353'},'assistenza','Destinatari')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 12:33:16.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','protocollodestinatario','8',null,null,null,'S',{ts '2020-03-27 12:33:16.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 12:33:16.307'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','protocollodestinatario','64',null,null,null,'S',{ts '2020-03-27 12:33:16.307'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'destcodiceaoo' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Amministrazione pubblica destinataria - Codice IPA area organizzativa omogenea',kind = 'S',lt = {ts '2020-03-27 12:33:59.183'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'destcodiceaoo' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('destcodiceaoo','protocollodestinatario','50',null,null,'Amministrazione pubblica destinataria - Codice IPA area organizzativa omogenea','S',{ts '2020-03-27 12:33:59.183'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'destidamm' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Amministrazione pubblica destinataria - Codice IPA',kind = 'S',lt = {ts '2020-03-27 12:33:59.183'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'destidamm' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('destidamm','protocollodestinatario','50',null,null,'Amministrazione pubblica destinataria - Codice IPA','S',{ts '2020-03-27 12:33:59.183'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'destmail' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'E-mail',kind = 'S',lt = {ts '2020-03-27 12:34:37.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'destmail' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('destmail','protocollodestinatario','512',null,null,'E-mail','S',{ts '2020-03-27 12:34:37.747'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprotocollodestinatario' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 12:33:16.307'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprotocollodestinatario' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprotocollodestinatario','protocollodestinatario','4',null,null,null,'S',{ts '2020-03-27 12:33:16.307'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_dest' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Destinatario',kind = 'S',lt = {ts '2020-03-27 12:34:37.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_dest' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_dest','protocollodestinatario','4',null,null,'Destinatario','S',{ts '2020-03-27 12:34:37.747'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 12:33:16.307'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','protocollodestinatario','8',null,null,null,'S',{ts '2020-03-27 12:33:16.307'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 12:33:16.307'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','protocollodestinatario','64',null,null,null,'S',{ts '2020-03-27 12:33:16.307'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protanno' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 12:33:16.307'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protanno' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protanno','protocollodestinatario','4',null,null,null,'S',{ts '2020-03-27 12:33:16.307'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protnumero' AND tablename = 'protocollodestinatario')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-27 12:33:16.307'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protnumero' AND tablename = 'protocollodestinatario'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protnumero','protocollodestinatario','4',null,null,null,'S',{ts '2020-03-27 12:33:16.307'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

