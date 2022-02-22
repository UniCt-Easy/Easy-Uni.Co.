
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'istattitolistudio')
UPDATE [tabledescr] SET description = 'VOCABOLARIO classificazione ISTAT dei 2.6.5 titoli di studio',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-17 10:52:01.330'},lu = 'assistenza',title = 'Cllassificazione ISTAT dei titoli di studio' WHERE tablename = 'istattitolistudio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('istattitolistudio','VOCABOLARIO classificazione ISTAT dei 2.6.5 titoli di studio','2','S',{ts '2018-07-17 10:52:01.330'},'assistenza','Cllassificazione ISTAT dei titoli di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceistitutogruppo' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Codice tipo di scuola/istituto, gruppo di corsi accademici',kind = 'S',lt = {ts '2019-03-08 16:24:47.737'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(3)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceistitutogruppo' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceistitutogruppo','istattitolistudio','3',null,null,'Codice tipo di scuola/istituto, gruppo di corsi accademici','S',{ts '2019-03-08 16:24:47.737'},'assistenza','N','varchar(3)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicelivello' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice livello',kind = 'S',lt = {ts '2019-03-08 16:24:47.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'codicelivello' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicelivello','istattitolistudio','4',null,null,'Codice livello','S',{ts '2019-03-08 16:24:47.747'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicespecializcorso' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Codice specializzazione scolastica/post-scolastica, corso accademico',kind = 'S',lt = {ts '2019-03-08 16:24:47.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(3)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicespecializcorso' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicespecializcorso','istattitolistudio','3',null,null,'Codice specializzazione scolastica/post-scolastica, corso accademico','S',{ts '2019-03-08 16:24:47.747'},'assistenza','N','varchar(3)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistattitolistudio' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2019-03-08 16:24:47.747'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistattitolistudio' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistattitolistudio','istattitolistudio','4',null,null,'Codice','S',{ts '2019-03-08 16:24:47.747'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'isced97field' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ISCED 97 - Field of study',kind = 'S',lt = {ts '2019-03-08 16:24:47.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'isced97field' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('isced97field','istattitolistudio','50',null,null,'ISCED 97 - Field of study','S',{ts '2019-03-08 16:24:47.747'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'isced97level' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ISCED 97 - Level and program destination',kind = 'S',lt = {ts '2019-03-08 16:24:47.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'isced97level' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('isced97level','istattitolistudio','50',null,null,'ISCED 97 - Level and program destination','S',{ts '2019-03-08 16:24:47.747'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-03-08 16:24:52.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','istattitolistudio','8',null,null,null,'S',{ts '2019-03-08 16:24:52.063'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-03-08 16:24:52.067'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','istattitolistudio','64',null,null,null,'S',{ts '2019-03-08 16:24:52.067'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sinonimi' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:52:05.803'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'sinonimi' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sinonimi','istattitolistudio','1024',null,null,null,'S',{ts '2018-07-17 10:52:05.803'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tipo' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Tipo di scuola/istituto, Corso/classe di corsi accademici',kind = 'S',lt = {ts '2019-03-08 16:24:47.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tipo' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tipo','istattitolistudio','1024',null,null,'Tipo di scuola/istituto, Corso/classe di corsi accademici','S',{ts '2019-03-08 16:24:47.747'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolo' AND tablename = 'istattitolistudio')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Titolo di studio',kind = 'S',lt = {ts '2019-03-08 16:24:47.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'titolo' AND tablename = 'istattitolistudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolo','istattitolistudio','1024',null,null,'Titolo di studio','S',{ts '2019-03-08 16:24:47.747'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3191')
UPDATE [relation] SET childtable = 'istattitolistudio',description = 'Classificazione ISTAT del titolo di studio',lt = {ts '2018-07-17 11:04:13.257'},lu = 'assistenza',parenttable = 'titolostudio',title = 'istattitolistudio' WHERE idrelation = '3191'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3191','istattitolistudio','Classificazione ISTAT del titolo di studio',{ts '2018-07-17 11:04:13.257'},'assistenza','titolostudio','istattitolistudio')
GO

-- FINE GENERAZIONE SCRIPT --

