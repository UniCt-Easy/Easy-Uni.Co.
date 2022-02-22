
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettocosto')
UPDATE [tabledescr] SET description = 'Costi per le categorie di costo di un progetto',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 16:58:05.627'},lu = 'assistenza',title = 'Costi per le categorie di costo di un progetto' WHERE tablename = 'progettocosto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettocosto','Costi per le categorie di costo di un progetto','3','N',{ts '2021-02-19 16:58:05.627'},'assistenza','Costi per le categorie di costo di un progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'amount' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Importo',kind = 'S',lt = {ts '2020-06-26 10:49:38.193'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'amount' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('amount','progettocosto','5','9','2','Importo','S',{ts '2020-06-26 10:49:38.193'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.523'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettocosto','8',null,null,null,'S',{ts '2020-06-18 12:18:33.523'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.523'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettocosto','64',null,null,null,'S',{ts '2020-06-18 12:18:33.523'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'doc' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '35',col_precision = null,col_scale = null,description = 'Documento collegato',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(35)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'doc' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('doc','progettocosto','35',null,null,'Documento collegato','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','varchar(35)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'docdate' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data del documento collegato',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'docdate' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('docdate','progettocosto','3',null,null,'Data del documento collegato','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di contratto',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','progettocosto','4',null,null,'Tipo di contratto','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idexp' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Spesa',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idexp' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idexp','progettocosto','4',null,null,'Spesa','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpettycash' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fondo economale',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpettycash' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpettycash','progettocosto','4',null,null,'Fondo economale','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettocosto','4',null,null,'Progetto','S',{ts '2020-06-26 10:49:38.197'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettocosto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.523'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettocosto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettocosto','progettocosto','4',null,null,null,'S',{ts '2020-06-18 12:18:33.523'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voce di costo',kind = 'S',lt = {ts '2020-06-18 12:19:18.350'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettocosto','4',null,null,'Voce di costo','S',{ts '2020-06-18 12:19:18.350'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrelated' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Chiave economico patrimoniale',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idrelated' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrelated','progettocosto','50',null,null,'Chiave economico patrimoniale','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attività svolta',kind = 'S',lt = {ts '2020-10-02 18:12:48.977'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','progettocosto','4',null,null,'Attività svolta','S',{ts '2020-10-02 18:12:48.977'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato avanzamento lavori',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','progettocosto','4',null,null,'Stato avanzamento lavori','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-18 12:19:18.350'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','progettocosto','4',null,null,'Workpackage','S',{ts '2020-06-18 12:19:18.350'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettocosto','8',null,null,null,'S',{ts '2020-06-18 12:18:33.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettocosto','64',null,null,null,'S',{ts '2020-06-18 12:18:33.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'noperation' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero operazione',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'noperation' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('noperation','progettocosto','4',null,null,'Numero operazione','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'yoperation' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Esercizio operazione',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'yoperation' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('yoperation','progettocosto','2',null,null,'Esercizio operazione','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','smallint','smallint','System.Int16')
GO

-- FINE GENERAZIONE SCRIPT --

