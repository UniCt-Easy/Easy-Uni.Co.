
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


-- CREAZIONE TABELLA perfvalutazioneuo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazioneuo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazioneuo] (
idperfvalutazioneuo int NOT NULL,
idstruttura int NOT NULL,
completamentopsauo decimal(19,2) NULL,
completamentopsuo decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idperfschedastatus int NULL,
idreg_appr int NULL,
idreg_val int NULL,
indicatori decimal(19,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obiettiviindividuali decimal(19,2) NULL,
pesoindicatori decimal(19,2) NULL,
pesoobiettivi decimal(19,2) NULL,
pesoprogaltreuo decimal(19,2) NULL,
pesoproguo decimal(19,2) NULL,
risultato decimal(19,2) NULL,
year int NULL,
 CONSTRAINT xpkperfvalutazioneuo PRIMARY KEY (idperfvalutazioneuo,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazioneuo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idperfvalutazioneuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idperfvalutazioneuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'idperfvalutazioneuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'completamentopsauo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD completamentopsauo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN completamentopsauo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'completamentopsuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD completamentopsuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN completamentopsuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idperfschedastatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idperfschedastatus int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN idperfschedastatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idreg_appr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idreg_appr int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN idreg_appr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'idreg_val' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD idreg_val int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN idreg_val int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'indicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD indicatori decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN indicatori decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'obiettiviindividuali' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD obiettiviindividuali decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN obiettiviindividuali decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoindicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoindicatori decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoindicatori decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoprogaltreuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoprogaltreuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoprogaltreuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'pesoproguo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD pesoproguo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN pesoproguo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'risultato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD risultato decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN risultato decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuo' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuo] ADD year int NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuo] ALTER COLUMN year int NULL
GO

-- VERIFICA DI perfvalutazioneuo IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfvalutazioneuo'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuo','int','assistenza','idperfvalutazioneuo','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuo','int','assistenza','idstruttura','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','completamentopsauo','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','completamentopsuo','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuo','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuo','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','int','assistenza','idperfschedastatus','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','int','Generator','idreg_appr','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','int','assistenza','idreg_val','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','indicatori','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuo','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfvalutazioneuo','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','obiettiviindividuali','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','pesoindicatori','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','pesoobiettivi','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','pesoprogaltreuo','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','pesoproguo','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','decimal(19,2)','assistenza','risultato','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfvalutazioneuo','int','assistenza','year','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI perfvalutazioneuo IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfvalutazioneuo')
UPDATE customobject set isreal = 'S' where objectname = 'perfvalutazioneuo'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfvalutazioneuo', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfvalutazioneuo')
UPDATE [tabledescr] SET description = 'Schede di valutazione delle Unità organizzative',idapplication = '2',isdbo = 'S',lt = {ts '2022-02-07 16:19:26.943'},lu = 'Generator',title = 'Schede di valutazione delle Unità organizzative' WHERE tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfvalutazioneuo','Schede di valutazione delle Unità organizzative','2','S',{ts '2022-02-07 16:19:26.943'},'Generator','Schede di valutazione delle Unità organizzative')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'completamentopsauo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento dei progetti Strategici di altre UO',kind = 'S',lt = {ts '2021-07-30 13:07:41.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'completamentopsauo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('completamentopsauo','perfvalutazioneuo','9','19','2','Percentuale di completamento dei progetti Strategici di altre UO','S',{ts '2021-07-30 13:07:41.427'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'completamentopsuo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento per i progetti Strategici della UO',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'completamentopsuo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('completamentopsuo','perfvalutazioneuo','9','19','2','Percentuale di completamento per i progetti Strategici della UO','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','perfvalutazioneuo','8',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','perfvalutazioneuo','64',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfschedastatus' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato',kind = 'S',lt = {ts '2021-05-31 17:06:34.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfschedastatus' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfschedastatus','perfvalutazioneuo','4',null,null,'Stato','S',{ts '2021-05-31 17:06:34.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfvalutazioneuo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-01 17:07:15.013'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idperfvalutazioneuo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfvalutazioneuo','perfvalutazioneuo','4',null,null,null,'S',{ts '2021-06-01 17:07:15.013'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_appr' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-06 15:28:12.583'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_appr' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_appr','perfvalutazioneuo','4',null,null,'','S',{ts '2021-10-06 15:28:12.583'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_val' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Valutatore',kind = 'S',lt = {ts '2021-05-31 17:06:34.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_val' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_val','perfvalutazioneuo','4',null,null,'Valutatore','S',{ts '2021-05-31 17:06:34.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura',kind = 'S',lt = {ts '2021-06-10 16:17:39.787'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','perfvalutazioneuo','4',null,null,'Struttura','S',{ts '2021-06-10 16:17:39.787'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicatori' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento degli indicatori',kind = 'S',lt = {ts '2021-07-30 13:11:42.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'indicatori' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicatori','perfvalutazioneuo','9','19','2','Percentuale di completamento degli indicatori','S',{ts '2021-07-30 13:11:42.140'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','perfvalutazioneuo','8',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-06-08 16:39:43.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','perfvalutazioneuo','64',null,null,null,'S',{ts '2021-06-08 16:39:43.450'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obiettiviindividuali' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Percentuale di completamento degli obiettivi una tantum',kind = 'S',lt = {ts '2021-09-29 13:15:20.600'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'obiettiviindividuali' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obiettiviindividuali','perfvalutazioneuo','9','19','2','Percentuale di completamento degli obiettivi una tantum','S',{ts '2021-09-29 13:15:20.600'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoindicatori' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance degli indicatori ',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoindicatori' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoindicatori','perfvalutazioneuo','9','19','2','Peso della valutazione della performance degli indicatori ','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoobiettivi' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance degli obiettivi una tantum',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoobiettivi' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoobiettivi','perfvalutazioneuo','9','19','2','Peso della valutazione della performance degli obiettivi una tantum','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoprogaltreuo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance dei Progetti Strategici di altre UO ',kind = 'S',lt = {ts '2021-07-30 13:07:41.427'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoprogaltreuo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoprogaltreuo','perfvalutazioneuo','9','19','2','Peso della valutazione della performance dei Progetti Strategici di altre UO ','S',{ts '2021-07-30 13:07:41.427'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pesoproguo' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Peso della valutazione della performance dei Progetti Strategici della UO',kind = 'S',lt = {ts '2021-07-30 13:05:33.463'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'pesoproguo' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pesoproguo','perfvalutazioneuo','9','19','2','Peso della valutazione della performance dei Progetti Strategici della UO','S',{ts '2021-07-30 13:05:33.463'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'risultato' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Risultato %',kind = 'S',lt = {ts '2021-07-30 13:12:39.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'risultato' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('risultato','perfvalutazioneuo','9','19','2','Risultato %','S',{ts '2021-07-30 13:12:39.723'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'perfvalutazioneuo')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno solare',kind = 'S',lt = {ts '2021-05-31 17:06:34.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'perfvalutazioneuo'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','perfvalutazioneuo','4',null,null,'Anno solare','S',{ts '2021-05-31 17:06:34.270'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

