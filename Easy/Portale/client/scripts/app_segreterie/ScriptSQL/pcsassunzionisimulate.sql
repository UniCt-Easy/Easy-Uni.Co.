
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


-- CREAZIONE TABELLA pcsassunzionisimulate --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcsassunzionisimulate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pcsassunzionisimulate] (
idpcsassunzionisimulate int NOT NULL,
year int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data datetime NULL,
finanziamento varchar(150) NULL,
idcontrattokind int NULL,
idcontrattokind_start int NULL,
idsasd int NULL,
idstruttura int NULL,
legge varchar(250) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nominativo varchar(150) NULL,
numeropersoneassunzione decimal(19,2) NULL,
percentuale decimal(19,2) NULL,
stipendio decimal(19,2) NULL,
totale decimal(19,2) NULL,
totale1 decimal(19,2) NULL,
totale2 decimal(19,2) NULL,
totale3 decimal(19,2) NULL,
 CONSTRAINT xpkpcsassunzionisimulate PRIMARY KEY (idpcsassunzionisimulate,
year
)
)
END
GO

-- VERIFICA STRUTTURA pcsassunzionisimulate --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'idpcsassunzionisimulate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD idpcsassunzionisimulate int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzionisimulate') and col.name = 'idpcsassunzionisimulate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzionisimulate] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD year int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzionisimulate') and col.name = 'year' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzionisimulate] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzionisimulate') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzionisimulate] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzionisimulate') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzionisimulate] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD data datetime NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN data datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'finanziamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD finanziamento varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN finanziamento varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'idcontrattokind_start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD idcontrattokind_start int NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN idcontrattokind_start int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'legge' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD legge varchar(250) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN legge varchar(250) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzionisimulate') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzionisimulate] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pcsassunzionisimulate') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pcsassunzionisimulate] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'nominativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD nominativo varchar(150) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN nominativo varchar(150) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'numeropersoneassunzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD numeropersoneassunzione decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN numeropersoneassunzione decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD percentuale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN percentuale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'stipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD stipendio decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN stipendio decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD totale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN totale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'totale1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD totale1 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN totale1 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'totale2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD totale2 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN totale2 decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pcsassunzionisimulate' and C.name = 'totale3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pcsassunzionisimulate] ADD totale3 decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [pcsassunzionisimulate] ALTER COLUMN totale3 decimal(19,2) NULL
GO

-- VERIFICA DI pcsassunzionisimulate IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pcsassunzionisimulate'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcsassunzionisimulate','int','Generator','idpcsassunzionisimulate','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcsassunzionisimulate','int','Generator','year','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcsassunzionisimulate','datetime','Generator','ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcsassunzionisimulate','varchar(64)','Generator','cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','datetime','Generator','data','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','varchar(150)','Generator','finanziamento','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','int','Generator','idcontrattokind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','int','Generator','idcontrattokind_start','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','int','Generator','idsasd','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','int','Generator','idstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','varchar(250)','Generator','legge','250','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcsassunzionisimulate','datetime','Generator','lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcsassunzionisimulate','varchar(64)','Generator','lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','varchar(150)','Generator','nominativo','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','decimal(19,2)','Generator','numeropersoneassunzione','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','decimal(19,2)','Generator','percentuale','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','decimal(19,2)','Generator','stipendio','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','decimal(19,2)','Generator','totale','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','decimal(19,2)','Generator','totale1','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','decimal(19,2)','Generator','totale2','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcsassunzionisimulate','decimal(19,2)','Generator','totale3','9','N','decimal','System.Decimal','','2','','19','N')
GO

-- VERIFICA DI pcsassunzionisimulate IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pcsassunzionisimulate')
UPDATE customobject set isreal = 'S' where objectname = 'pcsassunzionisimulate'
ELSE
INSERT INTO customobject (objectname, isreal) values('pcsassunzionisimulate', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'pcsassunzionisimulate')
UPDATE [tabledescr] SET description = 'Assunzioni simulate',idapplication = '2',isdbo = 'S',lt = {ts '2022-01-31 12:29:07.127'},lu = 'Generator',title = 'Assunzioni simulate' WHERE tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('pcsassunzionisimulate','Assunzioni simulate','2','S',{ts '2022-01-31 12:29:07.127'},'Generator','Assunzioni simulate')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','pcsassunzionisimulate','8',null,null,'','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','pcsassunzionisimulate','64',null,null,'','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data assunzione presunta',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','pcsassunzionisimulate','8',null,null,'Data assunzione presunta','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanziamento' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Finanziamento',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'finanziamento' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanziamento','pcsassunzionisimulate','150',null,null,'Finanziamento','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Qualifica/Categoria',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','pcsassunzionisimulate','4',null,null,'Qualifica/Categoria','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind_start' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Qualifica/Categoria di partenza',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind_start' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind_start','pcsassunzionisimulate','4',null,null,'Qualifica/Categoria di partenza','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpcsassunzionisimulate' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpcsassunzionisimulate' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpcsassunzionisimulate','pcsassunzionisimulate','4',null,null,'','S',{ts '2022-01-31 12:29:07.130'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SSD',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','pcsassunzionisimulate','4',null,null,'SSD','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dipartimento',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','pcsassunzionisimulate','4',null,null,'Dipartimento','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'legge' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '250',col_precision = null,col_scale = null,description = 'Legge/Decreto',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(250)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'legge' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('legge','pcsassunzionisimulate','250',null,null,'Legge/Decreto','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','varchar(250)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','pcsassunzionisimulate','8',null,null,'','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','pcsassunzionisimulate','64',null,null,'','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nominativo' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Nominativo',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'nominativo' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nominativo','pcsassunzionisimulate','150',null,null,'Nominativo','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numeropersoneassunzione' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Numero di persone su nuova assunzione',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'numeropersoneassunzione' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numeropersoneassunzione','pcsassunzionisimulate','9','19','2','Numero di persone su nuova assunzione','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'percentuale' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Indicare la percentuale di stipendio da considerare.',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'percentuale' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('percentuale','pcsassunzionisimulate','9','19','2','Indicare la percentuale di stipendio da considerare.','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipendio' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Stipendio tabellare più basso',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'stipendio' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipendio','pcsassunzionisimulate','9','19','2','Stipendio tabellare più basso','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale anno in analisi',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale','pcsassunzionisimulate','9','19','2','Totale anno in analisi','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale1' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale anno in analisi +1',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale1' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale1','pcsassunzionisimulate','9','19','2','Totale anno in analisi +1','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale2' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale anno in analisi +2',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale2' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale2','pcsassunzionisimulate','9','19','2','Totale anno in analisi +2','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale3' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale anno in analisi +3',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale3' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale3','pcsassunzionisimulate','9','19','2','Totale anno in analisi +3','S',{ts '2022-01-31 12:29:07.130'},'Generator','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'pcsassunzionisimulate')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-01-31 12:29:07.130'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'pcsassunzionisimulate'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','pcsassunzionisimulate','4',null,null,'','S',{ts '2022-01-31 12:29:07.130'},'Generator','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

