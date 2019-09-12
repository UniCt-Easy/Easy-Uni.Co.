-- CREAZIONE TABELLA payment_bank --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[payment_bank]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [payment_bank] (
kpay int NOT NULL,
idpay int NOT NULL,
amount decimal(19,2) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(200) NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nbill int NULL,
 CONSTRAINT xpkpayment_bank PRIMARY KEY (kpay,
idpay
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1payment_bank' and id=object_id('payment_bank'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment_bank
     ON payment_bank
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment_bank
     ON payment_bank
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1payment_bank' and id=object_id('payment_bank'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment_bank
     ON payment_bank
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1payment_bank
     ON payment_bank
     (
     kpay     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA STRUTTURA payment_bank --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'kpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD kpay int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'kpay' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'idpay' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD idpay int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'idpay' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'amount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD amount decimal(19,2) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'amount' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN amount decimal(19,2) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD description varchar(200) NULL 
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN description varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('payment_bank') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [payment_bank] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'payment_bank' and C.name = 'nbill' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [payment_bank] ADD nbill int NULL 
END
ELSE
	ALTER TABLE [payment_bank] ALTER COLUMN nbill int NULL
GO

-- VERIFICA DI payment_bank IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'payment_bank'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','N','System.Int32','int','S','payment_bank','N','','4','idpay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','payment_bank','S','','4','kpay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','payment_bank','S','','9','amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','datetime','','N','System.DateTime','datetime','N','payment_bank','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','N','System.String','varchar(64)','N','payment_bank','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','S','System.String','varchar(200)','N','payment_bank','N','','200','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','N','System.Int32','int','N','payment_bank','S','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','datetime','','N','System.DateTime','datetime','N','payment_bank','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','varchar','','N','System.String','varchar(64)','N','payment_bank','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SA''','','int','','S','System.Int32','int','N','payment_bank','N','','4','nbill','')
GO

-- VERIFICA DI payment_bank IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'payment_bank')
UPDATE customobject set isreal = 'S' where objectname = 'payment_bank'
ELSE
INSERT INTO customobject (objectname, isreal) values('payment_bank', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

