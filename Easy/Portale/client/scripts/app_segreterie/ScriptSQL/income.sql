
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


-- CREAZIONE TABELLA income --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[income]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [income] (
idinc int NOT NULL,
adate date NOT NULL,
autocode int NULL,
autokind tinyint NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate date NULL,
expiration date NULL,
external_reference varchar(200) NULL,
flag int NULL,
idman int NULL,
idpayment int NULL,
idreg int NULL,
idunderwriting int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmov int NOT NULL,
nphase tinyint NOT NULL,
parentidinc int NULL,
rtf image NULL,
txt text NULL,
ymov smallint NOT NULL,
 CONSTRAINT xpkincome PRIMARY KEY (idinc
)
)
END
GO

-- VERIFICA STRUTTURA income --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idinc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'idinc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'adate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD adate date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'adate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN adate date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'autocode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD autocode int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN autocode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'autokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD autokind tinyint NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN autokind tinyint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'cupcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD cupcode varchar(15) NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN cupcode varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'doc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD doc varchar(35) NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN doc varchar(35) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'docdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD docdate date NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN docdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'expiration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD expiration date NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN expiration date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'external_reference' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD external_reference varchar(200) NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN external_reference varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD flag int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN flag int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idman int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idpayment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idpayment int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN idpayment int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'idunderwriting' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD idunderwriting int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN idunderwriting int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'nmov' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD nmov int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'nmov' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN nmov int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD nphase tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'nphase' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN nphase tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'parentidinc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD parentidinc int NULL 
END
ELSE
	ALTER TABLE [income] ALTER COLUMN parentidinc int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD txt text NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'income' and C.name = 'ymov' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [income] ADD ymov smallint NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('income') and col.name = 'ymov' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [income] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [income] ALTER COLUMN ymov smallint NOT NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='uq1income' and id=object_id('income'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1income
     ON income (nphase, ymov, nmov )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1income
     ON income (nphase, ymov, nmov )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi10income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi10income
     ON income (description, nphase )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi10income
     ON income (description, nphase )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1income
     ON income (nphase )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1income
     ON income (nphase )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2income
     ON income (parentidinc )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2income
     ON income (parentidinc )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3income
     ON income (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3income
     ON income (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4income
     ON income (idreg, doc, docdate )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4income
     ON income (idreg, doc, docdate )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5income
     ON income (idman )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5income
     ON income (idman )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8income
     ON income (idpayment, autokind, idreg )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8income
     ON income (idpayment, autokind, idreg )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9income' and id=object_id('income'))
BEGIN
     CREATE NONCLUSTERED INDEX xi9income
     ON income (idpayment )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi9income
     ON income (idpayment )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA DI income IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'income'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','int','assistenza','idinc','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','date','assistenza','adate','3','S','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','int','assistenza','autocode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','tinyint','assistenza','autokind','1','N','tinyint','System.Byte','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','varchar(15)','assistenza','cupcode','15','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','varchar(150)','assistenza','description','150','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','varchar(35)','assistenza','doc','35','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','date','assistenza','docdate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','date','assistenza','expiration','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','varchar(200)','assistenza','external_reference','200','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','int','assistenza','flag','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','int','assistenza','idman','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','int','assistenza','idpayment','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','int','assistenza','idunderwriting','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','int','assistenza','nmov','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','tinyint','assistenza','nphase','1','S','tinyint','System.Byte','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','int','assistenza','parentidinc','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','image','assistenza','rtf','16','N','image','System.Byte[]','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','income','text','assistenza','txt','16','N','text','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','income','smallint','assistenza','ymov','2','S','smallint','System.Int16','','','''assistenza''','','N')
GO

-- VERIFICA DI income IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'income')
UPDATE customobject set isreal = 'S' where objectname = 'income'
ELSE
INSERT INTO customobject (objectname, isreal) values('income', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'income')
UPDATE [tabledescr] SET description = 'Movimento di entrata',idapplication = '2',isdbo = 'N',lt = {ts '2022-01-17 12:42:12.907'},lu = 'Generator',title = 'Movimento di entrata' WHERE tablename = 'income'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('income','Movimento di entrata','2','N',{ts '2022-01-17 12:42:12.907'},'Generator','Movimento di entrata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'adate' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data contabile',kind = 'S',lt = {ts '1900-01-01 02:59:52.910'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'adate' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('adate','income','4',null,null,'data contabile','S',{ts '1900-01-01 02:59:52.910'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'autocode' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Automatismo',kind = 'S',lt = {ts '1900-01-01 02:59:19.247'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'autocode' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('autocode','income','4',null,null,'Codice Automatismo','S',{ts '1900-01-01 02:59:19.247'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'autokind' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tipo automatismo, descritto in tabella autokind',kind = 'S',lt = {ts '2016-07-08 11:45:07.353'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'autokind' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('autokind','income','1',null,null,'Tipo automatismo, descritto in tabella autokind','S',{ts '2016-07-08 11:45:07.353'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:47.277'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','income','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:47.277'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.710'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','income','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.710'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cupcode' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Codice CUP',kind = 'S',lt = {ts '1900-01-01 03:00:08.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cupcode' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cupcode','income','15',null,null,'Codice CUP','S',{ts '1900-01-01 03:00:08.197'},'nino','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:50.993'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','income','150',null,null,'Descrizione','S',{ts '1900-01-01 02:59:50.993'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'doc' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '35',col_precision = null,col_scale = null,description = 'documento',kind = 'S',lt = {ts '1900-01-01 02:59:56.770'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(35)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'doc' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('doc','income','35',null,null,'documento','S',{ts '1900-01-01 02:59:56.770'},'nino','N','varchar(35)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'docdate' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data documento',kind = 'S',lt = {ts '1900-01-01 02:59:56.430'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'docdate' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('docdate','income','4',null,null,'data documento','S',{ts '1900-01-01 02:59:56.430'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'expiration' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'scadenza',kind = 'S',lt = {ts '1900-01-01 03:00:03.753'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'expiration' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('expiration','income','4',null,null,'scadenza','S',{ts '1900-01-01 03:00:03.753'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'external_reference' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Chiave esterna per db collegati',kind = 'S',lt = {ts '1900-01-01 03:00:25.167'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'external_reference' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('external_reference','income','200',null,null,'Chiave esterna per db collegati','S',{ts '1900-01-01 03:00:25.167'},'nino','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2022-01-17 12:42:12.910'},lu = 'Generator',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'flag' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag','income','4',null,null,'','S',{ts '2022-01-17 12:42:12.910'},'Generator','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idinc' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id mov. entrata (tabella income)',kind = 'S',lt = {ts '1900-01-01 02:59:19.657'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idinc' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idinc','income','4',null,null,'id mov. entrata (tabella income)','S',{ts '1900-01-01 02:59:19.657'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idman' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id responsabile (tabella manager)',kind = 'S',lt = {ts '1900-01-01 02:59:21.887'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idman' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idman','income','4',null,null,'id responsabile (tabella manager)','S',{ts '1900-01-01 02:59:21.887'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpayment' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id mov. spesa collegato (idexp di expense)',kind = 'S',lt = {ts '1900-01-01 03:00:05.983'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpayment' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpayment','income','4',null,null,'id mov. spesa collegato (idexp di expense)','S',{ts '1900-01-01 03:00:05.983'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:52.167'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','income','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:52.167'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idunderwriting' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id finanziamento (tabella underwriting)',kind = 'S',lt = {ts '1900-01-01 03:00:05.383'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idunderwriting' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idunderwriting','income','4',null,null,'id finanziamento (tabella underwriting)','S',{ts '1900-01-01 03:00:05.383'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','income','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.937'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.967'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','income','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.967'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nmov' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'N.movimento',kind = 'S',lt = {ts '1900-01-01 03:00:01.243'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nmov' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nmov','income','4',null,null,'N.movimento','S',{ts '1900-01-01 03:00:01.243'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nphase' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'N.fase',kind = 'S',lt = {ts '1900-01-01 03:00:00.367'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'nphase' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nphase','income','1',null,null,'N.fase','S',{ts '1900-01-01 03:00:00.367'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parentidinc' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id movimento padre (tabella income)',kind = 'S',lt = {ts '1900-01-01 03:00:25.423'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'parentidinc' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parentidinc','income','4',null,null,'Id movimento padre (tabella income)','S',{ts '1900-01-01 03:00:25.423'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.460'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','income','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.460'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.130'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','income','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.130'},'nino','N','text','text','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ymov' AND tablename = 'income')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Anno movimento',kind = 'S',lt = {ts '1900-01-01 03:00:01.000'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'ymov' AND tablename = 'income'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ymov','income','2',null,null,'Anno movimento','S',{ts '1900-01-01 03:00:01.000'},'nino','N','smallint','smallint','System.Int16')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '948')
UPDATE [relation] SET childtable = 'income',description = 'N.fase',lt = {ts '2017-05-20 09:19:53.537'},lu = 'lu',parenttable = 'incomephase',title = 'Movimento di entrata' WHERE idrelation = '948'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('948','income','N.fase',{ts '2017-05-20 09:19:53.537'},'lu','incomephase','Movimento di entrata')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1157')
UPDATE [relation] SET childtable = 'income',description = 'id responsabile (tabella manager)',lt = {ts '2017-05-20 09:19:59.413'},lu = 'lu',parenttable = 'manager',title = 'Movimento di entrata' WHERE idrelation = '1157'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1157','income','id responsabile (tabella manager)',{ts '2017-05-20 09:19:59.413'},'lu','manager','Movimento di entrata')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2068')
UPDATE [relation] SET childtable = 'income',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:05.860'},lu = 'lu',parenttable = 'registry',title = 'Movimento di entrata' WHERE idrelation = '2068'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2068','income','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:05.860'},'lu','registry','Movimento di entrata')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2745')
UPDATE [relation] SET childtable = 'income',description = 'id finanziamento (tabella underwriting)',lt = {ts '2017-05-20 09:20:12.127'},lu = 'lu',parenttable = 'underwriting',title = 'Movimento di entrata' WHERE idrelation = '2745'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2745','income','id finanziamento (tabella underwriting)',{ts '2017-05-20 09:20:12.127'},'lu','underwriting','Movimento di entrata')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2979')
UPDATE [relation] SET childtable = 'income',description = 'Id movimento padre (tabella income)',lt = {ts '2017-05-21 20:46:07.893'},lu = 'nino',parenttable = 'income',title = 'Movimento di entrata' WHERE idrelation = '2979'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2979','income','Id movimento padre (tabella income)',{ts '2017-05-21 20:46:07.893'},'nino','income','Movimento di entrata')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3019')
UPDATE [relation] SET childtable = 'income',description = 'id mov. spesa collegato (idexp di expense)',lt = {ts '2017-05-22 10:20:43.093'},lu = 'nino',parenttable = 'expense',title = 'Movimento di entrata' WHERE idrelation = '3019'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3019','income','id mov. spesa collegato (idexp di expense)',{ts '2017-05-22 10:20:43.093'},'nino','expense','Movimento di entrata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '948' AND parentcol = 'nphase')
UPDATE [relationcol] SET childcol = 'nphase',lt = {ts '2017-05-20 09:19:53.677'},lu = 'lu' WHERE idrelation = '948' AND parentcol = 'nphase'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('948','nphase','nphase',{ts '2017-05-20 09:19:53.677'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

