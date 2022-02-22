
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


--[DBO]--
-- CREAZIONE TABELLA istitutokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istitutokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[istitutokind] (
idistitutokind int NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
tipoistituto varchar(256) NOT NULL,
tipoistitutoen varchar(256) NOT NULL,
tipoistitutosigla varchar(50) NOT NULL,
 CONSTRAINT xpkistitutokind PRIMARY KEY (idistitutokind
)
)
END
GO

-- VERIFICA STRUTTURA istitutokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'idistitutokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD idistitutokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'idistitutokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'tipoistituto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD tipoistituto varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'tipoistituto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN tipoistituto varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'tipoistitutoen' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD tipoistitutoen varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'tipoistitutoen' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN tipoistitutoen varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istitutokind' and C.name = 'tipoistitutosigla' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istitutokind] ADD tipoistitutosigla varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istitutokind') and col.name = 'tipoistitutosigla' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istitutokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istitutokind] ALTER COLUMN tipoistitutosigla varchar(50) NOT NULL
GO

-- VERIFICA DI istitutokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'istitutokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istitutokind','int','ASSISTENZA','idistitutokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istitutokind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','istitutokind','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istitutokind','varchar(256)','ASSISTENZA','tipoistituto','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istitutokind','varchar(256)','ASSISTENZA','tipoistitutoen','256','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','istitutokind','varchar(50)','ASSISTENZA','tipoistitutosigla','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI istitutokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'istitutokind')
UPDATE customobject set isreal = 'S' where objectname = 'istitutokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('istitutokind', 'S')
GO

-- GENERAZIONE DATI PER istitutokind --
IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '1')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Accademia di Belle Arti',tipoistitutoen = 'Academy of Fine Arts',tipoistitutosigla = 'ABA' WHERE idistitutokind = '1'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('1',{ts '2018-06-11 11:23:41.090'},'ferdinando','Accademia di Belle Arti','Academy of Fine Arts','ABA')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '2')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Accademia Nazionale di Arte Drammatica',tipoistitutoen = 'National Academy of Dramatic Art',tipoistitutosigla = 'ANAD' WHERE idistitutokind = '2'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('2',{ts '2018-06-11 11:23:41.090'},'ferdinando','Accademia Nazionale di Arte Drammatica','National Academy of Dramatic Art','ANAD')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '3')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Accademia Nazionale di Danza',tipoistitutoen = 'National Academy of Dance',tipoistitutosigla = 'AND' WHERE idistitutokind = '3'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('3',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Accademia Nazionale di Danza','National Academy of Dance','AND')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '4')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Conservatorio di Musica',tipoistitutoen = 'Music Conservatory',tipoistitutosigla = 'CON' WHERE idistitutokind = '4'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('4',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Conservatorio di Musica','Music Conservatory','CON')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '5')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Istituto Musicale Pareggiato',tipoistitutoen = 'higher music schools',tipoistitutosigla = 'IMP' WHERE idistitutokind = '5'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('5',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Istituto Musicale Pareggiato','higher music schools','IMP')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '6')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Istituto superiore per le Industrie Artistiche',tipoistitutoen = 'Higher Institute for Artistic Industries',tipoistitutosigla = 'ISIA' WHERE idistitutokind = '6'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('6',{ts '2018-06-11 11:23:41.090'},'ferdinando','Istituto superiore per le Industrie Artistiche','Higher Institute for Artistic Industries','ISIA')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '7')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Accademia Legalmente Riconosciuta',tipoistitutoen = 'Academy Legally Recognized',tipoistitutosigla = 'ALR' WHERE idistitutokind = '7'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('7',{ts '2018-06-11 11:23:41.090'},'ferdinando','Accademia Legalmente Riconosciuta','Academy Legally Recognized','ALR')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '8')
UPDATE [istitutokind] SET lt = {ts '2019-02-28 18:06:33.173'},lu = 'ASSISTENZA',tipoistituto = 'Istituzioni autorizzate a rilasciare titoli AFAM (art.11 DPR 8.7.2005 n.212)',tipoistitutoen = 'Institutions authorized to issue AFAM diplomas (art.11 DPR 8.7.2005 n.212)',tipoistitutosigla = 'Altr' WHERE idistitutokind = '8'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('8',{ts '2019-02-28 18:06:33.173'},'ASSISTENZA','Istituzioni autorizzate a rilasciare titoli AFAM (art.11 DPR 8.7.2005 n.212)','Institutions authorized to issue AFAM diplomas (art.11 DPR 8.7.2005 n.212)','Altr')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '9')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Università statale',tipoistitutoen = 'State University',tipoistitutosigla = 'US' WHERE idistitutokind = '9'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('9',{ts '2018-06-11 11:23:41.090'},'ferdinando','Università statale','State University','US')
GO

IF exists(SELECT * FROM [istitutokind] WHERE idistitutokind = '10')
UPDATE [istitutokind] SET lt = {ts '2018-06-11 11:23:41.090'},lu = 'ferdinando',tipoistituto = 'Università non statale',tipoistitutoen = 'Non-state University',tipoistitutosigla = 'UNS' WHERE idistitutokind = '10'
ELSE
INSERT INTO [istitutokind] (idistitutokind,lt,lu,tipoistituto,tipoistitutoen,tipoistitutosigla) VALUES ('10',{ts '2018-06-11 11:23:41.090'},'ferdinando','Università non statale','Non-state University','UNS')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'istitutokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO MIUR delle tipologie degli istituti di istruzione',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 10:42:28.297'},lu = 'assistenza',title = 'Tipologie degli istituti di istruzione' WHERE tablename = 'istitutokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('istitutokind','VOCABOLARIO MIUR delle tipologie degli istituti di istruzione',null,'N',{ts '2018-07-17 10:42:28.297'},'assistenza','Tipologie degli istituti di istruzione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idistitutokind' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 18:07:11.547'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idistitutokind' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idistitutokind','istitutokind','4',null,null,null,'S',{ts '2018-12-05 18:07:11.547'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 18:07:11.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','istitutokind','8',null,null,null,'S',{ts '2018-12-05 18:07:11.547'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-05 18:07:11.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','istitutokind','64',null,null,null,'S',{ts '2018-12-05 18:07:11.547'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tipoistituto' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-02-28 19:12:43.990'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tipoistituto' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tipoistituto','istitutokind','256',null,null,'Tipologia','S',{ts '2019-02-28 19:12:43.990'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tipoistitutoen' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Tipologia (EN)',kind = 'S',lt = {ts '2019-02-28 19:12:43.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tipoistitutoen' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tipoistitutoen','istitutokind','256',null,null,'Tipologia (EN)','S',{ts '2019-02-28 19:12:43.993'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tipoistitutosigla' AND tablename = 'istitutokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Sigla',kind = 'S',lt = {ts '2019-02-28 19:12:43.993'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tipoistitutosigla' AND tablename = 'istitutokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tipoistitutosigla','istitutokind','50',null,null,'Sigla','S',{ts '2019-02-28 19:12:43.993'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

