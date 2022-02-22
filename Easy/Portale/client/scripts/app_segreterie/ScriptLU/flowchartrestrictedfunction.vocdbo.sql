
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'flowchartrestrictedfunction')
UPDATE [tabledescr] SET description = 'Restrizioni associate alla voce di organigramma',idapplication = '1',isdbo = 'N',lt = {ts '2017-05-20 14:56:28.520'},lu = 'nino',title = 'Restrizioni associate alla voce di organigramma' WHERE tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('flowchartrestrictedfunction','Restrizioni associate alla voce di organigramma','1','N',{ts '2017-05-20 14:56:28.520'},'nino','Restrizioni associate alla voce di organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:47.227'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','flowchartrestrictedfunction','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:47.227'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.660'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','flowchartrestrictedfunction','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.660'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idflowchart' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '34',col_precision = null,col_scale = null,description = 'Id della voce di organigramma (tabella flowchart)',kind = 'S',lt = {ts '1900-01-01 03:00:14.803'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(34)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idflowchart' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idflowchart','flowchartrestrictedfunction','34',null,null,'Id della voce di organigramma (tabella flowchart)','S',{ts '1900-01-01 03:00:14.803'},'nino','S','varchar(34)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrestrictedfunction' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID Operatività (tabella restrictedfunction)',kind = 'S',lt = {ts '1900-01-01 03:00:30.763'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrestrictedfunction' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrestrictedfunction','flowchartrestrictedfunction','4',null,null,'ID Operatività (tabella restrictedfunction)','S',{ts '1900-01-01 03:00:30.763'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.823'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','flowchartrestrictedfunction','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.823'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'flowchartrestrictedfunction')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.857'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'flowchartrestrictedfunction'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','flowchartrestrictedfunction','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.857'},'nino','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '813')
UPDATE [relation] SET childtable = 'flowchartrestrictedfunction',description = 'Id della voce di organigramma (tabella flowchart)',lt = {ts '2017-05-20 09:19:50.833'},lu = 'lu',parenttable = 'flowchart',title = 'Restrizioni associate alla voce di organigramma' WHERE idrelation = '813'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('813','flowchartrestrictedfunction','Id della voce di organigramma (tabella flowchart)',{ts '2017-05-20 09:19:50.833'},'lu','flowchart','Restrizioni associate alla voce di organigramma')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2147')
UPDATE [relation] SET childtable = 'flowchartrestrictedfunction',description = 'ID Operatività (tabella restrictedfunction)',lt = {ts '2017-05-20 09:20:07.207'},lu = 'lu',parenttable = 'restrictedfunction',title = 'Restrizioni associate alla voce di organigramma' WHERE idrelation = '2147'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2147','flowchartrestrictedfunction','ID Operatività (tabella restrictedfunction)',{ts '2017-05-20 09:20:07.207'},'lu','restrictedfunction','Restrizioni associate alla voce di organigramma')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '813' AND parentcol = 'idflowchart')
UPDATE [relationcol] SET childcol = 'idflowchart',lt = {ts '2017-05-20 09:19:50.900'},lu = 'lu' WHERE idrelation = '813' AND parentcol = 'idflowchart'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('813','idflowchart','idflowchart',{ts '2017-05-20 09:19:50.900'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

