
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'assetdiary')
UPDATE [tabledescr] SET description = 'Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 11:37:30.923'},lu = 'assistenza',title = 'Diari di utilizzo dei beni strumentali' WHERE tablename = 'assetdiary'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('assetdiary','Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto','3','N',{ts '2021-02-19 11:37:30.923'},'assistenza','Diari di utilizzo dei beni strumentali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idasset' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bene strumentale',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idasset' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idasset','assetdiary','4',null,null,'Bene strumentale','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiary' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiary' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiary','assetdiary','4',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpiece' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero parte',kind = 'S',lt = {ts '2020-06-18 10:33:39.790'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpiece' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpiece','assetdiary','4',null,null,'Numero parte','S',{ts '2020-06-18 10:33:39.790'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','assetdiary','4',null,null,'Progetto','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Operatore',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','assetdiary','4',null,null,'Operatore','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','assetdiary','4',null,null,'Workpackage','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di utilizzo complessive preventivate',kind = 'S',lt = {ts '2020-06-18 10:33:39.793'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','assetdiary','4',null,null,'Ore di utilizzo complessive preventivate','S',{ts '2020-06-18 10:33:39.793'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'assetdiaryora')
UPDATE [tabledescr] SET description = 'Dettaglio delle ore di utilizzo di un bene strumentale',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 11:39:16.030'},lu = 'assistenza',title = 'Dettaglio delle ore' WHERE tablename = 'assetdiaryora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('assetdiaryora','Dettaglio delle ore di utilizzo di un bene strumentale','3','N',{ts '2021-02-19 11:39:16.030'},'assistenza','Dettaglio delle ore')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'amount' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2020-06-23 16:49:01.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'amount' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('amount','assetdiaryora','5','9','2',null,'S',{ts '2020-06-23 16:49:01.053'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','assetdiaryora','8',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','assetdiaryora','64',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiary' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiary' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiary','assetdiaryora','4',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiaryora' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiaryora' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiaryora','assetdiaryora','4',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato avanzamento lavori',kind = 'S',lt = {ts '2021-03-05 16:14:06.237'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','assetdiaryora','4',null,null,'Stato avanzamento lavori','S',{ts '2021-03-05 16:14:06.237'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-05 16:12:47.927'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','assetdiaryora','4',null,null,null,'S',{ts '2021-03-05 16:12:47.927'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','assetdiaryora','8',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','assetdiaryora','64',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora di inizio',kind = 'S',lt = {ts '2020-06-05 16:25:20.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','assetdiaryora','8',null,null,'Data e ora di inizio','S',{ts '2020-06-05 16:25:20.413'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora di fine',kind = 'S',lt = {ts '2020-06-05 16:25:20.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','assetdiaryora','8',null,null,'Data e ora di fine','S',{ts '2020-06-05 16:25:20.413'},'assistenza','N','datetime','datetime','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'contrattokind')
UPDATE [tabledescr] SET description = 'Tipologie di contratto',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:53:33.403'},lu = 'assistenza',title = 'Tipologie di contratto' WHERE tablename = 'contrattokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('contrattokind','Tipologie di contratto','3','S',{ts '2021-02-19 17:53:33.403'},'assistenza','Tipologie di contratto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','contrattokind','1',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegnoaggiuntivo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita assegno aggiuntivo',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assegnoaggiuntivo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegnoaggiuntivo','contrattokind','1',null,null,'Abilita assegno aggiuntivo','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo lordo annuo',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuo','contrattokind','5','9','2','Costo lordo annuo','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuooneri' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo lordo annuo e oneri',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuooneri' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuooneri','contrattokind','5','9','2','Costo lordo annuo e oneri','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','contrattokind','8',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','contrattokind','64',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','contrattokind','256',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'elementoperequativo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita elemento perequativo',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'elementoperequativo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('elementoperequativo','contrattokind','1',null,null,'Abilita elemento perequativo','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-04 13:18:56.727'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','contrattokind','4',null,null,null,'S',{ts '2018-12-04 13:18:56.727'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiateneo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita indennità di ateneo',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indennitadiateneo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiateneo','contrattokind','1',null,null,'Abilita indennità di ateneo','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiposizione' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita indennità di posizione',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indennitadiposizione' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiposizione','contrattokind','1',null,null,'Abilita indennità di posizione','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indvacancacontrattuale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita ind. vacanca contrattuale',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indvacancacontrattuale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indvacancacontrattuale','contrattokind','1',null,null,'Abilita ind. vacanca contrattuale','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','contrattokind','8',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','contrattokind','64',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxcompitididatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per i compiti didattici a tempo parziale',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxcompitididatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxcompitididatempoparziale','contrattokind','4',null,null,'Ore massime per i compiti didattici a tempo parziale','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxcompitididatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per i compiti didattici a tempo pieno',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxcompitididatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxcompitididatempopieno','contrattokind','4',null,null,'Ore massime per i compiti didattici a tempo pieno','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxdidatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per didattica frontale a tempo parziale',kind = 'S',lt = {ts '2020-05-20 11:54:19.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxdidatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxdidatempoparziale','contrattokind','4',null,null,'Ore massime per didattica frontale a tempo parziale','S',{ts '2020-05-20 11:54:19.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxdidatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per didattica frontale a tempo pieno',kind = 'S',lt = {ts '2020-05-20 11:54:19.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxdidatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxdidatempopieno','contrattokind','4',null,null,'Ore massime per didattica frontale a tempo pieno','S',{ts '2020-05-20 11:54:19.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxgg' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di lavoro al giorno massime',kind = 'S',lt = {ts '2020-06-12 15:47:15.233'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxgg' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxgg','contrattokind','4',null,null,'Ore di lavoro al giorno massime','S',{ts '2020-06-12 15:47:15.233'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxtempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime a tempo parziale',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxtempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxtempoparziale','contrattokind','4',null,null,'Ore massime a tempo parziale','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxtempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime a tempo pieno',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxtempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxtempopieno','contrattokind','4',null,null,'Ore massime a tempo pieno','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremincompitididatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime per i compiti didattici a tempo parziale',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremincompitididatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremincompitididatempoparziale','contrattokind','4',null,null,'Ore minime per i compiti didattici a tempo parziale','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremincompitididatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime per i compiti didattici a tempo pieno',kind = 'S',lt = {ts '2020-05-20 12:57:57.883'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremincompitididatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremincompitididatempopieno','contrattokind','4',null,null,'Ore minime per i compiti didattici a tempo pieno','S',{ts '2020-05-20 12:57:57.883'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremindidatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime di didattica frontale a tempo parziale',kind = 'S',lt = {ts '2020-05-20 11:48:33.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremindidatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremindidatempoparziale','contrattokind','4',null,null,'Ore minime di didattica frontale a tempo parziale','S',{ts '2020-05-20 11:48:33.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremindidatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime di didattica frontale a tempo pieno',kind = 'S',lt = {ts '2020-05-20 11:48:33.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremindidatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremindidatempopieno','contrattokind','4',null,null,'Ore minime di didattica frontale a tempo pieno','S',{ts '2020-05-20 11:48:33.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremintempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime a tempo parziale',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremintempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremintempoparziale','contrattokind','4',null,null,'Ore minime a tempo parziale','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremintempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime a tempo pieno',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremintempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremintempopieno','contrattokind','4',null,null,'Ore minime a tempo pieno','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orestraordinariemax' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime di straordinario rendicontabili',kind = 'S',lt = {ts '2020-05-21 10:06:18.870'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orestraordinariemax' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orestraordinariemax','contrattokind','4',null,null,'Ore massime di straordinario rendicontabili','S',{ts '2020-05-21 10:06:18.870'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parttime' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita part-time',kind = 'S',lt = {ts '2020-05-21 10:50:04.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'parttime' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parttime','contrattokind','1',null,null,'Abilita part-time','S',{ts '2020-05-21 10:50:04.330'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita scatti stipendio',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'scatto' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','contrattokind','1',null,null,'Abilita scatti stipendio','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','contrattokind','4',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempdef' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita tempo definito o parziale',kind = 'S',lt = {ts '2020-05-21 12:31:15.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempdef' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempdef','contrattokind','1',null,null,'Abilita tempo definito o parziale','S',{ts '2020-05-21 12:31:15.367'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','contrattokind','50',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totaletredicesima' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita totale tredicesima',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'totaletredicesima' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totaletredicesima','contrattokind','1',null,null,'Abilita totale tredicesima','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita tredicesima indennità integrativa speciale',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tredicesimaindennitaintegrativaspeciale','contrattokind','1',null,null,'Abilita tredicesima indennità integrativa speciale','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'contrattokindposition')
UPDATE [tabledescr] SET description = 'Ruoli di Easy associati alle tipologie di contratto',idapplication = null,isdbo = 'N',lt = {ts '2021-03-09 10:16:26.777'},lu = 'assistenza',title = 'Ruoli associati' WHERE tablename = 'contrattokindposition'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('contrattokindposition','Ruoli di Easy associati alle tipologie di contratto',null,'N',{ts '2021-03-09 10:16:26.777'},'assistenza','Ruoli associati')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'contrattokindposition')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 10:16:30.823'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'contrattokindposition'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','contrattokindposition','8',null,null,null,'S',{ts '2021-03-09 10:16:30.823'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'contrattokindposition')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 10:16:30.823'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'contrattokindposition'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','contrattokindposition','60',null,null,null,'S',{ts '2021-03-09 10:16:30.823'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'contrattokindposition')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di contratto',kind = 'S',lt = {ts '2021-03-09 10:16:57.217'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'contrattokindposition'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','contrattokindposition','4',null,null,'Tipologia di contratto','S',{ts '2021-03-09 10:16:57.217'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idposition' AND tablename = 'contrattokindposition')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ruolo',kind = 'S',lt = {ts '2021-03-09 10:16:57.220'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idposition' AND tablename = 'contrattokindposition'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idposition','contrattokindposition','4',null,null,'Ruolo','S',{ts '2021-03-09 10:16:57.220'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'contrattokindposition')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 10:16:30.823'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'contrattokindposition'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','contrattokindposition','8',null,null,null,'S',{ts '2021-03-09 10:16:30.823'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'contrattokindposition')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 10:16:30.823'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'contrattokindposition'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','contrattokindposition','60',null,null,null,'S',{ts '2021-03-09 10:16:30.823'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'istanza_eq')
UPDATE [tabledescr] SET description = '2.5.10 Istanza di Equipollenza, estende istanza',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 12:21:31.910'},lu = 'assistenza',title = 'Istanza di Equipollenza' WHERE tablename = 'istanza_eq'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('istanza_eq','2.5.10 Istanza di Equipollenza, estende istanza',null,'N',{ts '2018-07-20 12:21:31.910'},'assistenza','Istanza di Equipollenza')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 12:21:34.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','istanza_eq','8',null,null,null,'S',{ts '2018-07-20 12:21:34.510'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 12:21:34.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','istanza_eq','64',null,null,null,'S',{ts '2018-07-20 12:21:34.510'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddichiar_titolo_seg' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dichiarazione del titolo di studio',kind = 'S',lt = {ts '2020-09-16 17:32:23.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddichiar_titolo_seg' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddichiar_titolo_seg','istanza_eq','4',null,null,'Dichiarazione del titolo di studio','S',{ts '2020-09-16 17:32:23.377'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanza' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istanza',kind = 'S',lt = {ts '2019-11-14 11:45:10.657'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanza' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanza','istanza_eq','4',null,null,'Istanza','S',{ts '2019-11-14 11:45:10.657'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistanzakind' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-04 12:52:26.837'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistanzakind' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistanzakind','istanza_eq','4',null,null,null,'S',{ts '2020-05-04 12:52:26.837'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2019-11-14 11:45:10.657'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','istanza_eq','4',null,null,'Studente','S',{ts '2019-11-14 11:45:10.657'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 12:21:34.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','istanza_eq','8',null,null,null,'S',{ts '2018-07-20 12:21:34.510'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'istanza_eq')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-20 12:21:34.510'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'istanza_eq'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','istanza_eq','64',null,null,null,'S',{ts '2018-07-20 12:21:34.510'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3316')
UPDATE [relation] SET childtable = 'istanza_eq',description = 'dati di base della istanza',lt = {ts '2018-07-20 12:21:52.217'},lu = 'assistenza',parenttable = 'istanza',title = null WHERE idrelation = '3316'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3316','istanza_eq','dati di base della istanza',{ts '2018-07-20 12:21:52.217'},'assistenza','istanza',null)
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progetto')
UPDATE [tabledescr] SET description = 'Progetto di ricerca',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 17:26:47.600'},lu = 'assistenza',title = 'Progetto di ricerca' WHERE tablename = 'progetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progetto','Progetto di ricerca','3','N',{ts '2021-02-19 17:26:47.600'},'assistenza','Progetto di ricerca')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progetto','9','14','2','Costo totale per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolato' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale effettivo per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budgetcalcolato' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolato','progetto','9','14','2','Costo totale effettivo per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Calcolato il',kind = 'S',lt = {ts '2020-10-26 10:44:21.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolatodate','progetto','8',null,null,'Calcolato il','S',{ts '2020-10-26 10:44:21.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'capofilatxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente capofila non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'capofilatxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('capofilatxt','progetto','2048',null,null,'Ente capofila non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceidentificativo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Codice identificativo',kind = 'S',lt = {ts '2020-10-30 08:33:43.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceidentificativo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceidentificativo','progetto','2048',null,null,'Codice identificativo','S',{ts '2020-10-30 08:33:43.240'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Cofinanziamento richiesto all''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributo','progetto','9','14','2','Cofinanziamento richiesto all''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributoente' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo totale richiesto dall''ateneo all’ente finanziatore',kind = 'S',lt = {ts '2020-11-04 16:51:02.247'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributoente' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributoente','progetto','9','14','2','Contributo totale richiesto dall''ateneo all’ente finanziatore','S',{ts '2020-11-04 16:51:02.247'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cup' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Codice univoco progetto (CUP)',kind = 'S',lt = {ts '2020-10-30 17:51:30.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cup' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cup','progetto','15',null,null,'Codice univoco progetto (CUP)','S',{ts '2020-10-30 17:51:30.213'},'assistenza','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di presentazione',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','progetto','3',null,null,'Data di presentazione','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datacontabile' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data chiusura contablile',kind = 'S',lt = {ts '2020-12-09 12:56:24.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datacontabile' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datacontabile','progetto','3',null,null,'Data chiusura contablile','S',{ts '2020-12-09 12:56:24.963'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:03:58.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progetto','0',null,null,'Descrizione','S',{ts '2020-05-20 14:03:58.150'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'durata' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:11:44.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'durata' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('durata','progetto','4',null,null,null,'S',{ts '2020-05-25 13:11:44.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanziatoretxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente finanziatore non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'finanziatoretxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanziatoretxt','progetto','2048',null,null,'Ente finanziatore non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','progetto','4',null,null,'Didattica','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrency' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice valuta',kind = 'S',lt = {ts '2020-11-02 18:34:42.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrency' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrency','progetto','4',null,null,'Codice valuta','S',{ts '2020-11-02 18:34:42.180'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idduratakind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Espressa in',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idduratakind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idduratakind','progetto','4',null,null,'Espressa in','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice interno',kind = 'S',lt = {ts '2020-10-30 08:33:16.517'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progetto','4',null,null,'Codice interno','S',{ts '2020-10-30 08:33:16.517'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di progetto o attività',kind = 'S',lt = {ts '2020-11-04 16:52:57.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progetto','4',null,null,'Tipo di progetto o attività','S',{ts '2020-11-04 16:52:57.667'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato del progetto o attività',kind = 'S',lt = {ts '2020-09-30 16:14:37.087'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progetto','4',null,null,'Stato del progetto o attività','S',{ts '2020-09-30 16:14:37.087'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Principal investigator / Responsabile di progetto ',kind = 'S',lt = {ts '2020-07-15 17:09:18.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','progetto','4',null,null,'Principal investigator / Responsabile di progetto ','S',{ts '2020-07-15 17:09:18.147'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente capofila',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende','progetto','4',null,null,'Ente capofila','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente finanziatore',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende_fin','progetto','4',null,null,'Ente finanziatore','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Programma di finanziamento',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfin','progetto','4',null,null,'Programma di finanziamento','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bando di riferimento',kind = 'S',lt = {ts '2020-06-12 18:11:47.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfinbando','progetto','4',null,null,'Bando di riferimento','S',{ts '2020-06-12 18:11:47.253'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','progetto','3',null,null,'Data di inizio','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','progetto','3',null,null,'Data di fine','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4000',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(4000)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progetto','4000',null,null,'Titolo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','nvarchar(4000)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolobreve' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo breve o acronimo',kind = 'S',lt = {ts '2020-05-20 14:03:58.153'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'titolobreve' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolobreve','progetto','2048',null,null,'Titolo breve o acronimo','S',{ts '2020-05-20 14:03:58.153'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalbudget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalbudget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalbudget','progetto','9','14','2','Costo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalcontributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalcontributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalcontributo','progetto','9','14','2','Contributo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'url' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'URL del sito del progetto',kind = 'S',lt = {ts '2020-11-02 18:28:26.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'url' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('url','progetto','1024',null,null,'URL del sito del progetto','S',{ts '2020-11-02 18:28:26.997'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettobudget')
UPDATE [tabledescr] SET description = 'Budget per le categorie di costo di un progetto ',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 16:55:19.440'},lu = 'assistenza',title = 'Budget per le categorie di costo di un progetto ' WHERE tablename = 'progettobudget'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettobudget','Budget per le categorie di costo di un progetto ','3','N',{ts '2021-02-19 16:55:19.440'},'assistenza','Budget per le categorie di costo di un progetto ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Budget iniziale',kind = 'S',lt = {ts '2020-12-09 16:32:07.130'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progettobudget','5','9','2','Budget iniziale','S',{ts '2020-12-09 16:32:07.130'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudget','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voce di costo',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettobudget','4',null,null,'Voce di costo','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','progettobudget','4',null,null,'Workpackage','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine di visualizzazione',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','progettobudget','4',null,null,'Ordine di visualizzazione','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --


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


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_amministrativi')
UPDATE [tabledescr] SET description = '2.7.8 Personale amministrativo',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 16:25:35.940'},lu = 'assistenza',title = 'Personale amministrativo' WHERE tablename = 'registry_amministrativi'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_amministrativi','2.7.8 Personale amministrativo','3','S',{ts '2021-02-19 16:25:35.940'},'assistenza','Personale amministrativo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum vitae',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_amministrativi','0',null,null,'Curriculum vitae','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_amministrativi','4',null,null,'Tipo','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_amministrativi','4',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_docenti')
UPDATE [tabledescr] SET description = '2.4.20 docenti',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 10:33:23.860'},lu = 'assistenza',title = 'Docenti' WHERE tablename = 'registry_docenti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_docenti','2.4.20 docenti','3','S',{ts '2021-02-19 10:33:23.860'},'assistenza','Docenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum Vitae',kind = 'S',lt = {ts '2018-11-27 13:37:14.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_docenti','0',null,null,'Curriculum Vitae','S',{ts '2018-11-27 13:37:14.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classe consorsuale',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassconsorsuale','registry_docenti','4',null,null,'Classe consorsuale','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-26 17:44:20.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_docenti','4',null,null,'Tipo','S',{ts '2020-05-26 17:44:20.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fonte',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idfonteindicebibliometrico','registry_docenti','4',null,null,'Fonte','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_docenti','4',null,null,'Codice Istituto','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto, Ente o Azienda',kind = 'S',lt = {ts '2019-02-15 17:21:00.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istituti','registry_docenti','4',null,null,'Istituto, Ente o Azienda','S',{ts '2019-02-15 17:21:00.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','registry_docenti','4',null,null,'SASD','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di afferenza',kind = 'S',lt = {ts '2019-09-09 18:32:55.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','registry_docenti','4',null,null,'Struttura di afferenza','S',{ts '2019-09-09 18:32:55.953'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Indice bibliometrico (H-Index)',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicebibliometrico','registry_docenti','4',null,null,'Indice bibliometrico (H-Index)','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'matricola' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Matricola',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'matricola' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('matricola','registry_docenti','50',null,null,'Matricola','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ricevimento' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Orari di ricevimento',kind = 'S',lt = {ts '2018-11-27 13:28:30.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'ricevimento' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ricevimento','registry_docenti','0',null,null,'Orari di ricevimento','S',{ts '2018-11-27 13:28:30.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'soggiorno' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = 'Permesso di soggiorno',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'soggiorno' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('soggiorno','registry_docenti','255',null,null,'Permesso di soggiorno','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicont')
UPDATE [tabledescr] SET description = '2.4.31 Scheda di rendicontazione / registro elettronico
',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 11:41:54.540'},lu = 'assistenza',title = 'Scheda di rendicontazione / registro elettronico' WHERE tablename = 'rendicont'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicont','2.4.31 Scheda di rendicontazione / registro elettronico
','3','S',{ts '2021-02-19 11:41:54.540'},'assistenza','Scheda di rendicontazione / registro elettronico')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2019-10-15 16:01:49.763'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','rendicont','9',null,null,'Anno accademico','S',{ts '2019-10-15 16:01:49.763'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicont','8',null,null,null,'S',{ts '2018-07-27 18:16:39.210'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicont','64',null,null,null,'S',{ts '2018-07-27 18:16:39.213'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-04-24 17:25:10.743'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','rendicont','4',null,null,'Docente','S',{ts '2019-04-24 17:25:10.743'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicont','8',null,null,null,'S',{ts '2018-07-27 18:16:39.213'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:16:39.217'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicont','64',null,null,null,'S',{ts '2018-07-27 18:16:39.217'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'rendicont')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-10-16 12:53:52.563'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'rendicont'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','rendicont','1024',null,null,'Denominazione','S',{ts '2019-10-16 12:53:52.563'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3442')
UPDATE [relation] SET childtable = 'rendicont',description = 'Rendicontazioni annuali',lt = {ts '2018-12-07 18:37:51.957'},lu = 'assistenza',parenttable = 'docenti',title = '2.4.31 Scheda di rendicontazione / registro elettronico
' WHERE idrelation = '3442'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3442','rendicont','Rendicontazioni annuali',{ts '2018-12-07 18:37:51.957'},'assistenza','docenti','2.4.31 Scheda di rendicontazione / registro elettronico
')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontaltro')
UPDATE [tabledescr] SET description = 'Registro delle attività oltre le lezioni della 2.4.31 Scheda di rendicontazione / registro elettronico
',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 11:42:07.003'},lu = 'assistenza',title = 'Registro delle attività oltre le lezioni della scheda di rendicontazione / registro elettroni' WHERE tablename = 'rendicontaltro'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontaltro','Registro delle attività oltre le lezioni della 2.4.31 Scheda di rendicontazione / registro elettronico
','3','S',{ts '2021-02-19 11:42:07.003'},'assistenza','Registro delle attività oltre le lezioni della scheda di rendicontazione / registro elettroni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2019-10-15 15:56:13.037'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','rendicontaltro','9',null,null,'Anno accademico','S',{ts '2019-10-15 15:56:13.037'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:17:44.543'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontaltro','8',null,null,null,'S',{ts '2018-07-27 18:17:44.543'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:17:44.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontaltro','64',null,null,null,'S',{ts '2018-07-27 18:17:44.547'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 13:59:57.583'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','rendicontaltro','3',null,null,null,'S',{ts '2020-05-20 13:59:57.583'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-10-15 15:56:13.037'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','rendicontaltro','4',null,null,'Docente','S',{ts '2019-10-15 15:56:13.037'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontaltro' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2018-11-21 18:41:08.290'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontaltro' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontaltro','rendicontaltro','4',null,null,'Codice','S',{ts '2018-11-21 18:41:08.290'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontaltrokind' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2018-11-21 18:41:08.290'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontaltrokind' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontaltrokind','rendicontaltro','4',null,null,'Tipologia','S',{ts '2018-11-21 18:41:08.290'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:17:44.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontaltro','8',null,null,null,'S',{ts '2018-07-27 18:17:44.547'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 18:17:44.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontaltro','64',null,null,null,'S',{ts '2018-07-27 18:17:44.547'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ore' AND tablename = 'rendicontaltro')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2018-07-27 18:17:44.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'ore' AND tablename = 'rendicontaltro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ore','rendicontaltro','5','9','2',null,'S',{ts '2018-07-27 18:17:44.547'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3436')
UPDATE [relation] SET childtable = 'rendicontaltro',description = 'Altre attivit?',lt = {ts '2018-12-07 18:40:15.610'},lu = 'assistenza',parenttable = 'rendicont',title = 'rendicontaltro' WHERE idrelation = '3436'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3436','rendicontaltro','Altre attivit?',{ts '2018-12-07 18:40:15.610'},'assistenza','rendicont','rendicontaltro')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogetto')
UPDATE [tabledescr] SET description = '2.7.3 attività di progetto',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 11:17:26.343'},lu = 'assistenza',title = 'attività di progetto' WHERE tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogetto','2.7.3 attività di progetto','3','N',{ts '2021-02-19 11:17:26.343'},'assistenza','attività di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','rendicontattivitaprogetto','3',null,null,'Data inizio prevista','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','rendicontattivitaprogetto','-1',null,null,'Descrizione','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Missione',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditineration','rendicontattivitaprogetto','4',null,null,'Missione','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','rendicontattivitaprogetto','4',null,null,'Progetto','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Partecipante',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','rendicontattivitaprogetto','4',null,null,'Partecipante','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogetto','4',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2021-03-05 16:14:40.183'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','rendicontattivitaprogetto','4',null,null,'Workpackage','S',{ts '2021-03-05 16:14:40.183'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore preventivate',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','rendicontattivitaprogetto','4',null,null,'Numero di ore preventivate','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine prevista',kind = 'S',lt = {ts '2021-03-05 16:15:09.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','rendicontattivitaprogetto','3',null,null,'Data fine prevista','S',{ts '2021-03-05 16:15:09.310'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogettoora')
UPDATE [tabledescr] SET description = 'Dettaglio giornaliero della 2.7.3 rendicontazione delle attività di progetto',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 11:22:56.850'},lu = 'assistenza',title = 'Dettaglio giornaliero della attività di progetto' WHERE tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogettoora','Dettaglio giornaliero della 2.7.3 rendicontazione delle attività di progetto','3','N',{ts '2021-02-19 11:22:56.850'},'assistenza','Dettaglio giornaliero della attività di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontattivitaprogettoora','8',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontattivitaprogettoora','64',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data',kind = 'S',lt = {ts '2020-05-20 14:11:37.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','rendicontattivitaprogettoora','3',null,null,'Data','S',{ts '2020-05-20 14:11:37.110'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attività di progetto',kind = 'S',lt = {ts '2021-03-05 16:16:39.557'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogettoora','4',null,null,'Attività di progetto','S',{ts '2021-03-05 16:16:39.557'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 15:34:08.850'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogettoora','rendicontattivitaprogettoora','4',null,null,null,'S',{ts '2020-05-20 15:34:08.850'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato di avanzamento lavori',kind = 'S',lt = {ts '2021-03-05 16:16:39.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','rendicontattivitaprogettoora','4',null,null,'Stato di avanzamento lavori','S',{ts '2021-03-05 16:16:39.557'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-05 16:15:49.263'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','rendicontattivitaprogettoora','4',null,null,null,'S',{ts '2021-03-05 16:15:49.263'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontattivitaprogettoora','8',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontattivitaprogettoora','64',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ore' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore',kind = 'S',lt = {ts '2020-05-20 14:11:57.517'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ore' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ore','rendicontattivitaprogettoora','4',null,null,'Numero di ore','S',{ts '2020-05-20 14:11:57.517'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sal')
UPDATE [tabledescr] SET description = 'Stato avanzamento lavori',idapplication = '3',isdbo = 'N',lt = {ts '2021-03-10 16:08:45.873'},lu = 'assistenza',title = 'Stato avanzamento lavori' WHERE tablename = 'sal'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sal','Stato avanzamento lavori','3','N',{ts '2021-03-10 16:08:45.873'},'assistenza','Stato avanzamento lavori')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '9',col_precision = '16',col_scale = '2',description = 'Budget preventivato',kind = 'S',lt = {ts '2021-03-09 10:15:25.897'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(16,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','sal','9','16','2','Budget preventivato','S',{ts '2021-03-09 10:15:25.897'},'assistenza','N','decimal(16,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datablocco' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di Blocco',kind = 'S',lt = {ts '2021-03-09 10:15:25.900'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datablocco' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datablocco','sal','3',null,null,'Data di Blocco','S',{ts '2021-03-09 10:15:25.900'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2021-03-05 16:17:43.967'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','sal','4',null,null,'Progetto','S',{ts '2021-03-05 16:17:43.967'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SAL',kind = 'S',lt = {ts '2021-03-09 10:15:25.900'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','sal','4',null,null,'SAL','S',{ts '2021-03-09 10:15:25.900'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2021-03-09 10:15:25.900'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','sal','3',null,null,'Data di inizio','S',{ts '2021-03-09 10:15:25.900'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2021-03-09 10:15:25.903'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','sal','3',null,null,'Data di fine','S',{ts '2021-03-09 10:15:25.903'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'salassetdiaryora')
UPDATE [tabledescr] SET description = 'Ore dei diari d''uso del SAL',idapplication = '3',isdbo = 'N',lt = {ts '2021-03-10 16:08:57.197'},lu = 'assistenza',title = 'Ore dei diari d''uso del SAL' WHERE tablename = 'salassetdiaryora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('salassetdiaryora','Ore dei diari d''uso del SAL','3','N',{ts '2021-03-10 16:08:57.197'},'assistenza','Ore dei diari d''uso del SAL')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'salassetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:26:29.877'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'salassetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','salassetdiaryora','8',null,null,null,'S',{ts '2021-03-09 17:26:29.877'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'salassetdiaryora')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:26:29.877'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'salassetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','salassetdiaryora','60',null,null,null,'S',{ts '2021-03-09 17:26:29.877'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiaryora' AND tablename = 'salassetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore dei diari d''uso',kind = 'S',lt = {ts '2021-03-09 17:30:06.680'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiaryora' AND tablename = 'salassetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiaryora','salassetdiaryora','4',null,null,'Ore dei diari d''uso','S',{ts '2021-03-09 17:30:06.680'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'salassetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:30:06.680'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'salassetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','salassetdiaryora','4',null,null,null,'S',{ts '2021-03-09 17:30:06.680'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'salassetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:30:06.680'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'salassetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','salassetdiaryora','4',null,null,null,'S',{ts '2021-03-09 17:30:06.680'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'salassetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:26:29.877'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'salassetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','salassetdiaryora','8',null,null,null,'S',{ts '2021-03-09 17:26:29.877'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'salassetdiaryora')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:26:29.877'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'salassetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','salassetdiaryora','60',null,null,null,'S',{ts '2021-03-09 17:26:29.877'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'salprogettocosto')
UPDATE [tabledescr] SET description = 'Dettagli dei costi del SAL',idapplication = '3',isdbo = 'N',lt = {ts '2021-03-10 16:09:05.640'},lu = 'assistenza',title = 'Dettagli dei costi del SAL' WHERE tablename = 'salprogettocosto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('salprogettocosto','Dettagli dei costi del SAL','3','N',{ts '2021-03-10 16:09:05.640'},'assistenza','Dettagli dei costi del SAL')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'salprogettocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:24:29.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'salprogettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','salprogettocosto','8',null,null,null,'S',{ts '2021-03-09 17:24:29.667'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'salprogettocosto')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:24:29.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'salprogettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','salprogettocosto','60',null,null,null,'S',{ts '2021-03-09 17:24:29.667'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'salprogettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:24:29.667'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'salprogettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','salprogettocosto','4',null,null,null,'S',{ts '2021-03-09 17:24:29.667'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettocosto' AND tablename = 'salprogettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dettaglio costo',kind = 'S',lt = {ts '2021-03-09 17:24:46.483'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettocosto' AND tablename = 'salprogettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettocosto','salprogettocosto','4',null,null,'Dettaglio costo','S',{ts '2021-03-09 17:24:46.483'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'salprogettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:24:29.667'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'salprogettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','salprogettocosto','4',null,null,null,'S',{ts '2021-03-09 17:24:29.667'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'salprogettocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:24:29.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'salprogettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','salprogettocosto','8',null,null,null,'S',{ts '2021-03-09 17:24:29.667'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'salprogettocosto')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-09 17:24:29.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'salprogettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','salprogettocosto','60',null,null,null,'S',{ts '2021-03-09 17:24:29.667'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'salrendicontattivitaprogettoora')
UPDATE [tabledescr] SET description = 'Ore di attività del SAL',idapplication = null,isdbo = 'N',lt = {ts '2021-03-10 17:35:04.863'},lu = 'assistenza',title = 'Ore di attività del SAL' WHERE tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('salrendicontattivitaprogettoora','Ore di attività del SAL',null,'N',{ts '2021-03-10 17:35:04.863'},'assistenza','Ore di attività del SAL')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'salrendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-10 17:35:11.087'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','salrendicontattivitaprogettoora','8',null,null,null,'S',{ts '2021-03-10 17:35:11.087'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'salrendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-10 17:35:11.087'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','salrendicontattivitaprogettoora','60',null,null,null,'S',{ts '2021-03-10 17:35:11.087'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'salrendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-10 17:35:11.087'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','salrendicontattivitaprogettoora','4',null,null,null,'S',{ts '2021-03-10 17:35:11.087'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'salrendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di attività',kind = 'S',lt = {ts '2021-03-10 17:35:39.967'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogettoora','salrendicontattivitaprogettoora','4',null,null,'Ore di attività','S',{ts '2021-03-10 17:35:39.967'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'salrendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-10 17:35:11.087'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','salrendicontattivitaprogettoora','4',null,null,null,'S',{ts '2021-03-10 17:35:11.087'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'salrendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-10 17:35:11.087'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','salrendicontattivitaprogettoora','8',null,null,null,'S',{ts '2021-03-10 17:35:11.087'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'salrendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-03-10 17:35:11.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'salrendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','salrendicontattivitaprogettoora','60',null,null,null,'S',{ts '2021-03-10 17:35:11.090'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'workpackage')
UPDATE [tabledescr] SET description = 'Workpackage',idapplication = '3',isdbo = 'N',lt = {ts '2021-02-19 16:41:27.513'},lu = 'assistenza',title = 'Workpackage' WHERE tablename = 'workpackage'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('workpackage','Workpackage','3','N',{ts '2021-02-19 16:41:27.513'},'assistenza','Workpackage')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'acronimo' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'acronimo' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('acronimo','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','workpackage','0',null,null,'Descrizione','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','workpackage','4',null,null,'Progetto','S',{ts '2020-05-20 14:05:52.450'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dipartimento',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','workpackage','4',null,null,'Dipartimento','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Unità previsionale di base (UPB)',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','workpackage','50',null,null,'Unità previsionale di base (UPB)','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','workpackage','4',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'raggruppamento' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'raggruppamento' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('raggruppamento','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2021-03-05 16:19:51.397'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','workpackage','3',null,null,'Data di inizio','S',{ts '2021-03-05 16:19:51.397'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2021-03-05 16:19:51.397'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','workpackage','3',null,null,'Data di fine','S',{ts '2021-03-05 16:19:51.397'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','workpackage','2048',null,null,'Titolo','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

