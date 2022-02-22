
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
-- CREAZIONE TABELLA graduatoriadesc --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[graduatoriadesc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[graduatoriadesc] (
idgraduatoriadesc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
gradmax decimal(9,2) NULL,
gradmin decimal(9,2) NULL,
gradval decimal(9,2) NULL,
idgraduatoria int NOT NULL,
idgraduatoriavar int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
molt decimal(9,2) NULL,
prefer char(1) NULL,
 CONSTRAINT xpkgraduatoriadesc PRIMARY KEY (idgraduatoriadesc
)
)
END
GO

-- VERIFICA STRUTTURA graduatoriadesc --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'idgraduatoriadesc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD idgraduatoriadesc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriadesc') and col.name = 'idgraduatoriadesc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriadesc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriadesc') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriadesc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriadesc') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriadesc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'gradmax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD gradmax decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN gradmax decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'gradmin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD gradmin decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN gradmin decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'gradval' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD gradval decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN gradval decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'idgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD idgraduatoria int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriadesc') and col.name = 'idgraduatoria' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriadesc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN idgraduatoria int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'idgraduatoriavar' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD idgraduatoriavar int NULL 
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN idgraduatoriavar int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriadesc') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriadesc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('graduatoriadesc') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [graduatoriadesc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'molt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD molt decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN molt decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'graduatoriadesc' and C.name = 'prefer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [graduatoriadesc] ADD prefer char(1) NULL 
END
ELSE
	ALTER TABLE [graduatoriadesc] ALTER COLUMN prefer char(1) NULL
GO

-- VERIFICA DI graduatoriadesc IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'graduatoriadesc'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriadesc','int','ASSISTENZA','idgraduatoriadesc','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriadesc','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriadesc','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriadesc','decimal(9,2)','ASSISTENZA','gradmax','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriadesc','decimal(9,2)','ASSISTENZA','gradmin','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriadesc','decimal(9,2)','ASSISTENZA','gradval','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriadesc','int','ASSISTENZA','idgraduatoria','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriadesc','int','ASSISTENZA','idgraduatoriavar','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriadesc','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','graduatoriadesc','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriadesc','decimal(9,2)','ASSISTENZA','molt','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','graduatoriadesc','char(1)','ASSISTENZA','prefer','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI graduatoriadesc IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'graduatoriadesc')
UPDATE customobject set isreal = 'S' where objectname = 'graduatoriadesc'
ELSE
INSERT INTO customobject (objectname, isreal) values('graduatoriadesc', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'graduatoriadesc')
UPDATE [tabledescr] SET description = 'descrive come usare una variabile del calcolo sulla 2.4.36 Graduatoria
',idapplication = null,isdbo = 'N',lt = {ts '2020-03-04 15:44:47.100'},lu = 'assistenza',title = 'Parametri del calcolo' WHERE tablename = 'graduatoriadesc'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('graduatoriadesc','descrive come usare una variabile del calcolo sulla 2.4.36 Graduatoria
',null,'N',{ts '2020-03-04 15:44:47.100'},'assistenza','Parametri del calcolo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 15:44:50.417'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','graduatoriadesc','8',null,null,null,'S',{ts '2020-03-04 15:44:50.417'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 15:44:50.417'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','graduatoriadesc','64',null,null,null,'S',{ts '2020-03-04 15:44:50.417'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'gradmax' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Punteggio assegnato fino al valore',kind = 'S',lt = {ts '2020-03-04 15:47:58.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'gradmax' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('gradmax','graduatoriadesc','5','9','2','Punteggio assegnato fino al valore','S',{ts '2020-03-04 15:47:58.083'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'gradmin' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Punteggio assegnato a partire dal valore',kind = 'S',lt = {ts '2020-03-04 15:47:58.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'gradmin' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('gradmin','graduatoriadesc','5','9','2','Punteggio assegnato a partire dal valore','S',{ts '2020-03-04 15:47:58.083'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'gradval' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Punteggio',kind = 'S',lt = {ts '2020-03-04 15:47:58.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'gradval' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('gradval','graduatoriadesc','5','9','2','Punteggio','S',{ts '2020-03-04 15:47:58.083'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoria' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 15:44:50.417'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoria' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoria','graduatoriadesc','4',null,null,null,'S',{ts '2020-03-04 15:44:50.417'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoriadesc' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 15:44:50.417'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoriadesc' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoriadesc','graduatoriadesc','4',null,null,null,'S',{ts '2020-03-04 15:44:50.417'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoriavar' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Variabile del calcolo',kind = 'S',lt = {ts '2020-03-04 15:47:58.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoriavar' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoriavar','graduatoriadesc','4',null,null,'Variabile del calcolo','S',{ts '2020-03-04 15:47:58.083'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 15:44:50.417'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','graduatoriadesc','8',null,null,null,'S',{ts '2020-03-04 15:44:50.417'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-03-04 15:44:50.417'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','graduatoriadesc','64',null,null,null,'S',{ts '2020-03-04 15:44:50.417'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'molt' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Moltiplicatore',kind = 'S',lt = {ts '2020-03-04 15:47:58.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'molt' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('molt','graduatoriadesc','5','9','2','Moltiplicatore','S',{ts '2020-03-04 15:47:58.083'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'prefer' AND tablename = 'graduatoriadesc')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Preferenza a pari merito (crescente o decrescente)',kind = 'S',lt = {ts '2020-03-04 15:47:58.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'prefer' AND tablename = 'graduatoriadesc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('prefer','graduatoriadesc','1',null,null,'Preferenza a pari merito (crescente o decrescente)','S',{ts '2020-03-04 15:47:58.083'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3257')
UPDATE [relation] SET childtable = 'graduatoriadesc',description = 'graduatoria della variabile',lt = {ts '2018-07-18 17:47:37.600'},lu = 'assistenza',parenttable = 'graduatoria',title = null WHERE idrelation = '3257'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3257','graduatoriadesc','graduatoria della variabile',{ts '2018-07-18 17:47:37.600'},'assistenza','graduatoria',null)
GO

-- FINE GENERAZIONE SCRIPT --

