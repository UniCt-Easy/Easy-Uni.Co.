
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
-- CREAZIONE TABELLA corsostudio --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[corsostudio] (
idcorsostudio int NOT NULL,
almalaureasurvey char(1) NULL,
annoistituz int NULL,
basevoto int NULL,
codice varchar(50) NULL,
codicemiur varchar(10) NULL,
codicemiurlungo varchar(50) NULL,
crediti int NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
durata int NULL,
idcorsostudiokind int NOT NULL,
idcorsostudiolivello int NULL,
idcorsostudionorma int NULL,
idduratakind int NULL,
idstruttura int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obbform nvarchar(max) NULL,
sboccocc nvarchar(max) NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
 CONSTRAINT xpkcorsostudio PRIMARY KEY (idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA corsostudio --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'almalaureasurvey' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD almalaureasurvey char(1) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN almalaureasurvey char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'annoistituz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD annoistituz int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN annoistituz int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'basevoto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD basevoto int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN basevoto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD codicemiur varchar(10) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN codicemiur varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'codicemiurlungo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD codicemiurlungo varchar(50) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN codicemiurlungo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'crediti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD crediti int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN crediti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD durata int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudiokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'idcorsostudiokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idcorsostudiokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudiolivello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudiolivello int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idcorsostudiolivello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idcorsostudionorma' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idcorsostudionorma int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idcorsostudionorma int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('corsostudio') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [corsostudio] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'obbform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD obbform nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN obbform nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'sboccocc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD sboccocc nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN sboccocc nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'corsostudio' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [corsostudio] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [corsostudio] ALTER COLUMN title_en varchar(1024) NULL
GO

-- VERIFICA DI corsostudio IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'corsostudio'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudio','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','char(1)','ASSISTENZA','almalaureasurvey','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','basevoto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','varchar(50)','ASSISTENZA','codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','varchar(10)','ASSISTENZA','codicemiur','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','varchar(50)','ASSISTENZA','codicemiurlungo','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','crediti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudio','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudio','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','durata','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudio','int','ASSISTENZA','idcorsostudiokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','idcorsostudiolivello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','idcorsostudionorma','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','idduratakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudio','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudio','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','nvarchar(max)','ASSISTENZA','obbform','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','nvarchar(max)','ASSISTENZA','sboccocc','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudio','varchar(1024)','ASSISTENZA','title_en','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI corsostudio IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'corsostudio')
UPDATE customobject set isreal = 'S' where objectname = 'corsostudio'
ELSE
INSERT INTO customobject (objectname, isreal) values('corsostudio', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'corsostudio')
UPDATE [tabledescr] SET description = '2.4.2 Corso di studio',idapplication = null,isdbo = 'N',lt = {ts '2018-07-18 16:14:56.570'},lu = 'assistenza',title = 'Corso di studio' WHERE tablename = 'corsostudio'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('corsostudio','2.4.2 Corso di studio',null,'N',{ts '2018-07-18 16:14:56.570'},'assistenza','Corso di studio')
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

