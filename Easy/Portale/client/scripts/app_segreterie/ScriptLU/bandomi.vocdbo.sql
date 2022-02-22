
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
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'bandomi')
UPDATE [tabledescr] SET description = '2.5.15 Bandi per la mobilità internazionale',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 11:07:11.753'},lu = 'assistenza',title = 'Bandi per la mobilità internazionale' WHERE tablename = 'bandomi'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('bandomi','2.5.15 Bandi per la mobilità internazionale',null,'N',{ts '2018-07-27 11:07:11.753'},'assistenza','Bandi per la mobilità internazionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno Accademico',kind = 'S',lt = {ts '2021-06-28 11:38:20.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(9)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','bandomi','9',null,null,'Anno Accademico','S',{ts '2021-06-28 11:38:20.610'},'assistenza','N','nvarchar(9)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfminimi' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti formativi minimi per l''accesso',kind = 'S',lt = {ts '2019-02-26 11:24:35.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfminimi' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfminimi','bandomi','5','9','2','Crediti formativi minimi per l''accesso','S',{ts '2019-02-26 11:24:35.843'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice identificativo',kind = 'S',lt = {ts '2020-09-07 12:19:11.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','bandomi','50',null,null,'Codice identificativo','S',{ts '2020-09-07 12:19:11.053'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','bandomi','8',null,null,null,'S',{ts '2019-02-26 11:24:37.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','bandomi','64',null,null,null,'S',{ts '2019-02-26 11:24:37.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datariferimentorequisiti' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di riferimento per il calcolo dei requisiti',kind = 'S',lt = {ts '2019-02-26 11:24:35.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datariferimentorequisiti' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datariferimentorequisiti','bandomi','3',null,null,'Data di riferimento per il calcolo dei requisiti','S',{ts '2019-02-26 11:24:35.843'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'durata' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:07:13.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'durata' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('durata','bandomi','4',null,null,null,'S',{ts '2018-07-27 11:07:13.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomi' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Accordo di scambio per la mobilità internazionale',kind = 'S',lt = {ts '2019-11-28 16:49:48.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomi' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomi','bandomi','4',null,null,'Accordo di scambio per la mobilità internazionale','S',{ts '2019-11-28 16:49:48.917'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassicurazione' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Assicurazione',kind = 'S',lt = {ts '2019-02-26 12:42:34.307'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassicurazione' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassicurazione','bandomi','4',null,null,'Assicurazione','S',{ts '2019-02-26 12:42:34.307'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomi' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:07:13.613'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomi' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomi','bandomi','4',null,null,null,'S',{ts '2018-07-27 11:07:13.613'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomobilitaintkind' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-02-26 11:24:35.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomobilitaintkind' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomobilitaintkind','bandomi','4',null,null,'Tipologia','S',{ts '2019-02-26 11:24:35.843'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idduratakind' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Durata',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idduratakind' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idduratakind','bandomi','4',null,null,'Durata','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoria' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Graduatoria',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoria' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoria','bandomi','4',null,null,'Graduatoria','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogrammami' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Programma per la mobilità di riferimento',kind = 'S',lt = {ts '2020-09-07 17:29:00.220'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogrammami' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogrammami','bandomi','4',null,null,'Programma per la mobilità di riferimento','S',{ts '2020-09-07 17:29:00.220'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idresidence' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Residenza',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idresidence' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idresidence','bandomi','4',null,null,'Residenza','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di riferimento',kind = 'S',lt = {ts '2021-06-28 11:38:20.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','bandomi','4',null,null,'Struttura di riferimento','S',{ts '2021-06-28 11:38:20.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iduratakind' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di durata',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iduratakind' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iduratakind','bandomi','4',null,null,'Tipo di durata','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iscrittonellanno' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Solo per iscritti nell''anno',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'iscrittonellanno' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iscrittonellanno','bandomi','1',null,null,'Solo per iscritti nell''anno','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','bandomi','8',null,null,null,'S',{ts '2019-02-26 11:24:37.083'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','bandomi','64',null,null,null,'S',{ts '2019-02-26 11:24:37.083'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'maxpreferenze' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero massimo di preferenze',kind = 'S',lt = {ts '2019-02-26 12:49:31.170'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'maxpreferenze' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('maxpreferenze','bandomi','4',null,null,'Numero massimo di preferenze','S',{ts '2019-02-26 12:49:31.170'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'mediaminima' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Mendia minima',kind = 'S',lt = {ts '2019-02-26 12:49:31.170'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'mediaminima' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('mediaminima','bandomi','5','9','2','Mendia minima','S',{ts '2019-02-26 12:49:31.170'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nessundebito' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Nessun debito formativo',kind = 'S',lt = {ts '2019-02-26 12:49:31.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'nessundebito' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nessundebito','bandomi','1',null,null,'Nessun debito formativo','S',{ts '2019-02-26 12:49:31.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numeroesamiminimo' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero minimo di esami',kind = 'S',lt = {ts '2019-02-26 12:49:31.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numeroesamiminimo' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numeroesamiminimo','bandomi','4',null,null,'Numero minimo di esami','S',{ts '2019-02-26 12:49:31.173'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startcandidature' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio delle candidature',kind = 'S',lt = {ts '2019-02-26 12:49:31.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'startcandidature' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startcandidature','bandomi','8',null,null,'Data di inizio delle candidature','S',{ts '2019-02-26 12:49:31.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startgraduatoria' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio della graduatoria',kind = 'S',lt = {ts '2019-02-26 12:49:31.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'startgraduatoria' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startgraduatoria','bandomi','8',null,null,'Data di inizio della graduatoria','S',{ts '2019-02-26 12:49:31.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startpermanenza' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio del periodo all''estero',kind = 'S',lt = {ts '2019-02-26 12:49:31.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'startpermanenza' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startpermanenza','bandomi','3',null,null,'Data di inizio del periodo all''estero','S',{ts '2019-02-26 12:49:31.177'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startpresentazione' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio delle presentazioni dei Learning Agreement',kind = 'S',lt = {ts '2019-02-26 12:49:31.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'startpresentazione' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startpresentazione','bandomi','8',null,null,'Data di inizio delle presentazioni dei Learning Agreement','S',{ts '2019-02-26 12:49:31.180'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stopcadidature' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di fine di presentazione delle candidature',kind = 'S',lt = {ts '2019-02-26 12:49:31.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stopcadidature' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stopcadidature','bandomi','8',null,null,'Data di fine di presentazione delle candidature','S',{ts '2019-02-26 12:49:31.180'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stopgraduatoria' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di fine della graduatoria',kind = 'S',lt = {ts '2019-02-26 12:49:31.183'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stopgraduatoria' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stopgraduatoria','bandomi','8',null,null,'Data di fine della graduatoria','S',{ts '2019-02-26 12:49:31.183'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stoppermanenza' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine di permanenza all''estero',kind = 'S',lt = {ts '2019-02-26 12:49:31.183'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stoppermanenza' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stoppermanenza','bandomi','3',null,null,'Data di fine di permanenza all''estero','S',{ts '2019-02-26 12:49:31.183'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stoppresentazione' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di fine delle presentazioni dei Learning Agreement',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stoppresentazione' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stoppresentazione','bandomi','8',null,null,'Data di fine delle presentazioni dei Learning Agreement','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'testodomanda' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Testo della intestazione della domanda di ammissione',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'testodomanda' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('testodomanda','bandomi','-1',null,null,'Testo della intestazione della domanda di ammissione','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo del bando',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','bandomi','-1',null,null,'Titolo del bando','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolodomanda' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo della domanda di ammissione',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'titolodomanda' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolodomanda','bandomi','-1',null,null,'Titolo della domanda di ammissione','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

