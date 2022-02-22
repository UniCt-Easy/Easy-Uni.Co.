
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


-- CREAZIONE TABELLA cedolino --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cedolino]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[cedolino] (
idcedolino int NOT NULL,
idcontratto int NOT NULL,
idreg int NOT NULL,
assegno decimal(18,2) NULL,
classe int NULL,
data date NULL,
idmese int NULL,
iis decimal(18,2) NULL,
irap decimal(18,2) NULL,
lordo decimal(18,2) NULL,
scatto int NULL,
stipendio decimal(18,2) NULL,
totale decimal(18,2) NULL,
year int NULL,
 CONSTRAINT xpkcedolino PRIMARY KEY (idcedolino,
idcontratto,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA cedolino --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idcedolino' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idcedolino int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cedolino') and col.name = 'idcedolino' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cedolino] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idcontratto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idcontratto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cedolino') and col.name = 'idcontratto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cedolino] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cedolino') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cedolino] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'assegno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD assegno decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN assegno decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'classe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD classe int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN classe int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD data date NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'idmese' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD idmese int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN idmese int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'iis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD iis decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN iis decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD irap decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN irap decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'lordo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD lordo decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN lordo decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD scatto int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN scatto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'stipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD stipendio decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN stipendio decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'totale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD totale decimal(18,2) NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN totale decimal(18,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cedolino' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cedolino] ADD year int NULL 
END
ELSE
	ALTER TABLE [cedolino] ALTER COLUMN year int NULL
GO

-- VERIFICA DI cedolino IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'cedolino'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cedolino','int','Generator','idcedolino','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cedolino','int','Generator','idcontratto','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cedolino','int','Generator','idreg','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','decimal(18,2)','Generator','assegno','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','int','Generator','classe','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','date','Generator','data','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','int','Generator','idmese','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','decimal(18,2)','Generator','iis','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','decimal(18,2)','Generator','irap','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','decimal(18,2)','Generator','lordo','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','int','Generator','scatto','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','decimal(18,2)','Generator','stipendio','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','decimal(18,2)','Generator','totale','9','N','decimal','System.Decimal','','2','','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','cedolino','int','Generator','year','4','N','int','System.Int32','','','','','N')
GO

-- VERIFICA DI cedolino IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'cedolino')
UPDATE customobject set isreal = 'S' where objectname = 'cedolino'
ELSE
INSERT INTO customobject (objectname, isreal) values('cedolino', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'cedolino')
UPDATE [tabledescr] SET description = 'Cedolino',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-04 16:24:14.377'},lu = 'Generator',title = 'Cedolino' WHERE tablename = 'cedolino'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('cedolino','Cedolino','2','S',{ts '2021-11-04 16:24:14.377'},'Generator','Cedolino')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegno' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Assegno aggiuntivo',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'assegno' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegno','cedolino','9','18','2','Assegno aggiuntivo','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'classe' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'classe' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('classe','cedolino','4',null,null,null,'S',{ts '2021-11-04 16:19:41.657'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:24:14.383'},lu = 'Generator',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','cedolino','3',null,null,'','S',{ts '2021-11-04 16:24:14.383'},'Generator','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcedolino' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcedolino' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcedolino','cedolino','4',null,null,'','S',{ts '2021-11-04 16:19:41.657'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontratto' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontratto' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontratto','cedolino','4',null,null,'','S',{ts '2021-11-04 16:19:41.657'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmese' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:24:14.383'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idmese' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmese','cedolino','4',null,null,'','S',{ts '2021-11-04 16:24:14.383'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','cedolino','4',null,null,'','S',{ts '2021-11-04 16:19:41.657'},'Generator','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iis' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Indennità integrativa speciale',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'iis' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iis','cedolino','9','18','2','Indennità integrativa speciale','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'irap' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'IRAP',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'irap' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('irap','cedolino','9','18','2','IRAP','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lordo' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Retribuzione totale lorda',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'lordo' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lordo','cedolino','9','18','2','Retribuzione totale lorda','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'scatto' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','cedolino','4',null,null,null,'S',{ts '2021-11-04 16:19:41.657'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stipendio' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = null,kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'stipendio' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stipendio','cedolino','9','18','2',null,'S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totale' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '9',col_precision = '18',col_scale = '2',description = 'Totale costo annuo',kind = 'S',lt = {ts '2021-11-04 16:19:41.657'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(18,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totale' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totale','cedolino','9','18','2','Totale costo annuo','S',{ts '2021-11-04 16:19:41.657'},'Generator','N','decimal(18,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'cedolino')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-11-04 16:24:14.383'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'cedolino'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','cedolino','4',null,null,'','S',{ts '2021-11-04 16:24:14.383'},'Generator','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

