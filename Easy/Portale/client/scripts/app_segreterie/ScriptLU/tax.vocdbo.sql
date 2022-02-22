
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tax')
UPDATE [tabledescr] SET description = 'Tipi di ritenuta',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 17:43:00.850'},lu = 'assistenza',title = 'Tipi di ritenuta' WHERE tablename = 'tax'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tax','Tipi di ritenuta','3','S',{ts '2021-02-19 17:43:00.850'},'assistenza','Tipi di ritenuta')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.473'},lu = 'lu',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','tax','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.473'},'lu','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'appliancebasis' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Principio di applicazione: C Competenza - A Cassa Allargato - S Cassa',kind = 'S',lt = {ts '1900-01-01 03:00:24.070'},lu = 'lu',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'appliancebasis' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('appliancebasis','tax','1',null,null,'Principio di applicazione: C Competenza - A Cassa Allargato - S Cassa','S',{ts '1900-01-01 03:00:24.070'},'lu','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.470'},lu = 'lu',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tax','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.470'},'lu','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.903'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tax','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.903'},'lu','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:51.823'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','tax','50',null,null,'Descrizione','S',{ts '1900-01-01 02:59:51.823'},'lu','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fiscaltaxcode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice tributo/Causale contributo',kind = 'S',lt = {ts '1900-01-01 03:00:24.073'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'fiscaltaxcode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fiscaltaxcode','tax','20',null,null,'Codice tributo/Causale contributo','S',{ts '1900-01-01 03:00:24.073'},'lu','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagunabatable' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Ritenuta indetraibile',kind = 'C',lt = {ts '2016-02-07 11:10:49.143'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagunabatable' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagunabatable','tax','1',null,null,'Ritenuta indetraibile','C',{ts '2016-02-07 11:10:49.143'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'geoappliance' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tipo applicazione geografica: N Nulla- R Regionale - P Provinciale - C comunale',kind = 'S',lt = {ts '1900-01-01 02:59:11.967'},lu = 'lu',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'geoappliance' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('geoappliance','tax','1',null,null,'Tipo applicazione geografica: N Nulla- R Regionale - P Provinciale - C comunale','S',{ts '1900-01-01 02:59:11.967'},'lu','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive_cost' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale di Costo (tab. Accmotive)',kind = 'S',lt = {ts '1900-01-01 02:59:11.970'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive_cost' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive_cost','tax','36',null,null,'ID Causale di Costo (tab. Accmotive)','S',{ts '1900-01-01 02:59:11.970'},'lu','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive_debit' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale di Debito (tab. Accmotive)',kind = 'S',lt = {ts '1900-01-01 02:59:11.973'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive_debit' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive_debit','tax','36',null,null,'ID Causale di Debito (tab. Accmotive)','S',{ts '1900-01-01 02:59:11.973'},'lu','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive_pay' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale Liquidazione Ritenute (tab. Accmotive)',kind = 'S',lt = {ts '1900-01-01 02:59:11.977'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive_pay' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive_pay','tax','36',null,null,'ID Causale Liquidazione Ritenute (tab. Accmotive)','S',{ts '1900-01-01 02:59:11.977'},'lu','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'insuranceagencycode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Codice istituto previdenziale DALIA',kind = 'S',lt = {ts '2016-10-09 11:14:16.233'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'insuranceagencycode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('insuranceagencycode','tax','10',null,null,'Codice istituto previdenziale DALIA','S',{ts '2016-10-09 11:14:16.233'},'nino','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:43.277'},lu = 'lu',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tax','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:43.277'},'lu','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:40.307'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tax','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:40.307'},'lu','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'maintaxcode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID Ritenuta per Liquidazione (tab. Tax)',kind = 'S',lt = {ts '1900-01-01 02:59:11.987'},lu = 'lu',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'maintaxcode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('maintaxcode','tax','4',null,null,'ID Ritenuta per Liquidazione (tab. Tax)','S',{ts '1900-01-01 02:59:11.987'},'lu','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxablecode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Codice imponibile (tab . Taxablekind)',kind = 'S',lt = {ts '1900-01-01 03:00:27.693'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'taxablecode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxablecode','tax','20',null,null,'ID Codice imponibile (tab . Taxablekind)','S',{ts '1900-01-01 03:00:27.693'},'lu','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxcode' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id ritenuta (tabella tax)',kind = 'S',lt = {ts '1900-01-01 03:00:02.403'},lu = 'lu',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'taxcode' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxcode','tax','4',null,null,'id ritenuta (tabella tax)','S',{ts '1900-01-01 03:00:02.403'},'lu','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxkind' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Tipo ritenuta: 1 Fiscale- 2 Assistenziale - 3 Previdenziale - 4 Assicurativa - 5 Arretrati - 6 Altro',kind = 'C',lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'taxkind' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxkind','tax','2',null,null,'Tipo ritenuta: 1 Fiscale- 2 Assistenziale - 3 Previdenziale - 4 Assicurativa - 5 Arretrati - 6 Altro','C',{ts '2016-03-10 12:38:52.233'},'nino','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'taxref' AND tablename = 'tax')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'codice riferimento imposta (tabella tax)',kind = 'S',lt = {ts '1900-01-01 03:00:07.363'},lu = 'lu',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'taxref' AND tablename = 'tax'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('taxref','tax','20',null,null,'codice riferimento imposta (tabella tax)','S',{ts '1900-01-01 03:00:07.363'},'lu','N','varchar(20)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 11:10:49.143'},lu = 'Nino',title = 'Ritenuta detraibile' WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagunabatable','tax','N',null,{ts '2016-02-07 11:10:49.143'},'Nino','Ritenuta detraibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 11:10:49.143'},lu = 'Nino',title = 'Ritenuta indetraibile' WHERE colname = 'flagunabatable' AND tablename = 'tax' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagunabatable','tax','S',null,{ts '2016-02-07 11:10:49.143'},'Nino','Ritenuta indetraibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '1')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Fiscale' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '1'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','1',null,{ts '2016-03-10 12:38:52.233'},'nino','Fiscale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '2')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Assistenziale' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '2'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','2',null,{ts '2016-03-10 12:38:52.233'},'nino','Assistenziale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '3')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Previdenziale' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '3'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','3',null,{ts '2016-03-10 12:38:52.233'},'nino','Previdenziale')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '4')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Assicurativa' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '4'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','4',null,{ts '2016-03-10 12:38:52.233'},'nino','Assicurativa')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '5')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Arretrati' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '5'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','5',null,{ts '2016-03-10 12:38:52.233'},'nino','Arretrati')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '6')
UPDATE [colvalue] SET description = null,lt = {ts '2016-03-10 12:38:52.233'},lu = 'nino',title = 'Altro' WHERE colname = 'taxkind' AND tablename = 'tax' AND value = '6'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('taxkind','tax','6',null,{ts '2016-03-10 12:38:52.233'},'nino','Altro')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '73')
UPDATE [relation] SET childtable = 'tax',description = 'ID Causale di Costo (tab. Accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Tipi di ritenuta' WHERE idrelation = '73'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('73','tax','ID Causale di Costo (tab. Accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Tipi di ritenuta')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '74')
UPDATE [relation] SET childtable = 'tax',description = 'ID Causale di Debito (tab. Accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Tipi di ritenuta' WHERE idrelation = '74'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('74','tax','ID Causale di Debito (tab. Accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Tipi di ritenuta')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '75')
UPDATE [relation] SET childtable = 'tax',description = 'ID Causale Liquidazione Ritenute (tab. Accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Tipi di ritenuta' WHERE idrelation = '75'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('75','tax','ID Causale Liquidazione Ritenute (tab. Accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Tipi di ritenuta')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3136')
UPDATE [relation] SET childtable = 'tax',description = 'ID Codice imponibile (tab . Taxablekind)',lt = {ts '2017-05-22 15:32:06.610'},lu = 'nino',parenttable = 'taxablekind',title = 'Tipi di ritenuta' WHERE idrelation = '3136'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3136','tax','ID Codice imponibile (tab . Taxablekind)',{ts '2017-05-22 15:32:06.610'},'nino','taxablekind','Tipi di ritenuta')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '73' AND parentcol = 'idaccmotive')
UPDATE [relationcol] SET childcol = 'idaccmotive_cost',lt = {ts '2017-05-20 09:19:36.287'},lu = 'lu' WHERE idrelation = '73' AND parentcol = 'idaccmotive'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('73','idaccmotive','idaccmotive_cost',{ts '2017-05-20 09:19:36.287'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

