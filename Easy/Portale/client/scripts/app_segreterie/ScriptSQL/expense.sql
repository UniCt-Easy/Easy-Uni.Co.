
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


-- CREAZIONE TABELLA expense --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expense]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expense] (
idexp int NOT NULL,
adate date NOT NULL,
autocode int NULL,
autokind tinyint NULL,
cigcode varchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cupcode varchar(15) NULL,
description varchar(150) NOT NULL,
doc varchar(35) NULL,
docdate date NULL,
expiration date NULL,
external_reference varchar(200) NULL,
flag int NULL,
idclawback int NULL,
idformerexpense int NULL,
idinc_linked int NULL,
idman int NULL,
idpayment int NULL,
idreg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nmov int NOT NULL,
nphase tinyint NOT NULL,
parentidexp int NULL,
rtf image NULL,
txt text NULL,
ymov smallint NOT NULL,
 CONSTRAINT xpkexpense PRIMARY KEY (idexp
)
)
END
GO

-- VERIFICA STRUTTURA expense --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idexp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'idexp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'adate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD adate date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'adate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN adate date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autocode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD autocode int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN autocode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'autokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD autokind tinyint NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN autokind tinyint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'cigcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD cigcode varchar(10) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN cigcode varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'cupcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD cupcode varchar(15) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN cupcode varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'doc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD doc varchar(35) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN doc varchar(35) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'docdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD docdate date NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN docdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'expiration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD expiration date NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN expiration date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'external_reference' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD external_reference varchar(200) NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN external_reference varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD flag int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN flag int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idclawback' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idclawback int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idclawback int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idformerexpense' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idformerexpense int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idformerexpense int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idinc_linked' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idinc_linked int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idinc_linked int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idman int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idpayment' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idpayment int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idpayment int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nmov' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD nmov int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'nmov' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN nmov int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'nphase' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD nphase tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'nphase' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN nphase tinyint NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'parentidexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD parentidexp int NULL 
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN parentidexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD txt text NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expense' and C.name = 'ymov' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expense] ADD ymov smallint NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expense') and col.name = 'ymov' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expense] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expense] ALTER COLUMN ymov smallint NOT NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='uq1expense' and id=object_id('expense'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1expense
     ON expense (nphase, ymov, nmov )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX uq1expense
     ON expense (nphase, ymov, nmov )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi10expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi10expense
     ON expense (description, nphase )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi10expense
     ON expense (description, nphase )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi12expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi12expense
     ON expense (parentidexp )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi12expense
     ON expense (parentidexp )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi13expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi13expense
     ON expense (idinc_linked )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi13expense
     ON expense (idinc_linked )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1expense
     ON expense (nphase )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1expense
     ON expense (nphase )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2expense
     ON expense (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2expense
     ON expense (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3expense
     ON expense (idreg, doc, docdate )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3expense
     ON expense (idreg, doc, docdate )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4expense
     ON expense (idman )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4expense
     ON expense (idman )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8expense
     ON expense (idpayment )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8expense
     ON expense (idpayment )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9expense' and id=object_id('expense'))
BEGIN
     CREATE NONCLUSTERED INDEX xi9expense
     ON expense (idformerexpense )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi9expense
     ON expense (idformerexpense )
ON [PRIMARY]
END
GO

-- VERIFICA DI expense IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expense'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','int','assistenza','idexp','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','date','assistenza','adate','3','S','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','autocode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','tinyint','assistenza','autokind','1','N','tinyint','System.Byte','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','varchar(10)','assistenza','cigcode','10','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','varchar(15)','assistenza','cupcode','15','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','varchar(150)','assistenza','description','150','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','varchar(35)','assistenza','doc','35','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','date','assistenza','docdate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','date','assistenza','expiration','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','varchar(200)','assistenza','external_reference','200','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','flag','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','idclawback','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','idformerexpense','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','idinc_linked','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','idman','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','idpayment','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','int','assistenza','nmov','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','tinyint','assistenza','nphase','1','S','tinyint','System.Byte','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','int','assistenza','parentidexp','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','image','assistenza','rtf','16','N','image','System.Byte[]','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expense','text','assistenza','txt','16','N','text','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expense','smallint','assistenza','ymov','2','S','smallint','System.Int16','','','''assistenza''','','N')
GO

-- VERIFICA DI expense IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expense')
UPDATE customobject set isreal = 'S' where objectname = 'expense'
ELSE
INSERT INTO customobject (objectname, isreal) values('expense', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'expense')
UPDATE [tabledescr] SET description = 'Movimento di spesa',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:28.813'},lu = 'nino',title = 'Movimento di spesa' WHERE tablename = 'expense'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('expense','Movimento di spesa','1','N',{ts '1900-01-01 03:00:28.813'},'nino','Movimento di spesa')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'adate' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data contabile',kind = 'S',lt = {ts '1900-01-01 02:59:52.837'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'adate' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('adate','expense','4',null,null,'data contabile','S',{ts '1900-01-01 02:59:52.837'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'autocode' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Automatismo',kind = 'S',lt = {ts '1900-01-01 02:59:19.197'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'autocode' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('autocode','expense','4',null,null,'Codice Automatismo','S',{ts '1900-01-01 02:59:19.197'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'autokind' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Tipo automatismo, descritto in tabella autokind',kind = 'S',lt = {ts '2016-07-08 11:44:54.030'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'autokind' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('autokind','expense','1',null,null,'Tipo automatismo, descritto in tabella autokind','S',{ts '2016-07-08 11:44:54.030'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cigcode' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Codice CIG',kind = 'S',lt = {ts '1900-01-01 03:00:09.433'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cigcode' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cigcode','expense','10',null,null,'Codice CIG','S',{ts '1900-01-01 03:00:09.433'},'nino','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:46.980'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','expense','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:46.980'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:44.413'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','expense','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:44.413'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cupcode' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Codice CUP',kind = 'S',lt = {ts '1900-01-01 03:00:08.180'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cupcode' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cupcode','expense','15',null,null,'Codice CUP','S',{ts '1900-01-01 03:00:08.180'},'nino','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:50.860'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','expense','150',null,null,'Descrizione','S',{ts '1900-01-01 02:59:50.860'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'doc' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '35',col_precision = null,col_scale = null,description = 'documento',kind = 'S',lt = {ts '1900-01-01 02:59:56.717'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(35)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'doc' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('doc','expense','35',null,null,'documento','S',{ts '1900-01-01 02:59:56.717'},'nino','N','varchar(35)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'docdate' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'data documento',kind = 'S',lt = {ts '1900-01-01 02:59:56.383'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'docdate' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('docdate','expense','4',null,null,'data documento','S',{ts '1900-01-01 02:59:56.383'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'expiration' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'scadenza',kind = 'S',lt = {ts '1900-01-01 03:00:03.703'},lu = 'nino',primarykey = 'N',sql_declaration = 'smalldatetime',sql_type = 'smalldatetime',system_type = 'System.DateTime' WHERE colname = 'expiration' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('expiration','expense','4',null,null,'scadenza','S',{ts '1900-01-01 03:00:03.703'},'nino','N','smalldatetime','smalldatetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'external_reference' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Chiave esterna per db collegati',kind = 'S',lt = {ts '1900-01-01 03:00:25.153'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'external_reference' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('external_reference','expense','200',null,null,'Chiave esterna per db collegati','S',{ts '1900-01-01 03:00:25.153'},'nino','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclawback' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id recupero (tabella recupero)',kind = 'S',lt = {ts '1900-01-01 03:00:15.710'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclawback' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclawback','expense','4',null,null,'Id recupero (tabella recupero)','S',{ts '1900-01-01 03:00:15.710'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idexp' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id mov. spesa (tabella expense)',kind = 'S',lt = {ts '1900-01-01 02:59:19.350'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idexp' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idexp','expense','4',null,null,'id mov. spesa (tabella expense)','S',{ts '1900-01-01 02:59:19.350'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idformerexpense' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id economia di spesa (idexp di expense) associata qualora questo movimento. Questo movimento è valorizzato nella maschera ct_expenselast_reset (storno residui catania) e expense_wizardcreamovcompetenza (riemissione dei movimenti in competenza)',kind = 'S',lt = {ts '2016-10-07 09:05:09.993'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idformerexpense' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idformerexpense','expense','4',null,null,'id economia di spesa (idexp di expense) associata qualora questo movimento. Questo movimento è valorizzato nella maschera ct_expenselast_reset (storno residui catania) e expense_wizardcreamovcompetenza (riemissione dei movimenti in competenza)','S',{ts '2016-10-07 09:05:09.993'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idman' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id responsabile (tabella manager)',kind = 'S',lt = {ts '1900-01-01 02:59:21.810'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idman' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idman','expense','4',null,null,'id responsabile (tabella manager)','S',{ts '1900-01-01 02:59:21.810'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpayment' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id mov. spesa collegato (idexp di expense)',kind = 'S',lt = {ts '1900-01-01 03:00:05.943'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpayment' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpayment','expense','4',null,null,'id mov. spesa collegato (idexp di expense)','S',{ts '1900-01-01 03:00:05.943'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:52.110'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','expense','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:52.110'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:41.563'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','expense','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:41.563'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:38.597'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','expense','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:38.597'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nmov' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'N.movimento',kind = 'S',lt = {ts '1900-01-01 03:00:01.183'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nmov' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nmov','expense','4',null,null,'N.movimento','S',{ts '1900-01-01 03:00:01.183'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nphase' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'N.fase',kind = 'S',lt = {ts '1900-01-01 03:00:00.323'},lu = 'nino',primarykey = 'N',sql_declaration = 'tinyint',sql_type = 'tinyint',system_type = 'System.Byte' WHERE colname = 'nphase' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nphase','expense','1',null,null,'N.fase','S',{ts '1900-01-01 03:00:00.323'},'nino','N','tinyint','tinyint','System.Byte')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parentidexp' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id movimento padre (idexp di tabella expense)',kind = 'S',lt = {ts '1900-01-01 03:00:12.900'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'parentidexp' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parentidexp','expense','4',null,null,'id movimento padre (idexp di tabella expense)','S',{ts '1900-01-01 03:00:12.900'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.443'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','expense','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.443'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.107'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','expense','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.107'},'nino','N','text','text','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ymov' AND tablename = 'expense')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Anno movimento',kind = 'S',lt = {ts '1900-01-01 03:00:00.943'},lu = 'nino',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'ymov' AND tablename = 'expense'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ymov','expense','2',null,null,'Anno movimento','S',{ts '1900-01-01 03:00:00.943'},'nino','N','smallint','smallint','System.Int16')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '361')
UPDATE [relation] SET childtable = 'expense',description = 'Id recupero (tabella recupero)',lt = {ts '2017-05-20 09:19:42.593'},lu = 'lu',parenttable = 'clawback',title = 'Movimento di spesa' WHERE idrelation = '361'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('361','expense','Id recupero (tabella recupero)',{ts '2017-05-20 09:19:42.593'},'lu','clawback','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '610')
UPDATE [relation] SET childtable = 'expense',description = 'N.fase',lt = {ts '2017-05-20 09:19:48.660'},lu = 'lu',parenttable = 'expensephase',title = 'Movimento di spesa' WHERE idrelation = '610'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('610','expense','N.fase',{ts '2017-05-20 09:19:48.660'},'lu','expensephase','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1152')
UPDATE [relation] SET childtable = 'expense',description = 'id responsabile (tabella manager)',lt = {ts '2017-05-20 09:19:59.413'},lu = 'lu',parenttable = 'manager',title = 'Movimento di spesa' WHERE idrelation = '1152'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1152','expense','id responsabile (tabella manager)',{ts '2017-05-20 09:19:59.413'},'lu','manager','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2065')
UPDATE [relation] SET childtable = 'expense',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:05.860'},lu = 'lu',parenttable = 'registry',title = 'Movimento di spesa' WHERE idrelation = '2065'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2065','expense','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:05.860'},'lu','registry','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2978')
UPDATE [relation] SET childtable = 'expense',description = 'id movimento padre (idexp di tabella expense)',lt = {ts '2017-05-21 20:46:40.413'},lu = 'nino',parenttable = 'expense',title = 'Movimento di spesa' WHERE idrelation = '2978'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2978','expense','id movimento padre (idexp di tabella expense)',{ts '2017-05-21 20:46:40.413'},'nino','expense','Movimento di spesa')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3053')
UPDATE [relation] SET childtable = 'expense',description = 'id mov. spesa collegato (idexp di expense)',lt = {ts '2017-05-22 11:42:39.117'},lu = 'nino',parenttable = 'expense',title = null WHERE idrelation = '3053'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3053','expense','id mov. spesa collegato (idexp di expense)',{ts '2017-05-22 11:42:39.117'},'nino','expense',null)
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '361' AND parentcol = 'idclawback')
UPDATE [relationcol] SET childcol = 'idclawback',lt = {ts '2017-05-20 09:19:42.660'},lu = 'lu' WHERE idrelation = '361' AND parentcol = 'idclawback'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('361','idclawback','idclawback',{ts '2017-05-20 09:19:42.660'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

