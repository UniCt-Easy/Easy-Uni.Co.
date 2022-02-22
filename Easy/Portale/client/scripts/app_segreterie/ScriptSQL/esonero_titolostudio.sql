
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


-- CREAZIONE TABELLA esonero_titolostudio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[esonero_titolostudio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[esonero_titolostudio] (
idesonero int NOT NULL,
conseguitoincorso char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
dataconstutticf date NULL,
datalaurea date NULL,
idstruttura int NULL,
lt datetime NULL,
lu varchar(64) NULL,
nellistituto char(1) NULL,
noabbr char(1) NULL,
noparttime char(1) NULL,
votomin int NULL,
 CONSTRAINT xpkesonero_titolostudio PRIMARY KEY (idesonero
)
)
END
GO

-- VERIFICA STRUTTURA esonero_titolostudio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'idesonero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD idesonero int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('esonero_titolostudio') and col.name = 'idesonero' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [esonero_titolostudio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'conseguitoincorso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD conseguitoincorso char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN conseguitoincorso char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'dataconstutticf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD dataconstutticf date NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN dataconstutticf date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'datalaurea' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD datalaurea date NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN datalaurea date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'nellistituto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD nellistituto char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN nellistituto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'noabbr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD noabbr char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN noabbr char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'noparttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD noparttime char(1) NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN noparttime char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'esonero_titolostudio' and C.name = 'votomin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [esonero_titolostudio] ADD votomin int NULL 
END
ELSE
	ALTER TABLE [esonero_titolostudio] ALTER COLUMN votomin int NULL
GO

-- VERIFICA DI esonero_titolostudio IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'esonero_titolostudio'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','esonero_titolostudio','int','ASSISTENZA','idesonero','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','char(1)','ASSISTENZA','conseguitoincorso','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','date','ASSISTENZA','dataconstutticf','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','date','ASSISTENZA','datalaurea','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','char(1)','ASSISTENZA','nellistituto','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','char(1)','ASSISTENZA','noabbr','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','char(1)','ASSISTENZA','noparttime','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','esonero_titolostudio','int','ASSISTENZA','votomin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI esonero_titolostudio IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'esonero_titolostudio')
UPDATE customobject set isreal = 'S' where objectname = 'esonero_titolostudio'
ELSE
INSERT INTO customobject (objectname, isreal) values('esonero_titolostudio', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'esonero_titolostudio')
UPDATE [tabledescr] SET description = 'Parte di 2.3.6 Esoneri
',idapplication = null,isdbo = 'N',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',title = 'Esonero per titolo di studio' WHERE tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('esonero_titolostudio','Parte di 2.3.6 Esoneri
',null,'N',{ts '2019-02-27 15:35:13.330'},'assistenza','Esonero per titolo di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'conseguitoincorso' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Conseguito in corso',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'conseguitoincorso' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('conseguitoincorso','esonero_titolostudio','1',null,null,'Conseguito in corso','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','esonero_titolostudio','8',null,null,null,'S',{ts '2018-07-27 17:59:17.057'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','esonero_titolostudio','64',null,null,null,'S',{ts '2018-07-27 17:59:17.057'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataconstutticf' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data limite per aver conseguito tutti i crediti formativi',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'dataconstutticf' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataconstutticf','esonero_titolostudio','3',null,null,'Data limite per aver conseguito tutti i crediti formativi','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datalaurea' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data limite di conseguimento del titolo',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datalaurea' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datalaurea','esonero_titolostudio','3',null,null,'Data limite di conseguimento del titolo','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idesonero' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.060'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idesonero' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idesonero','esonero_titolostudio','4',null,null,null,'S',{ts '2018-07-27 17:59:17.060'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica',kind = 'S',lt = {ts '2019-09-09 19:00:51.017'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','esonero_titolostudio','4',null,null,'Struttura didattica','S',{ts '2019-09-09 19:00:51.017'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','esonero_titolostudio','8',null,null,null,'S',{ts '2018-07-27 17:59:17.060'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 17:59:17.060'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','esonero_titolostudio','64',null,null,null,'S',{ts '2018-07-27 17:59:17.060'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nellistituto' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Solo per corsi dell''istituto',kind = 'S',lt = {ts '2019-02-27 15:35:13.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'nellistituto' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nellistituto','esonero_titolostudio','1',null,null,'Solo per corsi dell''istituto','S',{ts '2019-02-27 15:35:13.330'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'noabbr' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Senza abbreviazioni di carriera',kind = 'S',lt = {ts '2019-02-27 15:35:13.333'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'noabbr' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('noabbr','esonero_titolostudio','1',null,null,'Senza abbreviazioni di carriera','S',{ts '2019-02-27 15:35:13.333'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'noparttime' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Senza aver effettuato iscrizioni part-time',kind = 'S',lt = {ts '2019-02-27 15:35:13.333'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'noparttime' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('noparttime','esonero_titolostudio','1',null,null,'Senza aver effettuato iscrizioni part-time','S',{ts '2019-02-27 15:35:13.333'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'votomin' AND tablename = 'esonero_titolostudio')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voto minimo',kind = 'S',lt = {ts '2019-02-27 15:35:13.333'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'votomin' AND tablename = 'esonero_titolostudio'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('votomin','esonero_titolostudio','4',null,null,'Voto minimo','S',{ts '2019-02-27 15:35:13.333'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3415')
UPDATE [relation] SET childtable = 'esonero_titolostudio',description = 'dati di base dell''esonero',lt = {ts '2018-07-27 17:59:16.770'},lu = 'assistenza',parenttable = 'esonero_titolostudio',title = null WHERE idrelation = '3415'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3415','esonero_titolostudio','dati di base dell''esonero',{ts '2018-07-27 17:59:16.770'},'assistenza','esonero_titolostudio',null)
GO

-- FINE GENERAZIONE SCRIPT --

