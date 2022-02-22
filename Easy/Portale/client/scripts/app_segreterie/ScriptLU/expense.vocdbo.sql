
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'expense')
UPDATE [tabledescr] SET description = 'Movimento di spesa',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:28.813'},lu = 'nino',title = 'Movimento di spesa' WHERE tablename = 'expense'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('expense','Movimento di spesa','1','N',{ts '1900-01-01 03:00:28.813'},'nino','Movimento di spesa')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'adate' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data contabile',kind = 'S',lt = {ts '1900-01-01 02:59:52.837'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'adate' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('adate','expense','4',null,null,'data contabile','S',{ts '1900-01-01 02:59:52.837'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'autocode' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Automatismo',kind = 'S',lt = {ts '1900-01-01 02:59:19.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'autocode' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('autocode','expense','4',null,null,'Codice Automatismo','S',{ts '1900-01-01 02:59:19.197'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'autokind' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tipo automatismo, descritto in tabella autokind',kind = 'S',lt = {ts '2016-07-08 11:44:54.030'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'autokind' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('autokind','expense','1',null,null,'Tipo automatismo, descritto in tabella autokind','S',{ts '2016-07-08 11:44:54.030'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cigcode' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Codice CIG',kind = 'S',lt = {ts '1900-01-01 03:00:09.433'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cigcode' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cigcode','expense','10',null,null,'Codice CIG','S',{ts '1900-01-01 03:00:09.433'},'nino','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:46.980'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','expense','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:46.980'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.413'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','expense','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.413'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cupcode' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Codice CUP',kind = 'S',lt = {ts '1900-01-01 03:00:08.180'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cupcode' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cupcode','expense','15',null,null,'Codice CUP','S',{ts '1900-01-01 03:00:08.180'},'nino','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:50.860'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','expense','150',null,null,'Descrizione','S',{ts '1900-01-01 02:59:50.860'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'doc' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '35',col_precision = null,col_scale = null,description = 'documento',kind = 'S',lt = {ts '1900-01-01 02:59:56.717'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(35)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'doc' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('doc','expense','35',null,null,'documento','S',{ts '1900-01-01 02:59:56.717'},'nino','N','varchar(35)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'docdate' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data documento',kind = 'S',lt = {ts '1900-01-01 02:59:56.383'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'docdate' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('docdate','expense','4',null,null,'data documento','S',{ts '1900-01-01 02:59:56.383'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'expiration' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'scadenza',kind = 'S',lt = {ts '1900-01-01 03:00:03.703'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'expiration' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('expiration','expense','4',null,null,'scadenza','S',{ts '1900-01-01 03:00:03.703'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'external_reference' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Chiave esterna per db collegati',kind = 'S',lt = {ts '1900-01-01 03:00:25.153'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'external_reference' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('external_reference','expense','200',null,null,'Chiave esterna per db collegati','S',{ts '1900-01-01 03:00:25.153'},'nino','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclawback' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id recupero (tabella recupero)',kind = 'S',lt = {ts '1900-01-01 03:00:15.710'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclawback' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclawback','expense','4',null,null,'Id recupero (tabella recupero)','S',{ts '1900-01-01 03:00:15.710'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idexp' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id mov. spesa (tabella expense)',kind = 'S',lt = {ts '1900-01-01 02:59:19.350'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idexp' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idexp','expense','4',null,null,'id mov. spesa (tabella expense)','S',{ts '1900-01-01 02:59:19.350'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idformerexpense' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id economia di spesa (idexp di expense) associata qualora questo movimento. Questo movimento è valorizzato nella maschera ct_expenselast_reset (storno residui catania) e expense_wizardcreamovcompetenza (riemissione dei movimenti in competenza)',kind = 'S',lt = {ts '2016-10-07 09:05:09.993'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idformerexpense' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idformerexpense','expense','4',null,null,'id economia di spesa (idexp di expense) associata qualora questo movimento. Questo movimento è valorizzato nella maschera ct_expenselast_reset (storno residui catania) e expense_wizardcreamovcompetenza (riemissione dei movimenti in competenza)','S',{ts '2016-10-07 09:05:09.993'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idman' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id responsabile (tabella manager)',kind = 'S',lt = {ts '1900-01-01 02:59:21.810'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idman' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idman','expense','4',null,null,'id responsabile (tabella manager)','S',{ts '1900-01-01 02:59:21.810'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpayment' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id mov. spesa collegato (idexp di expense)',kind = 'S',lt = {ts '1900-01-01 03:00:05.943'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpayment' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpayment','expense','4',null,null,'id mov. spesa collegato (idexp di expense)','S',{ts '1900-01-01 03:00:05.943'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:52.110'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','expense','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:52.110'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.563'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','expense','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.563'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.597'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','expense','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.597'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nmov' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'N.movimento',kind = 'S',lt = {ts '1900-01-01 03:00:01.183'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nmov' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nmov','expense','4',null,null,'N.movimento','S',{ts '1900-01-01 03:00:01.183'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nphase' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'N.fase',kind = 'S',lt = {ts '1900-01-01 03:00:00.323'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'nphase' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nphase','expense','1',null,null,'N.fase','S',{ts '1900-01-01 03:00:00.323'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parentidexp' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id movimento padre (idexp di tabella expense)',kind = 'S',lt = {ts '1900-01-01 03:00:12.900'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'parentidexp' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parentidexp','expense','4',null,null,'id movimento padre (idexp di tabella expense)','S',{ts '1900-01-01 03:00:12.900'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.443'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','expense','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.443'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.107'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','expense','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.107'},'nino','N','text','text','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ymov' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Anno movimento',kind = 'S',lt = {ts '1900-01-01 03:00:00.943'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'ymov' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ymov','expense','2',null,null,'Anno movimento','S',{ts '1900-01-01 03:00:00.943'},'nino','N','smallint','smallint','System.Int16')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '361')
UPDATE [relation] SET childtable = 'expense',description = 'Id recupero (tabella recupero)',lt = {ts '2017-05-20 09:19:42.593'},lu = 'lu',parenttable = 'clawback',title = 'Movimento di spesa' WHERE idrelation = '361'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('361','expense','Id recupero (tabella recupero)',{ts '2017-05-20 09:19:42.593'},'lu','clawback','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '610')
UPDATE [relation] SET childtable = 'expense',description = 'N.fase',lt = {ts '2017-05-20 09:19:48.660'},lu = 'lu',parenttable = 'expensephase',title = 'Movimento di spesa' WHERE idrelation = '610'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('610','expense','N.fase',{ts '2017-05-20 09:19:48.660'},'lu','expensephase','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1152')
UPDATE [relation] SET childtable = 'expense',description = 'id responsabile (tabella manager)',lt = {ts '2017-05-20 09:19:59.413'},lu = 'lu',parenttable = 'manager',title = 'Movimento di spesa' WHERE idrelation = '1152'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1152','expense','id responsabile (tabella manager)',{ts '2017-05-20 09:19:59.413'},'lu','manager','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2065')
UPDATE [relation] SET childtable = 'expense',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:05.860'},lu = 'lu',parenttable = 'registry',title = 'Movimento di spesa' WHERE idrelation = '2065'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2065','expense','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:05.860'},'lu','registry','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2978')
UPDATE [relation] SET childtable = 'expense',description = 'id movimento padre (idexp di tabella expense)',lt = {ts '2017-05-21 20:46:40.413'},lu = 'nino',parenttable = 'expense',title = 'Movimento di spesa' WHERE idrelation = '2978'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2978','expense','id movimento padre (idexp di tabella expense)',{ts '2017-05-21 20:46:40.413'},'nino','expense','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3053')
UPDATE [relation] SET childtable = 'expense',description = 'id mov. spesa collegato (idexp di expense)',lt = {ts '2017-05-22 11:42:39.117'},lu = 'nino',parenttable = 'expense',title = null WHERE idrelation = '3053'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3053','expense','id mov. spesa collegato (idexp di expense)',{ts '2017-05-22 11:42:39.117'},'nino','expense',null)
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '361' AND parentcol = 'idclawback')
UPDATE [relationcol] SET childcol = 'idclawback',lt = {ts '2017-05-20 09:19:42.660'},lu = 'lu' WHERE idrelation = '361' AND parentcol = 'idclawback'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('361','idclawback','idclawback',{ts '2017-05-20 09:19:42.660'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

