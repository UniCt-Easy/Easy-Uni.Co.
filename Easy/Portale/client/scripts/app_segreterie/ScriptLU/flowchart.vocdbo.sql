
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'flowchart')
UPDATE [tabledescr] SET description = 'Organigramma',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:28.857'},lu = 'nino',title = 'Organigramma' WHERE tablename = 'flowchart'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('flowchart','Organigramma','1','N',{ts '1900-01-01 03:00:28.857'},'nino','Organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'address' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'n. operazione',kind = 'S',lt = {ts '1900-01-01 03:00:15.020'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'address' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('address','flowchart','100',null,null,'n. operazione','S',{ts '1900-01-01 03:00:15.020'},'nino','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ayear' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'esercizio',kind = 'S',lt = {ts '1900-01-01 02:59:22.607'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ayear' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ayear','flowchart','4',null,null,'esercizio','S',{ts '1900-01-01 02:59:22.607'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cap' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice avv. postale',kind = 'S',lt = {ts '1900-01-01 03:00:09.837'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cap' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cap','flowchart','20',null,null,'Codice avv. postale','S',{ts '1900-01-01 03:00:09.837'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codeflowchart' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '1900-01-01 03:00:17.200'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codeflowchart' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codeflowchart','flowchart','50',null,null,'Codice','S',{ts '1900-01-01 03:00:17.200'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:47.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','flowchart','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:47.197'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.630'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','flowchart','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.630'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'fax' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '75',col_precision = null,col_scale = null,description = 'Fax',kind = 'S',lt = {ts '1900-01-01 03:00:20.113'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(75)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'fax' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('fax','flowchart','75',null,null,'Fax','S',{ts '1900-01-01 03:00:20.113'},'nino','N','varchar(75)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id città (tabella geo_city)',kind = 'S',lt = {ts '1900-01-01 03:00:02.167'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','flowchart','4',null,null,'id città (tabella geo_city)','S',{ts '1900-01-01 03:00:02.167'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idflowchart' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '34',col_precision = null,col_scale = null,description = 'Id della voce di organigramma (tabella flowchart)',kind = 'S',lt = {ts '1900-01-01 03:00:14.767'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(34)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idflowchart' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idflowchart','flowchart','34',null,null,'Id della voce di organigramma (tabella flowchart)','S',{ts '1900-01-01 03:00:14.767'},'nino','S','varchar(34)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor1' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 1(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:26.140'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor1' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor1','flowchart','4',null,null,'id voce analitica 1(tabella sorting)','S',{ts '1900-01-01 02:59:26.140'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor2' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 2(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:26.297'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor2' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor2','flowchart','4',null,null,'id voce analitica 2(tabella sorting)','S',{ts '1900-01-01 02:59:26.297'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor3' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 3(tabella sorting)',kind = 'S',lt = {ts '1900-01-01 02:59:26.453'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor3' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor3','flowchart','4',null,null,'id voce analitica 3(tabella sorting)','S',{ts '1900-01-01 02:59:26.453'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ubicazione',kind = 'S',lt = {ts '1900-01-01 03:00:11.380'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','flowchart','50',null,null,'ubicazione','S',{ts '1900-01-01 03:00:11.380'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.783'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','flowchart','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.783'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.817'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','flowchart','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.817'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nlevel' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'N. livello',kind = 'S',lt = {ts '1900-01-01 02:59:21.533'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nlevel' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nlevel','flowchart','4',null,null,'N. livello','S',{ts '1900-01-01 02:59:21.533'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridflowchart' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '34',col_precision = null,col_scale = null,description = 'chiave parent Organigramma (tabella flowchart) ',kind = 'S',lt = {ts '1900-01-01 02:58:35.177'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(34)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'paridflowchart' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridflowchart','flowchart','34',null,null,'chiave parent Organigramma (tabella flowchart) ','S',{ts '1900-01-01 02:58:35.177'},'nino','N','varchar(34)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'phone' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '55',col_precision = null,col_scale = null,description = 'Tel.',kind = 'S',lt = {ts '1900-01-01 03:00:20.117'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(55)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'phone' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('phone','flowchart','55',null,null,'Tel.','S',{ts '1900-01-01 03:00:20.117'},'nino','N','varchar(55)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'printingorder' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Ordine di stampa',kind = 'S',lt = {ts '1900-01-01 03:00:09.157'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'printingorder' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('printingorder','flowchart','50',null,null,'Ordine di stampa','S',{ts '1900-01-01 03:00:09.157'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'flowchart')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '1900-01-01 03:00:00.050'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'flowchart'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','flowchart','150',null,null,'Denominazione','S',{ts '1900-01-01 03:00:00.050'},'nino','N','varchar(150)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '844')
UPDATE [relation] SET childtable = 'flowchart',description = 'Codice avv. postale',lt = {ts '2017-05-20 09:19:52.217'},lu = 'lu',parenttable = 'geo_cap',title = 'Organigramma' WHERE idrelation = '844'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('844','flowchart','Codice avv. postale',{ts '2017-05-20 09:19:52.217'},'lu','geo_cap','Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '860')
UPDATE [relation] SET childtable = 'flowchart',description = 'id città (tabella geo_city)',lt = {ts '2017-05-20 09:19:52.420'},lu = 'lu',parenttable = 'geo_city',title = 'Organigramma' WHERE idrelation = '860'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('860','flowchart','id città (tabella geo_city)',{ts '2017-05-20 09:19:52.420'},'lu','geo_city','Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2321')
UPDATE [relation] SET childtable = 'flowchart',description = 'id voce analitica 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Organigramma' WHERE idrelation = '2321'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2321','flowchart','id voce analitica 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2322')
UPDATE [relation] SET childtable = 'flowchart',description = 'id voce analitica 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Organigramma' WHERE idrelation = '2322'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2322','flowchart','id voce analitica 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2323')
UPDATE [relation] SET childtable = 'flowchart',description = 'id voce analitica 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Organigramma' WHERE idrelation = '2323'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2323','flowchart','id voce analitica 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3062')
UPDATE [relation] SET childtable = 'flowchart',description = 'chiave parent Organigramma (tabella flowchart) ',lt = {ts '2017-05-22 11:50:50.303'},lu = 'nino',parenttable = 'flowchart',title = 'Organigramma' WHERE idrelation = '3062'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3062','flowchart','chiave parent Organigramma (tabella flowchart) ',{ts '2017-05-22 11:50:50.303'},'nino','flowchart','Organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3063')
UPDATE [relation] SET childtable = 'flowchart',description = 'esercizio',lt = {ts '2017-05-22 11:51:13.193'},lu = 'nino',parenttable = 'flowchartlevel',title = 'Organigramma' WHERE idrelation = '3063'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3063','flowchart','esercizio',{ts '2017-05-22 11:51:13.193'},'nino','flowchartlevel','Organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '844' AND parentcol = 'cap')
UPDATE [relationcol] SET childcol = 'cap',lt = {ts '2017-05-20 09:19:52.360'},lu = 'lu' WHERE idrelation = '844' AND parentcol = 'cap'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('844','cap','cap',{ts '2017-05-20 09:19:52.360'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

