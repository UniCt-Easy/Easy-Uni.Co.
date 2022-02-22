
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'upb')
UPDATE [tabledescr] SET description = 'U.P.B.',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:29.117'},lu = 'nino',title = 'U.P.B.' WHERE tablename = 'upb'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('upb','U.P.B.','1','N',{ts '1900-01-01 03:00:29.117'},'nino','U.P.B.')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Attivo',kind = 'S',lt = {ts '2020-11-04 19:03:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','upb','1','0','0','Attivo','S',{ts '2020-11-04 19:03:24.460'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assured' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Finanziamento certo (Non gestire assegnazione crediti/incassi)',kind = 'C',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assured' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assured','upb','1','0','0','Finanziamento certo (Non gestire assegnazione crediti/incassi)','C',{ts '2016-11-21 14:04:04.650'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cigcode' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '10',col_precision = '0',col_scale = '0',description = 'Codice CIG, Codice identificativo di gara',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cigcode' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cigcode','upb','10','0','0','Codice CIG, Codice identificativo di gara','S',{ts '2016-11-21 14:04:04.650'},'nino','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codeupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '50',col_precision = '0',col_scale = '0',description = 'Codice',kind = 'S',lt = {ts '2020-11-04 19:03:24.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codeupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codeupb','upb','50','0','0','Codice','S',{ts '2020-11-04 19:03:24.460'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data creazione',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','upb','8','0','0','data creazione','S',{ts '2016-11-21 14:04:04.650'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome utente creazione',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','upb','64','0','0','nome utente creazione','S',{ts '2016-11-21 14:04:04.650'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cupcode' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '15',col_precision = '0',col_scale = '0',description = 'Codice CUP, Codice unico di progetto',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cupcode' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cupcode','upb','15','0','0','Codice CUP, Codice unico di progetto','S',{ts '2016-11-21 14:04:04.650'},'nino','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'expiration' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'scadenza',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'expiration' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('expiration','upb','8','0','0','scadenza','S',{ts '2016-11-21 14:04:04.650'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'flag vari',kind = 'B',lt = {ts '2016-11-21 14:05:17.787'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'flag' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag','upb','4','0','0','flag vari','B',{ts '2016-11-21 14:05:17.787'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagactivity' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '2',col_precision = '0',col_scale = '0',description = 'Tipo attività',kind = 'C',lt = {ts '2020-11-04 18:01:20.387'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'flagactivity' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagactivity','upb','2','0','0','Tipo attività','C',{ts '2020-11-04 18:01:20.387'},'assistenza','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagkind' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '1',col_precision = '0',col_scale = '0',description = 'Funzione',kind = 'B',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'flagkind' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagkind','upb','1','0','0','Funzione','B',{ts '2016-11-21 14:04:04.650'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'granted' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Finanziamento concesso',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'granted' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('granted','upb','9','19','2','Finanziamento concesso','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idepupbkind' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idepupbkind' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idepupbkind','upb','4','0','0','ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idman' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id responsabile (tabella manager)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idman' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idman','upb','4','0','0','id responsabile (tabella manager)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor01' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 1(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor01' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor01','upb','4','0','0','id voce class.sicurezza 1(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor02' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 2(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor02' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor02','upb','4','0','0','id voce class.sicurezza 2(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor03' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 3(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor03' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor03','upb','4','0','0','id voce class.sicurezza 3(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor04' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 4(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor04' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor04','upb','4','0','0','id voce class.sicurezza 4(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor05' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'id voce class.sicurezza 5(tabella sorting)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor05' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor05','upb','4','0','0','id voce class.sicurezza 5(tabella sorting)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtreasurer' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'Id cassiere (tabella treasurer)',kind = 'S',lt = {ts '2016-11-21 14:04:04.650'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtreasurer' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtreasurer','upb','4','0','0','Id cassiere (tabella treasurer)','S',{ts '2016-11-21 14:04:04.650'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idunderwriter' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '4',col_precision = '0',col_scale = '0',description = 'ID Ente finanziatore (tabella underwriter)',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idunderwriter' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idunderwriter','upb','4','0','0','ID Ente finanziatore (tabella underwriter)','S',{ts '2016-11-21 14:04:04.657'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '36',col_precision = '0',col_scale = '0',description = 'id voce upb (tabella upb)',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','upb','36','0','0','id voce upb (tabella upb)','S',{ts '2016-11-21 14:04:04.657'},'nino','S','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data ultima modifica',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','upb','8','0','0','data ultima modifica','S',{ts '2016-11-21 14:04:04.657'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '64',col_precision = '0',col_scale = '0',description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','upb','64','0','0','nome ultimo utente modifica','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newcodeupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '50',col_precision = '0',col_scale = '0',description = 'Codice di consolidamento',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'newcodeupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newcodeupb','upb','50','0','0','Codice di consolidamento','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridupb' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '36',col_precision = '0',col_scale = '0',description = 'chiave parent U.P.B. (tabella upb) ',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'paridupb' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridupb','upb','36','0','0','chiave parent U.P.B. (tabella upb) ','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'previousappropriation' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale impegnato pregresso (previa informatizzazione)',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'previousappropriation' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('previousappropriation','upb','9','19','2','Totale impegnato pregresso (previa informatizzazione)','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'previousassessment' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale accertato pregresso (previa informatizzazione)',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'previousassessment' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('previousassessment','upb','9','19','2','Totale accertato pregresso (previa informatizzazione)','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'printingorder' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '50',col_precision = '0',col_scale = '0',description = 'Ordine di stampa',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'printingorder' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('printingorder','upb','50','0','0','Ordine di stampa','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'requested' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Finanziamento richiesto',kind = 'S',lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'requested' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('requested','upb','9','19','2','Finanziamento richiesto','S',{ts '2016-02-03 09:14:40.863'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '16',col_precision = '0',col_scale = '0',description = 'allegati',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','upb','16','0','0','allegati','S',{ts '2016-11-21 14:04:04.657'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data inizio',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','upb','8','0','0','data inizio','S',{ts '2016-11-21 14:04:04.657'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '8',col_precision = '0',col_scale = '0',description = 'data fine',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','upb','8','0','0','data fine','S',{ts '2016-11-21 14:04:04.657'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '150',col_precision = '0',col_scale = '0',description = 'Denominazione',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','upb','150','0','0','Denominazione','S',{ts '2016-11-21 14:04:04.657'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'upb')
UPDATE [coldescr] SET col_len = '16',col_precision = '0',col_scale = '0',description = 'note testuali',kind = 'S',lt = {ts '2016-11-21 14:04:04.657'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'upb'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','upb','16','0','0','note testuali','S',{ts '2016-11-21 14:04:04.657'},'nino','N','text','text','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colbit --
IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '0' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-11-21 14:05:17.787'},lu = 'nino',title = 'EP bloccato per prima fase e variazioni' WHERE colname = 'flag' AND nbit = '0' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','0','upb',null,{ts '2016-11-21 14:05:17.787'},'nino','EP bloccato per prima fase e variazioni')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flag' AND nbit = '1' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-11-21 14:05:17.787'},lu = 'nino',title = 'Finanziario bloccato per prima fase e variazioni' WHERE colname = 'flag' AND nbit = '1' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flag','1','upb',null,{ts '2016-11-21 14:05:17.787'},'nino','Finanziario bloccato per prima fase e variazioni')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flagkind' AND nbit = '0' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Didattica' WHERE colname = 'flagkind' AND nbit = '0' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flagkind','0','upb',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Didattica')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flagkind' AND nbit = '1' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Ricerca' WHERE colname = 'flagkind' AND nbit = '1' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flagkind','1','upb',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Ricerca')
GO

IF exists(SELECT * FROM [colbit] WHERE colname = 'flagkind' AND nbit = '2' AND tablename = 'upb')
UPDATE [colbit] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Usa contabilit? speciale negli impegni di budget' WHERE colname = 'flagkind' AND nbit = '2' AND tablename = 'upb'
ELSE
INSERT INTO [colbit] (colname,nbit,tablename,description,lt,lu,title) VALUES ('flagkind','2','upb',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Usa contabilit? speciale negli impegni di budget')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'assured' AND tablename = 'upb' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Non si tratta di Finanziamento certo' WHERE colname = 'assured' AND tablename = 'upb' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('assured','upb','N',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Non si tratta di Finanziamento certo')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'assured' AND tablename = 'upb' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Finanziamento certo' WHERE colname = 'assured' AND tablename = 'upb' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('assured','upb','S',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Finanziamento certo')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '1')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Istituzionale' WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '1'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagactivity','upb','1',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Istituzionale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '2')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Commerciale' WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '2'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagactivity','upb','2',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Commerciale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '4')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:14:40.863'},lu = 'assistenza',title = 'Qualsiasi / Non specificata' WHERE colname = 'flagactivity' AND tablename = 'upb' AND value = '4'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagactivity','upb','4',null,{ts '2016-02-03 09:14:40.863'},'assistenza','Qualsiasi / Non specificata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '483')
UPDATE [relation] SET childtable = 'upb',description = 'ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)',lt = {ts '2017-05-20 09:19:47.780'},lu = 'lu',parenttable = 'epupbkind',title = 'U.P.B.' WHERE idrelation = '483'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('483','upb','ID Tipo UPB nell''economico patrimoniale (tabella epupbkind)',{ts '2017-05-20 09:19:47.780'},'lu','epupbkind','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1172')
UPDATE [relation] SET childtable = 'upb',description = 'id responsabile (tabella manager)',lt = {ts '2017-05-20 09:19:59.413'},lu = 'lu',parenttable = 'manager',title = 'U.P.B.' WHERE idrelation = '1172'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1172','upb','id responsabile (tabella manager)',{ts '2017-05-20 09:19:59.413'},'lu','manager','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2531')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2531'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2531','upb','id voce class.sicurezza 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2532')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2532'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2532','upb','id voce class.sicurezza 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2533')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2533'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2533','upb','id voce class.sicurezza 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2534')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 4(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2534'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2534','upb','id voce class.sicurezza 4(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2535')
UPDATE [relation] SET childtable = 'upb',description = 'id voce class.sicurezza 5(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'U.P.B.' WHERE idrelation = '2535'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2535','upb','id voce class.sicurezza 5(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2734')
UPDATE [relation] SET childtable = 'upb',description = 'Id cassiere (tabella treasurer)',lt = {ts '2017-05-20 09:20:11.903'},lu = 'lu',parenttable = 'treasurer',title = 'U.P.B.' WHERE idrelation = '2734'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2734','upb','Id cassiere (tabella treasurer)',{ts '2017-05-20 09:20:11.903'},'lu','treasurer','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2736')
UPDATE [relation] SET childtable = 'upb',description = 'ID Ente finanziatore (tabella underwriter)',lt = {ts '2017-05-20 09:20:12.060'},lu = 'lu',parenttable = 'underwriter',title = 'U.P.B.' WHERE idrelation = '2736'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2736','upb','ID Ente finanziatore (tabella underwriter)',{ts '2017-05-20 09:20:12.060'},'lu','underwriter','U.P.B.')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3090')
UPDATE [relation] SET childtable = 'upb',description = 'chiave parent U.P.B. (tabella upb) ',lt = {ts '2017-05-22 14:54:23.597'},lu = 'nino',parenttable = 'upb',title = 'U.P.B.' WHERE idrelation = '3090'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3090','upb','chiave parent U.P.B. (tabella upb) ',{ts '2017-05-22 14:54:23.597'},'nino','upb','U.P.B.')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '483' AND parentcol = 'idepupbkind')
UPDATE [relationcol] SET childcol = 'idepupbkind',lt = {ts '2017-05-20 09:19:47.847'},lu = 'lu' WHERE idrelation = '483' AND parentcol = 'idepupbkind'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('483','idepupbkind','idepupbkind',{ts '2017-05-20 09:19:47.847'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

