
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
-- CREAZIONE TABELLA tassaiscrizioneconf --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tassaiscrizioneconf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tassaiscrizioneconf] (
idtassaiscrizioneconf int NOT NULL,
aa varchar(9) NOT NULL,
aamax varchar(9) NULL,
aamin varchar(9) NULL,
annofcmax int NULL,
annofcmin int NULL,
annomax int NULL,
annomin int NULL,
codice_corsostudio varchar(50) NULL,
codice_didprog varchar(50) NULL,
codice_didprogcurr varchar(50) NULL,
codice_didprogori varchar(50) NULL,
corsisingoli char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idcostoscontodef int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(2024) NOT NULL,
 CONSTRAINT xpktassaiscrizioneconf PRIMARY KEY (idtassaiscrizioneconf
)
)
END
GO

-- VERIFICA STRUTTURA tassaiscrizioneconf --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'idtassaiscrizioneconf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD idtassaiscrizioneconf int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'idtassaiscrizioneconf' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD aa varchar(9) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN aa varchar(9) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'aamax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD aamax varchar(9) NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN aamax varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'aamin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD aamin varchar(9) NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN aamin varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'annofcmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD annofcmax int NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN annofcmax int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'annofcmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD annofcmin int NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN annofcmin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'annomax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD annomax int NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN annomax int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'annomin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD annomin int NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN annomin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'codice_corsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD codice_corsostudio varchar(50) NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN codice_corsostudio varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'codice_didprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD codice_didprog varchar(50) NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN codice_didprog varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'codice_didprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD codice_didprogcurr varchar(50) NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN codice_didprogcurr varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'codice_didprogori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD codice_didprogori varchar(50) NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN codice_didprogori varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'corsisingoli' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD corsisingoli char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'corsisingoli' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN corsisingoli char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'idcostoscontodef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD idcostoscontodef int NULL 
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN idcostoscontodef int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tassaiscrizioneconf' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tassaiscrizioneconf] ADD title varchar(2024) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tassaiscrizioneconf') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tassaiscrizioneconf] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tassaiscrizioneconf] ALTER COLUMN title varchar(2024) NOT NULL
GO

-- VERIFICA DI tassaiscrizioneconf IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tassaiscrizioneconf'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','int','ASSISTENZA','idtassaiscrizioneconf','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','varchar(9)','ASSISTENZA','aamax','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','varchar(9)','ASSISTENZA','aamin','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','int','ASSISTENZA','annofcmax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','int','ASSISTENZA','annofcmin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','int','ASSISTENZA','annomax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','int','ASSISTENZA','annomin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','varchar(50)','ASSISTENZA','codice_corsostudio','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','varchar(50)','ASSISTENZA','codice_didprog','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','varchar(50)','ASSISTENZA','codice_didprogcurr','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','varchar(50)','ASSISTENZA','codice_didprogori','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','char(1)','ASSISTENZA','corsisingoli','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tassaiscrizioneconf','int','ASSISTENZA','idcostoscontodef','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tassaiscrizioneconf','varchar(2024)','ASSISTENZA','title','2024','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tassaiscrizioneconf IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tassaiscrizioneconf')
UPDATE customobject set isreal = 'S' where objectname = 'tassaiscrizioneconf'
ELSE
INSERT INTO customobject (objectname, isreal) values('tassaiscrizioneconf', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tassaiscrizioneconf')
UPDATE [tabledescr] SET description = '3.4.9 Configurazione delle tasse 3.4.9.1 Inserimento per le iscrizioni 
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 17:43:21.533'},lu = 'assistenza',title = 'Configurazione delle tasse -Inserimento per le iscrizioni ' WHERE tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tassaiscrizioneconf','3.4.9 Configurazione delle tasse 3.4.9.1 Inserimento per le iscrizioni 
',null,'N',{ts '2018-07-27 17:43:21.533'},'assistenza','Configurazione delle tasse -Inserimento per le iscrizioni ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2019-11-29 10:35:16.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','tassaiscrizioneconf','9',null,null,'Anno accademico','S',{ts '2019-11-29 10:35:16.370'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'aamax' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico massimo',kind = 'S',lt = {ts '2019-11-29 10:35:16.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aamax' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aamax','tassaiscrizioneconf','9',null,null,'Anno accademico massimo','S',{ts '2019-11-29 10:35:16.370'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'aamin' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico minimo',kind = 'S',lt = {ts '2019-11-29 10:35:16.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aamin' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aamin','tassaiscrizioneconf','9',null,null,'Anno accademico minimo','S',{ts '2019-11-29 10:35:16.370'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annofcmax' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di iscrizione fuori corso massimo',kind = 'S',lt = {ts '2019-11-29 10:35:16.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annofcmax' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annofcmax','tassaiscrizioneconf','4',null,null,'Anno di iscrizione fuori corso massimo','S',{ts '2019-11-29 10:35:16.370'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annofcmin' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di iscrizione fuori corso minimo',kind = 'S',lt = {ts '2019-11-29 10:35:16.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annofcmin' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annofcmin','tassaiscrizioneconf','4',null,null,'Anno di iscrizione fuori corso minimo','S',{ts '2019-11-29 10:35:16.370'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annomax' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di iscrizione massimo',kind = 'S',lt = {ts '2019-11-29 10:35:16.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annomax' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annomax','tassaiscrizioneconf','4',null,null,'Anno di iscrizione massimo','S',{ts '2019-11-29 10:35:16.370'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annomin' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di iscrizione minimo',kind = 'S',lt = {ts '2019-11-29 10:35:16.370'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annomin' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annomin','tassaiscrizioneconf','4',null,null,'Anno di iscrizione minimo','S',{ts '2019-11-29 10:35:16.370'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice_corsostudio' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice del corso di studio',kind = 'S',lt = {ts '2019-11-29 10:35:16.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice_corsostudio' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice_corsostudio','tassaiscrizioneconf','50',null,null,'Codice del corso di studio','S',{ts '2019-11-29 10:35:16.373'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice_didprog' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice della didattica programmata',kind = 'S',lt = {ts '2019-11-29 10:35:16.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice_didprog' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice_didprog','tassaiscrizioneconf','50',null,null,'Codice della didattica programmata','S',{ts '2019-11-29 10:35:16.373'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice_didprogcurr' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice del curriculum',kind = 'S',lt = {ts '2019-11-29 10:35:16.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice_didprogcurr' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice_didprogcurr','tassaiscrizioneconf','50',null,null,'Codice del curriculum','S',{ts '2019-11-29 10:35:16.373'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice_didprogori' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice dell''orientamento',kind = 'S',lt = {ts '2019-11-29 10:35:16.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice_didprogori' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice_didprogori','tassaiscrizioneconf','50',null,null,'Codice dell''orientamento','S',{ts '2019-11-29 10:35:16.373'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'corsisingoli' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Corsi singoli',kind = 'S',lt = {ts '2019-11-29 10:35:16.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'corsisingoli' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('corsisingoli','tassaiscrizioneconf','1',null,null,'Corsi singoli','S',{ts '2019-11-29 10:35:16.373'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:31:44.360'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tassaiscrizioneconf','8',null,null,null,'S',{ts '2019-11-29 10:31:44.360'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:31:44.360'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tassaiscrizioneconf','64',null,null,null,'S',{ts '2019-11-29 10:31:44.360'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcostoscontodef' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Costo',kind = 'S',lt = {ts '2019-11-29 10:35:16.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcostoscontodef' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcostoscontodef','tassaiscrizioneconf','4',null,null,'Costo','S',{ts '2019-11-29 10:35:16.373'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtassaiscrizioneconf' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:31:44.360'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtassaiscrizioneconf' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtassaiscrizioneconf','tassaiscrizioneconf','4',null,null,null,'S',{ts '2019-11-29 10:31:44.360'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:31:44.360'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tassaiscrizioneconf','8',null,null,null,'S',{ts '2019-11-29 10:31:44.360'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:31:44.360'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tassaiscrizioneconf','64',null,null,null,'S',{ts '2019-11-29 10:31:44.360'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'tassaiscrizioneconf')
UPDATE [coldescr] SET col_len = '2024',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-29 10:31:44.360'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','tassaiscrizioneconf','2024',null,null,null,'S',{ts '2019-11-29 10:31:44.360'},'assistenza','N','varchar(2024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

