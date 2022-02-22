
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
-- CREAZIONE TABELLA stipendiokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[stipendiokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stipendiokind] (
idstipendiokind int NOT NULL,
assegnoaggiuntivo decimal(7,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
elementoperequativo decimal(7,2) NULL,
idcontrattokind int NULL,
idinquadramento int NULL,
indennitadiateneo decimal(7,2) NULL,
indennitadiposizione decimal(7,2) NULL,
indintegrativaspeciale decimal(7,2) NULL,
indvacancacontrattuale decimal(7,2) NULL,
irap decimal(7,2) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oneriprevidenzialicaricoente decimal(7,2) NULL,
retribuzione decimal(7,2) NULL,
scatto nchar(10) NULL,
tempdef char(1) NULL,
totaletredicesima decimal(7,2) NULL,
tredicesimaindennitaintegrativaspeciale decimal(7,2) NULL,
 CONSTRAINT xpkstipendiokind PRIMARY KEY (idstipendiokind
)
)
END
GO

-- VERIFICA STRUTTURA stipendiokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'idstipendiokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD idstipendiokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'idstipendiokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'assegnoaggiuntivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD assegnoaggiuntivo decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN assegnoaggiuntivo decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'elementoperequativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD elementoperequativo decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN elementoperequativo decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'idinquadramento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD idinquadramento int NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN idinquadramento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indennitadiateneo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indennitadiateneo decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indennitadiateneo decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indennitadiposizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indennitadiposizione decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indennitadiposizione decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indintegrativaspeciale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indintegrativaspeciale decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indintegrativaspeciale decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'indvacancacontrattuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD indvacancacontrattuale decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN indvacancacontrattuale decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'irap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD irap decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN irap decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('stipendiokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [stipendiokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'oneriprevidenzialicaricoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD oneriprevidenzialicaricoente decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN oneriprevidenzialicaricoente decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'retribuzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD retribuzione decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN retribuzione decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD scatto nchar(10) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN scatto nchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD tempdef char(1) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN tempdef char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'totaletredicesima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD totaletredicesima decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN totaletredicesima decimal(7,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'stipendiokind' and C.name = 'tredicesimaindennitaintegrativaspeciale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [stipendiokind] ADD tredicesimaindennitaintegrativaspeciale decimal(7,2) NULL 
END
ELSE
	ALTER TABLE [stipendiokind] ALTER COLUMN tredicesimaindennitaintegrativaspeciale decimal(7,2) NULL
GO

-- VERIFICA DI stipendiokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'stipendiokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokind','int','ASSISTENZA','idstipendiokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','assegnoaggiuntivo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','elementoperequativo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','int','ASSISTENZA','idinquadramento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','indennitadiateneo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','indennitadiposizione','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','indintegrativaspeciale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','indvacancacontrattuale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','irap','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','oneriprevidenzialicaricoente','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','retribuzione','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','nchar(10)','ASSISTENZA','scatto','10','N','nchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','char(1)','ASSISTENZA','tempdef','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','totaletredicesima','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokind','decimal(7,2)','ASSISTENZA','tredicesimaindennitaintegrativaspeciale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

-- VERIFICA DI stipendiokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'stipendiokind')
UPDATE customobject set isreal = 'S' where objectname = 'stipendiokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('stipendiokind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'stipendiokind')
UPDATE [tabledescr] SET description = 'Tabelle stipendiali',idapplication = null,isdbo = 'N',lt = {ts '2020-07-14 15:48:33.000'},lu = 'assistenza',title = 'Tabelle stipendiali' WHERE tablename = 'stipendiokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('stipendiokind','Tabelle stipendiali',null,'N',{ts '2020-07-14 15:48:33.000'},'assistenza','Tabelle stipendiali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegnoaggiuntivo' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Assegno aggiuntivo',kind = 'S',lt = {ts '2020-07-14 15:52:25.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'assegnoaggiuntivo' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegnoaggiuntivo','stipendiokind','5','5','2','Assegno aggiuntivo','S',{ts '2020-07-14 15:52:25.330'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:51:21.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','stipendiokind','8',null,null,null,'S',{ts '2020-07-14 15:51:21.663'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:51:21.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','stipendiokind','64',null,null,null,'S',{ts '2020-07-14 15:51:21.663'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'elementoperequativo' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Elemento perequativo',kind = 'S',lt = {ts '2020-07-14 15:52:25.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'elementoperequativo' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('elementoperequativo','stipendiokind','5','5','2','Elemento perequativo','S',{ts '2020-07-14 15:52:25.330'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ruolo',kind = 'S',lt = {ts '2020-07-14 15:52:25.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','stipendiokind','4',null,null,'Ruolo','S',{ts '2020-07-14 15:52:25.330'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinquadramento' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Inquadramento',kind = 'S',lt = {ts '2020-07-14 15:52:25.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinquadramento' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinquadramento','stipendiokind','4',null,null,'Inquadramento','S',{ts '2020-07-14 15:52:25.330'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstipendiokind' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 17:07:16.257'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstipendiokind' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstipendiokind','stipendiokind','4',null,null,null,'S',{ts '2020-07-14 17:07:16.257'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiateneo' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Indennità di ateneo',kind = 'S',lt = {ts '2020-10-16 10:54:15.587'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'indennitadiateneo' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiateneo','stipendiokind','5','5','2','Indennità di ateneo','S',{ts '2020-10-16 10:54:15.587'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiposizione' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Indennità di posizione',kind = 'S',lt = {ts '2020-10-16 10:54:15.587'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'indennitadiposizione' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiposizione','stipendiokind','5','5','2','Indennità di posizione','S',{ts '2020-10-16 10:54:15.587'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indintegrativaspeciale' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Indennità integrativa speciale',kind = 'S',lt = {ts '2020-10-16 10:54:15.587'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'indintegrativaspeciale' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indintegrativaspeciale','stipendiokind','5','5','2','Indennità integrativa speciale','S',{ts '2020-10-16 10:54:15.587'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indvacancacontrattuale' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Indennità vacanca contrattuale',kind = 'S',lt = {ts '2020-10-16 10:54:15.587'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'indvacancacontrattuale' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indvacancacontrattuale','stipendiokind','5','5','2','Indennità vacanca contrattuale','S',{ts '2020-10-16 10:54:15.587'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'irap' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'IRAP',kind = 'S',lt = {ts '2020-07-14 15:55:03.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'irap' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('irap','stipendiokind','5','5','2','IRAP','S',{ts '2020-07-14 15:55:03.907'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:51:21.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','stipendiokind','8',null,null,null,'S',{ts '2020-07-14 15:51:21.663'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:51:21.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','stipendiokind','64',null,null,null,'S',{ts '2020-07-14 15:51:21.663'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oneriprevidenzialicaricoente' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Oneri previdenziali a carico dell''ente',kind = 'S',lt = {ts '2020-07-14 15:55:03.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'oneriprevidenzialicaricoente' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oneriprevidenzialicaricoente','stipendiokind','5','5','2','Oneri previdenziali a carico dell''ente','S',{ts '2020-07-14 15:55:03.907'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'retribuzione' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = null,kind = 'S',lt = {ts '2020-07-14 15:51:21.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'retribuzione' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('retribuzione','stipendiokind','5','5','2',null,'S',{ts '2020-07-14 15:51:21.663'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:51:21.663'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'scatto' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','stipendiokind','10',null,null,null,'S',{ts '2020-07-14 15:51:21.663'},'assistenza','N','nchar(10)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempdef' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tempo definito',kind = 'S',lt = {ts '2020-07-14 15:55:03.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempdef' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempdef','stipendiokind','1',null,null,'Tempo definito','S',{ts '2020-07-14 15:55:03.907'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totaletredicesima' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Totale tredicesima',kind = 'S',lt = {ts '2020-07-14 15:55:03.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totaletredicesima' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totaletredicesima','stipendiokind','5','5','2','Totale tredicesima','S',{ts '2020-07-14 15:55:03.907'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'stipendiokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Tredicesima indennità integrativa speciale',kind = 'S',lt = {ts '2020-10-16 10:54:15.587'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tredicesimaindennitaintegrativaspeciale','stipendiokind','5','5','2','Tredicesima indennità integrativa speciale','S',{ts '2020-10-16 10:54:15.587'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

