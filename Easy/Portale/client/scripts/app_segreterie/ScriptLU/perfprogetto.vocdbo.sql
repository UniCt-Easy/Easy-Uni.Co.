
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfprogetto')
UPDATE [tabledescr] SET description = 'Progetti strategici',idapplication = '2',isdbo = 'S',lt = {ts '2021-10-26 10:21:33.927'},lu = 'Generator',title = 'Progetti strategici' WHERE tablename = 'perfprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfprogetto','Progetti strategici','2','S',{ts '2021-10-26 10:21:33.927'},'Generator','Progetti strategici')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'benefici' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Benefici attesi',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'benefici' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('benefici','perfprogetto','-1',null,null,'Benefici attesi','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:26:40.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfprogetto','8',null,null,null,'S',{ts '2021-05-31 12:26:40.983'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:26:40.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfprogetto','64',null,null,null,'S',{ts '2021-05-31 12:26:40.983'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineeffettiva' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data fine effettiva',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datafineeffettiva' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineeffettiva','perfprogetto','8',null,null,'Data fine effettiva','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineprevista' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data fine prevista',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datafineprevista' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineprevista','perfprogetto','8',null,null,'Data fine prevista','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioeffettiva' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data inizio effettiva',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datainizioeffettiva' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioeffettiva','perfprogetto','8',null,null,'Data inizio effettiva','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','perfprogetto','8',null,null,'Data inizio prevista','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','perfprogetto','-1',null,null,'Descrizione','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogsuddannokind' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Frequenza monitoraggi',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogsuddannokind' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogsuddannokind','perfprogetto','4',null,null,'Frequenza monitoraggi','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogetto' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-24 14:57:05.407'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogetto' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogetto','perfprogetto','4',null,null,null,'S',{ts '2021-05-24 14:57:05.407'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfprogettostatus' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfprogettostatus' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfprogettostatus','perfprogetto','4',null,null,'Stato','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura',kind = 'S',lt = {ts '2021-06-09 12:02:20.097'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','perfprogetto','4',null,null,'Struttura','S',{ts '2021-06-09 12:02:20.097'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:26:40.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfprogetto','8',null,null,null,'S',{ts '2021-05-31 12:26:40.983'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-05-31 12:26:40.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfprogetto','64',null,null,null,'S',{ts '2021-05-31 12:26:40.983'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'note' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Note',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'note' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('note','perfprogetto','-1',null,null,'Note','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'risultato' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-26 10:21:33.930'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'risultato' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('risultato','perfprogetto','9','18','2','','S',{ts '2021-10-26 10:21:33.930'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'perfprogetto')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2021-05-24 15:02:23.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'perfprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','perfprogetto','1024',null,null,'Titolo','S',{ts '2021-05-24 15:02:23.393'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

