
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudio')
UPDATE [tabledescr] SET description = '2.4.2 Corso di studio',idapplication = '3',isdbo = 'S',lt = {ts '2021-02-19 12:55:08.087'},lu = 'assistenza',title = 'Corso di studio' WHERE tablename = 'corsostudio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudio','2.4.2 Corso di studio','3','S',{ts '2021-02-19 12:55:08.087'},'assistenza','Corso di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'almalaureasurvey' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Questionario Almalaurea',kind = 'S',lt = {ts '2019-02-26 11:04:21.630'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'almalaureasurvey' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('almalaureasurvey','corsostudio','1',null,null,'Questionario Almalaurea','S',{ts '2019-02-26 11:04:21.630'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annoistituz' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno accademico di istituzione',kind = 'S',lt = {ts '2019-02-26 11:03:36.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annoistituz' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annoistituz','corsostudio','4',null,null,'Anno accademico di istituzione','S',{ts '2019-02-26 11:03:36.100'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'basevoto' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Base del voto di conseguimento',kind = 'S',lt = {ts '2019-02-26 11:03:36.100'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'basevoto' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('basevoto','corsostudio','4',null,null,'Base del voto di conseguimento','S',{ts '2019-02-26 11:03:36.100'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 10:57:10.400'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','corsostudio','50',null,null,null,'S',{ts '2019-02-26 10:57:10.400'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicemiur' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Codice MIUR',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicemiur' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicemiur','corsostudio','10',null,null,'Codice MIUR','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicemiurlungo' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice MIUR lungo',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicemiurlungo' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicemiurlungo','corsostudio','50',null,null,'Codice MIUR lungo','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'crediti' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:14:57.660'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'crediti' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('crediti','corsostudio','4',null,null,null,'S',{ts '2018-07-18 16:14:57.660'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:14:57.660'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','corsostudio','8',null,null,null,'S',{ts '2018-07-18 16:14:57.660'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:14:57.660'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','corsostudio','64',null,null,null,'S',{ts '2018-07-18 16:14:57.660'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'durata' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:14:57.660'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'durata' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('durata','corsostudio','4',null,null,null,'S',{ts '2018-07-18 16:14:57.660'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:14:57.660'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','corsostudio','4',null,null,null,'S',{ts '2018-07-18 16:14:57.660'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','corsostudio','4',null,null,'Tipologia','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Livello',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiolivello','corsostudio','4',null,null,'Livello','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudionorma' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Normativa di riferimento',kind = 'S',lt = {ts '2019-03-18 16:12:16.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudionorma' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudionorma','corsostudio','4',null,null,'Normativa di riferimento','S',{ts '2019-03-18 16:12:16.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idduratakind' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia della durata',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idduratakind' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idduratakind','corsostudio','4',null,null,'Tipologia della durata','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di riferimento',kind = 'S',lt = {ts '2019-09-09 18:42:56.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','corsostudio','4',null,null,'Struttura di riferimento','S',{ts '2019-09-09 18:42:56.607'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:14:57.660'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudio','8',null,null,null,'S',{ts '2018-07-18 16:14:57.660'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:14:57.660'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudio','64',null,null,null,'S',{ts '2018-07-18 16:14:57.660'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obbform' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Obiettivi formativi',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'obbform' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obbform','corsostudio','0',null,null,'Obiettivi formativi','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sboccocc' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Sbocchi occupazionali',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'sboccocc' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sboccocc','corsostudio','0',null,null,'Sbocchi occupazionali','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','corsostudio','1024',null,null,'Denominazione','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'corsostudio')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione (EN)',kind = 'S',lt = {ts '2019-02-26 11:03:36.103'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'corsostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','corsostudio','1024',null,null,'Denominazione (EN)','S',{ts '2019-02-26 11:03:36.103'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudiokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO modificabile da loro delle tipologie dei  2.4.2 Corso di studio ',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:24:39.123'},lu = 'assistenza',title = 'Tipologie dei corsi di studio' WHERE tablename = 'corsostudiokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudiokind','VOCABOLARIO modificabile da loro delle tipologie dei  2.4.2 Corso di studio ',null,'N',{ts '2018-07-20 11:24:39.123'},'assistenza','Tipologie dei corsi di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','corsostudiokind','1',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','corsostudiokind','8',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','corsostudiokind','64',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','corsostudiokind','256',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','corsostudiokind','4',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudiokind','8',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudiokind','64',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','corsostudiokind','4',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'corsostudiokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:20:57.380'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','corsostudiokind','50',null,null,null,'S',{ts '2018-07-18 16:20:57.380'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3236')
UPDATE [relation] SET childtable = 'corsostudiokind',description = 'corso di studio di cui descrive il tipo',lt = {ts '2018-07-18 16:21:21.127'},lu = 'assistenza',parenttable = 'corsostudio',title = null WHERE idrelation = '3236'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3236','corsostudiokind','corso di studio di cui descrive il tipo',{ts '2018-07-18 16:21:21.127'},'assistenza','corsostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudiolivello')
UPDATE [tabledescr] SET description = 'VOCABOLARIO dei livelli dei  2.4.2 Corso di studio ',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 11:25:03.270'},lu = 'assistenza',title = 'Livelli dei corsi di studio' WHERE tablename = 'corsostudiolivello'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudiolivello','VOCABOLARIO dei livelli dei  2.4.2 Corso di studio ',null,'N',{ts '2018-07-20 11:25:03.270'},'assistenza','Livelli dei corsi di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia del corso di studi',kind = 'S',lt = {ts '2019-09-05 11:33:32.520'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiokind' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiokind','corsostudiolivello','4',null,null,'Tipologia del corso di studi','S',{ts '2019-09-05 11:33:32.520'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-09-05 11:33:55.317'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudiolivello' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudiolivello','corsostudiolivello','4',null,null,'Identificativo','S',{ts '2019-09-05 11:33:55.317'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:22:10.800'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudiolivello','8',null,null,null,'S',{ts '2018-07-18 16:22:10.800'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:22:10.800'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudiolivello','64',null,null,null,'S',{ts '2018-07-18 16:22:10.800'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'corsostudiolivello')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Livello',kind = 'S',lt = {ts '2019-09-05 11:33:55.317'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','corsostudiolivello','50',null,null,'Livello','S',{ts '2019-09-05 11:33:55.317'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3237')
UPDATE [relation] SET childtable = 'corsostudiolivello',description = 'corso di studio di cui descrive il livello',lt = {ts '2018-07-18 16:22:39.727'},lu = 'assistenza',parenttable = 'corsostudio',title = null WHERE idrelation = '3237'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3237','corsostudiolivello','corso di studio di cui descrive il livello',{ts '2018-07-18 16:22:39.727'},'assistenza','corsostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudionorma')
UPDATE [tabledescr] SET description = 'VOCABOLARIO delle normative dei 2.4.2 Corso di studio ',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 12:13:59.050'},lu = 'assistenza',title = 'Normative dei corsi di studio ' WHERE tablename = 'corsostudionorma'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudionorma','VOCABOLARIO delle normative dei 2.4.2 Corso di studio ',null,'N',{ts '2018-07-20 12:13:59.050'},'assistenza','Normative dei corsi di studio ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudionorma' AND tablename = 'corsostudionorma')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:58:49.367'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudionorma' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudionorma','corsostudionorma','4',null,null,null,'S',{ts '2018-07-18 16:58:49.367'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistitutokind' AND tablename = 'corsostudionorma')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia di corsi',kind = 'S',lt = {ts '2019-03-18 16:14:54.737'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistitutokind' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistitutokind','corsostudionorma','4',null,null,'Tipologia di corsi','S',{ts '2019-03-18 16:14:54.737'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'corsostudionorma')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:58:49.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','corsostudionorma','8',null,null,null,'S',{ts '2018-07-18 16:58:49.367'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'corsostudionorma')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-18 16:58:49.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','corsostudionorma','64',null,null,null,'S',{ts '2018-07-18 16:58:49.367'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'corsostudionorma')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2018-12-05 17:34:45.573'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','corsostudionorma','50',null,null,'Denominazione','S',{ts '2018-12-05 17:34:45.573'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3238')
UPDATE [relation] SET childtable = 'corsostudionorma',description = 'orso di studio di cui descrive la norma',lt = {ts '2018-07-18 16:59:32.087'},lu = 'assistenza',parenttable = 'corsostudio',title = null WHERE idrelation = '3238'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3238','corsostudionorma','orso di studio di cui descrive la norma',{ts '2018-07-18 16:59:32.087'},'assistenza','corsostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --

